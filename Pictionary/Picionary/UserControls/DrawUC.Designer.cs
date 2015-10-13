namespace Pictionary.UserControls
{
    partial class DrawUC
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
            this.paintPanel = new System.Windows.Forms.Panel();
            this.colorChooser = new System.Windows.Forms.Panel();
            this.drawLabel = new System.Windows.Forms.Label();
            this.clearBTN = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.sendText = new System.Windows.Forms.TextBox();
            this.submitImageBTN = new System.Windows.Forms.Button();
            this.askWordBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paintPanel
            // 
            this.paintPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paintPanel.Location = new System.Drawing.Point(14, 15);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(792, 544);
            this.paintPanel.TabIndex = 0;
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseDown);
            this.paintPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseMove);
            this.paintPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseUp);
            // 
            // colorChooser
            // 
            this.colorChooser.BackColor = System.Drawing.Color.Black;
            this.colorChooser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorChooser.Location = new System.Drawing.Point(14, 565);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(45, 46);
            this.colorChooser.TabIndex = 2;
            this.colorChooser.Click += new System.EventHandler(this.colorChooser_Click);
            // 
            // drawLabel
            // 
            this.drawLabel.AutoSize = true;
            this.drawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawLabel.Location = new System.Drawing.Point(375, 575);
            this.drawLabel.Name = "drawLabel";
            this.drawLabel.Size = new System.Drawing.Size(0, 25);
            this.drawLabel.TabIndex = 3;
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Transparent;
            this.clearBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBTN.Location = new System.Drawing.Point(66, 570);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(47, 35);
            this.clearBTN.TabIndex = 4;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // chatBox
            // 
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBox.Location = new System.Drawing.Point(812, 15);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(262, 544);
            this.chatBox.TabIndex = 5;
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(812, 565);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(262, 20);
            this.sendText.TabIndex = 6;
            this.sendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendText_KeyPress);
            // 
            // submitImageBTN
            // 
            this.submitImageBTN.Location = new System.Drawing.Point(120, 570);
            this.submitImageBTN.Name = "submitImageBTN";
            this.submitImageBTN.Size = new System.Drawing.Size(147, 35);
            this.submitImageBTN.TabIndex = 7;
            this.submitImageBTN.Text = "Submit Image";
            this.submitImageBTN.UseVisualStyleBackColor = true;
            this.submitImageBTN.Click += new System.EventHandler(this.submitImageBTN_Click);
            // 
            // askWordBTN
            // 
            this.askWordBTN.Location = new System.Drawing.Point(274, 570);
            this.askWordBTN.Name = "askWordBTN";
            this.askWordBTN.Size = new System.Drawing.Size(75, 23);
            this.askWordBTN.TabIndex = 8;
            this.askWordBTN.Text = "Get Word";
            this.askWordBTN.UseVisualStyleBackColor = true;
            this.askWordBTN.Click += new System.EventHandler(this.askWordBTN_Click);
            // 
            // DrawUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.askWordBTN);
            this.Controls.Add(this.submitImageBTN);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.drawLabel);
            this.Controls.Add(this.colorChooser);
            this.Controls.Add(this.paintPanel);
            this.Name = "DrawUC";
            this.Size = new System.Drawing.Size(1077, 614);
            this.VisibleChanged += new System.EventHandler(this.DrawUC_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.Panel colorChooser;
        private System.Windows.Forms.Label drawLabel;
        private System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.Button submitImageBTN;
        private System.Windows.Forms.Button askWordBTN;
    }
}
