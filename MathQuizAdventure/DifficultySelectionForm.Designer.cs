namespace MathQuizAdventure
{
    partial class DifficultySelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.EasyButton = new System.Windows.Forms.Button();
            this.MediumButton = new System.Windows.Forms.Button();
            this.HardButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EasyButton
            // 
            this.EasyButton.BackColor = System.Drawing.Color.DarkBlue;
            this.EasyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.EasyButton.Location = new System.Drawing.Point(137, 228);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(493, 44);
            this.EasyButton.TabIndex = 1;
            this.EasyButton.Text = "Easy";
            this.EasyButton.UseVisualStyleBackColor = false;
            this.EasyButton.Click += new System.EventHandler(this.EasyButton_Click);
            // 
            // MediumButton
            // 
            this.MediumButton.BackColor = System.Drawing.Color.DarkBlue;
            this.MediumButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.MediumButton.Location = new System.Drawing.Point(137, 278);
            this.MediumButton.Name = "MediumButton";
            this.MediumButton.Size = new System.Drawing.Size(493, 45);
            this.MediumButton.TabIndex = 2;
            this.MediumButton.Text = "Medium";
            this.MediumButton.UseVisualStyleBackColor = false;
            this.MediumButton.Click += new System.EventHandler(this.MediumButton_Click);
            // 
            // HardButton
            // 
            this.HardButton.BackColor = System.Drawing.Color.DarkBlue;
            this.HardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.HardButton.Location = new System.Drawing.Point(137, 329);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(493, 43);
            this.HardButton.TabIndex = 3;
            this.HardButton.Text = "Hard";
            this.HardButton.UseVisualStyleBackColor = false;
            this.HardButton.Click += new System.EventHandler(this.HardButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(161, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a Difficulty Level";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DifficultySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.BackgroundImage = global::MathQuizAdventure.Properties.Resources.leaderboard;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HardButton);
            this.Controls.Add(this.MediumButton);
            this.Controls.Add(this.EasyButton);
            this.Name = "DifficultySelectionForm";
            this.Text = "DifficultySelectionForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button EasyButton;
        private System.Windows.Forms.Button MediumButton;
        private System.Windows.Forms.Button HardButton;
        private System.Windows.Forms.Label label1;
    }
}