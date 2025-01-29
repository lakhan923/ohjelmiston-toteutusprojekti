using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MathQuizAdventure.Database
{
    public class DatabaseConnection
    {
        public static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MathQuiz;Integrated Security=True";
        public static void SaveScore(string playerName, int score, string difficultyLevel, string gameMode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Scores (PlayerName, Score, DifficultyLevel, GameMode, Timestamp) " +
                                   "VALUES (@PlayerName, @Score, @DifficultyLevel, @GameMode, @Timestamp)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PlayerName", playerName);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@DifficultyLevel", difficultyLevel);
                        cmd.Parameters.AddWithValue("@GameMode", gameMode);
                        cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Score successfully saved to database!");
                        }
                        else
                        {
                            MessageBox.Show("Error: No rows were inserted into the database.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
