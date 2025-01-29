using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuizAdventure
{
    public partial class DifficultySelectionForm : Form
    {
        public string SelectedDifficulty { get;  set; } = "Easy"; // Default difficulty
        public DifficultySelectionForm()
        {
            InitializeComponent();
        }

        public void EasyButton_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = "Easy";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void MediumButton_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = "Medium";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void HardButton_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = "Hard";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
