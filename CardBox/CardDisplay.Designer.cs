namespace CardBox
{
    partial class CardDisplay
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxPictureBox = new System.Windows.Forms.PictureBox();
            this.CardDisplayToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPictureBox
            // 
            this.pbxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxPictureBox.Location = new System.Drawing.Point(0, 0);
            this.pbxPictureBox.Name = "pbxPictureBox";
            this.pbxPictureBox.Size = new System.Drawing.Size(150, 150);
            this.pbxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPictureBox.TabIndex = 0;
            this.pbxPictureBox.TabStop = false;
            this.pbxPictureBox.Click += new System.EventHandler(this.pbxPictureBox_Click);
            // 
            // CardDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbxPictureBox);
            this.Name = "CardDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.pbxPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPictureBox;
        private System.Windows.Forms.ToolTip CardDisplayToolTip;
    }
}
