using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;
using MathQuizAdventure.Database;


namespace MathQuizAdventure
{
    public partial class Form1 : Form
    {
        public string difficultyLevel = "Easy"; // Default to Easy
        public string gameMode = "Single Player"; // Default to Single Player

        public int correctAnswer;
        public int score = 0;
        public int timeRemaining = 10; // 30 seconds for each puzzle
        public int selectedAnswer = -1; // Default value, no answer selected yet
        public Random rnd = new Random();

        // SoundPlayer 
        public SoundPlayer correctSound;
        public SoundPlayer wrongSound;
        public SoundPlayer backgroundMusic;
        public SoundPlayer gameOverSound;

        public string currentPlayer = "Player 1"; // Tracks the current player
        public int player1Score = 0; // Player 1's score
        public int player2Score = 0; // Player 2's score

        public Form1()
        {
            InitializeComponent();
            GenerateNewPuzzle();
            ShowGameModeSelection();
            ShowDifficultySelection();

            // Initialize SoundPlayer with file paths
            try
            {
                correctSound = new SoundPlayer(@"C:\Users\laaai\Desktop\MathQuizAdventure\MathQuizAdventure\Sounds\correct_sound.wav");
                wrongSound = new SoundPlayer(@"C:\Users\laaai\Desktop\MathQuizAdventure\MathQuizAdventure\Sounds\wrong_sound.wav");
                backgroundMusic = new SoundPlayer(@"C:\Users\laaai\Desktop\MathQuizAdventure\MathQuizAdventure\Sounds\background_music.wav");
                gameOverSound = new SoundPlayer(@"C:\Users\laaai\Desktop\MathQuizAdventure\MathQuizAdventure\Sounds\gameover_sound.wav");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sounds: {ex.Message}");
            }
            PlayBackgroundMusic();  // Start background music
        }

