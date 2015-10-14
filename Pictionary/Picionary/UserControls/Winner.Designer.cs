namespace Pictionary.UserControls
{
    partial class Winner
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nxtWord = new System.Windows.Forms.Button();
            this.nameLBL = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.sswLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pictionary.Properties.Resources.RoPaxman_We_have_a_winner;
            this.pictureBox1.Location = new System.Drawing.Point(183, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 251);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nxtWord
            // 
            this.nxtWord.BackColor = System.Drawing.Color.Maroon;
            this.nxtWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxtWord.ForeColor = System.Drawing.Color.White;
            this.nxtWord.Location = new System.Drawing.Point(235, 378);
            this.nxtWord.Name = "nxtWord";
            this.nxtWord.Size = new System.Drawing.Size(338, 56);
            this.nxtWord.TabIndex = 1;
            this.nxtWord.Text = "Next Word";
            this.nxtWord.UseVisualStyleBackColor = false;
            this.nxtWord.Click += new System.EventHandler(this.nxtWord_Click);
            // 
            // nameLBL
            // 
            this.nameLBL.AutoSize = true;
            this.nameLBL.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLBL.ForeColor = System.Drawing.Color.DarkGreen;
            this.nameLBL.Location = new System.Drawing.Point(318, 282);
            this.nameLBL.Name = "nameLBL";
            this.nameLBL.Size = new System.Drawing.Size(64, 20);
            this.nameLBL.TabIndex = 2;
            this.nameLBL.Text = "Richard";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(398, 282);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(105, 20);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "guessed right!";
            // 
            // sswLBL
            // 
            this.sswLBL.AutoSize = true;
            this.sswLBL.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sswLBL.ForeColor = System.Drawing.Color.DarkGreen;
            this.sswLBL.Location = new System.Drawing.Point(319, 316);
            this.sswLBL.Name = "sswLBL";
            this.sswLBL.Size = new System.Drawing.Size(49, 20);
            this.sswLBL.TabIndex = 4;
            this.sswLBL.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "was the answer!";
            // 
            // Winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sswLBL);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.nameLBL);
            this.Controls.Add(this.nxtWord);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Winner";
            this.Size = new System.Drawing.Size(830, 454);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button nxtWord;
        private System.Windows.Forms.Label nameLBL;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label sswLBL;
        private System.Windows.Forms.Label label4;
    }
}
