using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MathQuizAdventure
{
    public partial class LeaderboardForm : Form
    {
        public LeaderboardForm()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MathQuiz;Integrated Security=True";
            string query = "SELECT TOP 10 PlayerName, Score, DifficultyLevel, GameMode, Timestamp FROM Scores ORDER BY Score DESC, Timestamp DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    leaderboardDataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading leaderboard: {ex.Message}");
                }
            }
        }

    }
}