        public void PlayBackgroundMusic()
        {
            try
            {
                backgroundMusic.PlayLooping(); // Play music continuously
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }

        public void StopBackgroundMusic()
        {
            try
            {
                backgroundMusic.Stop(); // Stop music
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping background music: {ex.Message}");
            }
        }

        public void PlayWinningSound()
        {
            try
            {
                SoundPlayer winningSound = new SoundPlayer(@"C:\Users\laaai\Desktop\MathQuizAdventure\MathQuizAdventure\Sounds\winning_sound.wav");
                winningSound.PlaySync(); // Play the winning sound synchronously
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing winning sound: {ex.Message}");
            }
        }

        public void ShowGameModeSelection()
        {
            // Show game mode selection
            using (var gameModeForm = new GameModeSelectionForm())
            {
                if (gameModeForm.ShowDialog() == DialogResult.OK)
                {
                    gameMode = gameModeForm.SelectedMode; // Set the selected mode
                }
                else
                {
                    // Default to single-player mode if the user closes the dialog
                    gameMode = "Single Player";
                }
            }
        }

        public void ShowDifficultySelection()
        {
            using (var difficultyForm = new DifficultySelectionForm())
            {
                if (difficultyForm.ShowDialog() == DialogResult.OK)
                {
                    difficultyLevel = difficultyForm.SelectedDifficulty;
                }
            }
        }

        // Method to generate a new math puzzle
        public void GenerateNewPuzzle()
        {
            int num1, num2, operation;

            if (difficultyLevel == "Easy")
            {
                num1 = rnd.Next(1, 10);
                num2 = rnd.Next(1, 10);
                operation = rnd.Next(0, 2); // Addition, Subtraction
            }
            else if (difficultyLevel == "Medium")
            {
                num1 = rnd.Next(10, 50);
                num2 = rnd.Next(10, 50);
                operation = rnd.Next(0, 4); // Addition, Subtraction
            }
            else // Hard
            {
                num1 = rnd.Next(-50, 50); // Include negative numbers
                num2 = rnd.Next(-50, 50);
                operation = rnd.Next(0, 4);
            }

            string question;
            if (operation == 0)
            {
                question = $"{num1} + {num2} = ?";
                correctAnswer = num1 + num2;
            }
            else
            {
                question = $"{num1} - {num2} = ?";
                correctAnswer = num1 - num2;
            }

            lblProblem.Text = question;

            // Randomly assign answers to buttons
            int correctButtonIndex = rnd.Next(0, 4);
            if (correctButtonIndex == 0) btnAnswer1.Text = correctAnswer.ToString();
            else if (correctButtonIndex == 1) btnAnswer2.Text = correctAnswer.ToString();
            else if (correctButtonIndex == 2) btnAnswer3.Text = correctAnswer.ToString();
            else btnAnswer4.Text = correctAnswer.ToString();

            // Set wrong answers
            SetRandomIncorrectAnswers(correctButtonIndex);

            // Reset selected answer
            selectedAnswer = -1;

            // Reset the timer to 10 seconds for each new question
            timeRemaining = 10;
            lblTimer.Text = $"Time: {timeRemaining}s"; // Update the timer display
        }

        // Method to set random incorrect answers
        public void SetRandomIncorrectAnswers(int correctButtonIndex)
        {
            HashSet<int> usedAnswers = new HashSet<int> { correctAnswer };
            List<int> wrongAnswers = new List<int>();

            while (wrongAnswers.Count < 3)
            {
                int wrongAnswer = rnd.Next(correctAnswer - 10, correctAnswer + 10); // Adjust range if necessary
                if (wrongAnswer != correctAnswer && usedAnswers.Add(wrongAnswer))
                {
                    wrongAnswers.Add(wrongAnswer);
                }
            }

            // Assign wrong answers to buttons
            int i = 0;
            if (correctButtonIndex != 0) btnAnswer1.Text = wrongAnswers[i++].ToString();
            if (correctButtonIndex != 1) btnAnswer2.Text = wrongAnswers[i++].ToString();
            if (correctButtonIndex != 2) btnAnswer3.Text = wrongAnswers[i++].ToString();
            if (correctButtonIndex != 3) btnAnswer4.Text = wrongAnswers[i].ToString();
        }

        public void btnAnswer1_Click(object sender, EventArgs e)
        {
            selectedAnswer = int.Parse(btnAnswer1.Text); // Store the selected answer
        }

        // For btnAnswer2
        public void btnAnswer2_Click(object sender, EventArgs e)
        {
            selectedAnswer = int.Parse(btnAnswer2.Text); // Store the selected answer
        }

        // For btnAnswer3
        public void btnAnswer3_Click(object sender, EventArgs e)
        {
            selectedAnswer = int.Parse(btnAnswer3.Text); // Store the selected answer
        }

        // For btnAnswer4
        public void btnAnswer4_Click(object sender, EventArgs e)
        {
            selectedAnswer = int.Parse(btnAnswer4.Text); // Store the selected answer
        }

        public void btnStart_Click(object sender, EventArgs e)
        {

            player1Score = 0;
            player2Score = 0;
            currentPlayer = "Player 1"; // Start with Player 1
            score = 0;
            timeRemaining = 30; // Reset timer
            lblTimer.Text = $"Time: {timeRemaining}s";
            lblScore.Text = gameMode == "Two Player" ? $"Player 1: 0 | Player 2: 0" : $"Score: 0";
            lblCurrentPlayer.Text = gameMode == "Two Player" ? $"{currentPlayer}'s Turn" : "";

            btnStart.Enabled = false; // Disable start button during the game
            gameTimer.Start();
            GenerateNewPuzzle();

        }


        public void gameTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--; // Decrease the time by 1 second
            lblTimer.Text = $"Time: {timeRemaining}s"; // Update the label

            if (timeRemaining <= 0)
            {
                gameTimer.Stop(); // Stop the timer when it reaches 0
                StopBackgroundMusic(); // Stop the background music when the game ends
                                       // Update the score display
                                       // Determine the winner in Two Player mode
                if (gameMode == "Two Player")
                {
                    if (player1Score > player2Score)
                    {
                        MessageBox.Show($"Game Over!\n\nCongratulations Player 1! You won with a score of {player1Score}.\nPlayer 2 scored {player2Score}.",
                                        "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PlayWinningSound();
                    }
                    else if (player2Score > player1Score)
                    {
                        MessageBox.Show($"Game Over!\n\nCongratulations Player 2! You won with a score of {player2Score}.\nPlayer 1 scored {player1Score}.",
                                        "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PlayWinningSound();
                    }
                    else
                    {
                        MessageBox.Show($"Game Over!\n\nIt's a tie! Both players scored {player1Score}.",
                                        "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Save both players' scores
                    SavePlayerScore("Player 1", player1Score);
                    SavePlayerScore("Player 2", player2Score);
                }
                else // Single Player mode
                {
                    MessageBox.Show($"Game Over! Final Score: {score}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Save single-player score
                    SavePlayerScore("Single Player", score);
                }

                try
                {
                    gameOverSound.PlaySync(); // Play the game-over sound synchronously
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing game-over sound: {ex.Message}");
                }

                btnStart.Enabled = true; // Enable the start button for a new game
            }
        }

        public void SavePlayerScore(string playerName, int score)
        {
            try
            {
                DatabaseConnection.SaveScore(playerName, score, difficultyLevel, gameMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving score: {ex.Message}");
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            if (selectedAnswer != -1) // Ensure that an answer was selected
            {
                if (selectedAnswer == correctAnswer) // Check if the selected answer is correct
                {
                    if (gameMode == "Two Player")
                    {
                        // Update the score for the current player
                        if (currentPlayer == "Player 1")
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }

                        // Update the score label after the score change
                        lblScore.Text = $"Player 1: {player1Score} | Player 2: {player2Score}";
                        MessageBox.Show($"{currentPlayer} got it correct!");
                    }
                    else
                    {
                        // Single Player Mode
                        score++;
                        lblScore.Text = $"Score: {score}";
                        MessageBox.Show("Correct!");
                    }

                    correctSound.PlaySync(); // Play correct answer sound
                    PlayBackgroundMusic();
                }
                else
                {
                    wrongSound.PlaySync(); // Play wrong sound
                    MessageBox.Show(gameMode == "Two Player" ? $"{currentPlayer} got it wrong!" : "Wrong!");
                    PlayBackgroundMusic();
                }

                if (gameMode == "Two Player")
                {
                    SwitchPlayer(); // Alternate players
                }

                GenerateNewPuzzle(); // Generate a new puzzle
            }
            else
            {
                MessageBox.Show("Please select an answer before submitting.");
            }
        }

        public void SwitchPlayer()
        {
            // Alternate between Player 1 and Player 2
            if (gameMode == "Two Player") // Only switch players in Two Player Mode
            {
                if (currentPlayer == "Player 1")
                {
                    currentPlayer = "Player 2"; // Switch to Player 2
                }
                else
                {
                    currentPlayer = "Player 1"; // Switch to Player 1
                }
                lblCurrentPlayer.Text = $"{currentPlayer}'s Turn"; // Update turn display
            }
        }


        public void btnLeaderboard_Click(object sender, EventArgs e)
        {
            LeaderboardForm leaderboardForm = new LeaderboardForm();
            leaderboardForm.Show(); // Show the leaderboard form

        }
    }
}
