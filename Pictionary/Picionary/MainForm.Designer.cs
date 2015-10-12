
namespace Pictionary
{


    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuBar = new System.Windows.Forms.Panel();
            this.closeBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login2 = new Pictionary.UserControls.Login();
            this.drawUC2 = new Pictionary.UserControls.DrawUC();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Controls.Add(this.closeBTN);
            this.menuBar.Location = new System.Drawing.Point(-1, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1087, 37);
            this.menuBar.TabIndex = 4;
            this.menuBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuBar_MouseDown);
            // 
            // closeBTN
            // 
            this.closeBTN.BackColor = System.Drawing.Color.Transparent;
            this.closeBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeBTN.FlatAppearance.BorderSize = 0;
            this.closeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBTN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBTN.Location = new System.Drawing.Point(1042, 3);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(38, 31);
            this.closeBTN.TabIndex = 0;
            this.closeBTN.Text = "X";
            this.closeBTN.UseVisualStyleBackColor = false;
            this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Pictionary.Properties.Resources.you_can_draw_but_you_will_never_draw_like_this_379470;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(27, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(458, 658);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // login2
            // 
            this.login2.BackColor = System.Drawing.Color.Transparent;
            this.login2.Location = new System.Drawing.Point(4, 41);
            this.login2.Name = "login2";
            this.login2.Size = new System.Drawing.Size(1077, 614);
            this.login2.TabIndex = 6;
            // 
            // drawUC2
            // 
            this.drawUC2.BackColor = System.Drawing.Color.White;
            this.drawUC2.Location = new System.Drawing.Point(4, 40);
            this.drawUC2.Name = "drawUC2";
            this.drawUC2.Size = new System.Drawing.Size(1077, 614);
            this.drawUC2.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 658);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.login2);
            this.Controls.Add(this.drawUC2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControls.Login login2;
        private UserControls.DrawUC drawUC2;
    }
}

