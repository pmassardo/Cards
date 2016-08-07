namespace Durak
{
    partial class frmDurakGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDurakGame));
            this.btnRestart = new System.Windows.Forms.Button();
            this.grpComputer = new System.Windows.Forms.GroupBox();
            this.grpPlayer = new System.Windows.Forms.GroupBox();
            this.grpTalon = new System.Windows.Forms.GroupBox();
            this.grpBattleField = new System.Windows.Forms.GroupBox();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTrump = new System.Windows.Forms.Label();
            this.lblAdvanced = new System.Windows.Forms.Label();
            this.CardToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnLicence = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Black;
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(702, 386);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(96, 23);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "&Restart";
            this.CardToolTip.SetToolTip(this.btnRestart, "Click to Restart game.");
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // grpComputer
            // 
            this.grpComputer.ForeColor = System.Drawing.Color.White;
            this.grpComputer.Location = new System.Drawing.Point(4, 8);
            this.grpComputer.Name = "grpComputer";
            this.grpComputer.Size = new System.Drawing.Size(308, 340);
            this.grpComputer.TabIndex = 0;
            this.grpComputer.TabStop = false;
            this.grpComputer.Text = "Computer";
            this.CardToolTip.SetToolTip(this.grpComputer, "Computer cards appear here.");
            // 
            // grpPlayer
            // 
            this.grpPlayer.ForeColor = System.Drawing.Color.White;
            this.grpPlayer.Location = new System.Drawing.Point(490, 8);
            this.grpPlayer.Name = "grpPlayer";
            this.grpPlayer.Size = new System.Drawing.Size(308, 340);
            this.grpPlayer.TabIndex = 2;
            this.grpPlayer.TabStop = false;
            this.grpPlayer.Text = "Player";
            this.CardToolTip.SetToolTip(this.grpPlayer, "Player cards appear here.");
            // 
            // grpTalon
            // 
            this.grpTalon.ForeColor = System.Drawing.Color.White;
            this.grpTalon.Location = new System.Drawing.Point(3, 353);
            this.grpTalon.Name = "grpTalon";
            this.grpTalon.Size = new System.Drawing.Size(308, 116);
            this.grpTalon.TabIndex = 3;
            this.grpTalon.TabStop = false;
            this.grpTalon.Text = "Talon";
            this.CardToolTip.SetToolTip(this.grpTalon, "Trump will appear here.");
            // 
            // grpBattleField
            // 
            this.grpBattleField.ForeColor = System.Drawing.Color.White;
            this.grpBattleField.Location = new System.Drawing.Point(317, 8);
            this.grpBattleField.Name = "grpBattleField";
            this.grpBattleField.Size = new System.Drawing.Size(167, 461);
            this.grpBattleField.TabIndex = 1;
            this.grpBattleField.TabStop = false;
            this.grpBattleField.Text = "Battlefield";
            this.CardToolTip.SetToolTip(this.grpBattleField, "Table cards appear here.");
            // 
            // btnPickUp
            // 
            this.btnPickUp.BackColor = System.Drawing.Color.Black;
            this.btnPickUp.ForeColor = System.Drawing.Color.White;
            this.btnPickUp.Location = new System.Drawing.Point(702, 362);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(96, 23);
            this.btnPickUp.TabIndex = 7;
            this.btnPickUp.Text = "&PickUp/Disgard";
            this.CardToolTip.SetToolTip(this.btnPickUp, "Click to Pick-Up or Disgard.");
            this.btnPickUp.UseVisualStyleBackColor = false;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // lblCount
            // 
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(490, 451);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(153, 15);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Count";
            this.CardToolTip.SetToolTip(this.lblCount, "Card remaining in the Talon appears here.");
            // 
            // lblTrump
            // 
            this.lblTrump.ForeColor = System.Drawing.Color.White;
            this.lblTrump.Location = new System.Drawing.Point(490, 432);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(153, 15);
            this.lblTrump.TabIndex = 5;
            this.lblTrump.Text = "Trump";
            this.CardToolTip.SetToolTip(this.lblTrump, "Trump appears here.");
            // 
            // lblAdvanced
            // 
            this.lblAdvanced.ForeColor = System.Drawing.Color.White;
            this.lblAdvanced.Location = new System.Drawing.Point(490, 413);
            this.lblAdvanced.Name = "lblAdvanced";
            this.lblAdvanced.Size = new System.Drawing.Size(153, 15);
            this.lblAdvanced.TabIndex = 4;
            this.lblAdvanced.Text = "Advanced";
            this.CardToolTip.SetToolTip(this.lblAdvanced, "Game level appears here.");
            // 
            // btnLicence
            // 
            this.btnLicence.BackColor = System.Drawing.Color.Black;
            this.btnLicence.ForeColor = System.Drawing.Color.White;
            this.btnLicence.Location = new System.Drawing.Point(702, 434);
            this.btnLicence.Name = "btnLicence";
            this.btnLicence.Size = new System.Drawing.Size(96, 23);
            this.btnLicence.TabIndex = 10;
            this.btnLicence.Text = "&Licence";
            this.CardToolTip.SetToolTip(this.btnLicence, "Click to see licence data.");
            this.btnLicence.UseVisualStyleBackColor = false;
            this.btnLicence.Click += new System.EventHandler(this.btnLicence_Click);
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.Black;
            this.btnRules.ForeColor = System.Drawing.Color.White;
            this.btnRules.Location = new System.Drawing.Point(702, 410);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(96, 23);
            this.btnRules.TabIndex = 9;
            this.btnRules.Text = "R&ules";
            this.CardToolTip.SetToolTip(this.btnRules, "Click to display rules.");
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // frmDurakGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(801, 471);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnLicence);
            this.Controls.Add(this.lblAdvanced);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnPickUp);
            this.Controls.Add(this.grpBattleField);
            this.Controls.Add(this.grpTalon);
            this.Controls.Add(this.grpPlayer);
            this.Controls.Add(this.grpComputer);
            this.Controls.Add(this.btnRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDurakGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.GroupBox grpComputer;
        private System.Windows.Forms.GroupBox grpPlayer;
        private System.Windows.Forms.GroupBox grpTalon;
        private System.Windows.Forms.GroupBox grpBattleField;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.Label lblAdvanced;
        private System.Windows.Forms.ToolTip CardToolTip;
        private System.Windows.Forms.Button btnLicence;
        private System.Windows.Forms.Button btnRules;

    }
}

