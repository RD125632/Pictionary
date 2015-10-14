namespace Pictionary
{
    partial class WinnerForm
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
            this.winner1 = new Pictionary.UserControls.Winner(this.message, this);
            this.SuspendLayout();
            // 
            // winner1
            // 
            this.winner1.BackColor = System.Drawing.Color.White;
            this.winner1.Location = new System.Drawing.Point(2, 2);
            this.winner1.Name = "winner1";
            this.winner1.Size = new System.Drawing.Size(830, 454);
            this.winner1.TabIndex = 0;
            // 
            // WinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(834, 458);
            this.Controls.Add(this.winner1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinnerForm";
            this.Text = "WinnerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Winner winner1;
    }
}