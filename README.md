# ohjelmiston-toteutusprojekti


## About
- **Author**: Laiba Khan
- **Game name**: MathQuizAdventure Game
- **Game platform**: Windows
- **Number of players**: single player, Two players
- **itch.io page**: https://laiba-khan.itch.io/mathquizadventure

## Technology Stack 
- **Language**: C#
- **Framework**: Windows Forms (.NET Framework)
- **Database**: SQL Server / MySQL
- **Tools**: Visual Studio
- **Version Control**: Git and GitHub

## Game story
MathQuiz is an engaging Windows Forms application designed to improve mathematical skills through interactive gameplay. The game offers both single-player and two-player modes, allowing players to challenge themselves or compete against a friend. With multiple difficulty levels, sound effects, and a leaderboard system, MathQuiz provides a fun and rewarding experience.
The game generates random math puzzles based on the selected difficulty level. Players must choose the correct answer from four options before the timer runs out. The game features multiple rounds with increasing difficulty, and players earn points for each correct answer. In two-player mode, players alternate turns, and the player with the highest score at the end wins. The score is tracked throughout the game, and the first player to reach 10 points is declared the winner.

## Project Structure 
- **Forms**: 
  - Main Form (`Form1.cs`) for gameplay.
  - Leaderboard Form (`LeaderboardForm.cs`) for displaying top scores with player names.
  - Game Mode Selection (`GameModeSelectionForm.cs`).
  - Difficulty Selection (`DifficultySelectionForm.cs`).
- **Database**: 
  - `Scores` table to store player scores and game details.

## Core Features
- **Single Player Mode**: Challenge yourself to achieve the highest score.
- **Two Player Mode**: Compete with a friend to see who gets the highest score.
- **Difficulty Levels**: Choose between Easy, Medium, and Hard levels.
- **Leaderboard**: Track top scores.
- **Sound Effects**: Background, Correct, wrong, and game-over sound effects for an immersive experience.
- **Timer**: Timer is set to 10 seconds for each question.
- **question generation**: Generate random math questions according to the difficulty level.

## Game outline
![Game Outline](https://github.com/lakhan923/ohjelmiston-toteutusprojekti/raw/main/mathquizadventue_outline.JPG)

## Deployment
- **Publish as an Executable**: I will Use Visual Studio's publishing tools to create an .exe file for the game.
- **Planned Publication on itch.io**: The game will be published on itch.io to allow for easy distribution and accessibility for players.


