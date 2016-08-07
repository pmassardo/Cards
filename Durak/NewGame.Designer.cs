namespace Durak
{
    partial class frmNewGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewGame));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.cboDeckSize = new System.Windows.Forms.ComboBox();
            this.chkAdvanced = new System.Windows.Forms.CheckBox();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.NewGameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(5, 8);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(70, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "&Player Name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(80, 5);
            this.txtPlayerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(96, 20);
            this.txtPlayerName.TabIndex = 1;
            this.NewGameToolTip.SetToolTip(this.txtPlayerName, "Enter the player name here.");
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Black;
            this.btnStartGame.Location = new System.Drawing.Point(80, 79);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(96, 23);
            this.btnStartGame.TabIndex = 5;
            this.btnStartGame.Text = "&Start Game";
            this.NewGameToolTip.SetToolTip(this.btnStartGame, "Click to start the game.");
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // cboDeckSize
            // 
            this.cboDeckSize.FormattingEnabled = true;
            this.cboDeckSize.Location = new System.Drawing.Point(80, 30);
            this.cboDeckSize.Name = "cboDeckSize";
            this.cboDeckSize.Size = new System.Drawing.Size(96, 21);
            this.cboDeckSize.TabIndex = 3;
            this.NewGameToolTip.SetToolTip(this.cboDeckSize, "Select the DeckSize.");
            // 
            // chkAdvanced
            // 
            this.chkAdvanced.AutoSize = true;
            this.chkAdvanced.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAdvanced.Location = new System.Drawing.Point(15, 57);
            this.chkAdvanced.Name = "chkAdvanced";
            this.chkAdvanced.Size = new System.Drawing.Size(78, 17);
            this.chkAdvanced.TabIndex = 4;
            this.chkAdvanced.Text = "&Advanced:";
            this.NewGameToolTip.SetToolTip(this.chkAdvanced, "Check if you want Advance play.");
            this.chkAdvanced.UseVisualStyleBackColor = true;
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.Location = new System.Drawing.Point(16, 30);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(59, 13);
            this.lblDeckSize.TabIndex = 2;
            this.lblDeckSize.Text = "&Deck Size:";
            // 
            // frmNewGame
            // 
            this.AcceptButton = this.btnStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(182, 108);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.chkAdvanced);
            this.Controls.Add(this.cboDeckSize);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.lblPlayerName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewGame";
            this.Text = "New Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewGame_FormClosing);
            this.Load += new System.EventHandler(this.frmNewGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.ComboBox cboDeckSize;
        private System.Windows.Forms.CheckBox chkAdvanced;
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.ToolTip NewGameToolTip;
    }
}