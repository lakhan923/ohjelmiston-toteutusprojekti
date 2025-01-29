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
    public partial class GameModeSelectionForm : Form
    {
        public string SelectedMode { get; private set; } = "Single Player";

        public GameModeSelectionForm()
        {
            InitializeComponent();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            SelectedMode = "Single Player";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTwoPlayer_Click(object sender, EventArgs e)
        {
            SelectedMode = "Two Player";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
