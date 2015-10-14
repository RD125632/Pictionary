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
            this.askWordBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paintPanel
            // 
            this.paintPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paintPanel.Location = new System.Drawing.Point(19, 18);
            this.paintPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(1055, 669);
            this.paintPanel.TabIndex = 0;
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseDown);
            this.paintPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseMove);
            this.paintPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseUp);
            // 
            // colorChooser
            // 
            this.colorChooser.BackColor = System.Drawing.Color.Black;
            this.colorChooser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorChooser.Location = new System.Drawing.Point(19, 695);
            this.colorChooser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(59, 56);
            this.colorChooser.TabIndex = 2;
            this.colorChooser.Click += new System.EventHandler(this.colorChooser_Click);
            // 
            // drawLabel
            // 
            this.drawLabel.AutoSize = true;
            this.drawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawLabel.Location = new System.Drawing.Point(500, 708);
            this.drawLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.drawLabel.Name = "drawLabel";
            this.drawLabel.Size = new System.Drawing.Size(0, 31);
            this.drawLabel.TabIndex = 3;
            // 
            // clearBTN
            // 
            this.clearBTN.BackColor = System.Drawing.Color.Transparent;
            this.clearBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBTN.Location = new System.Drawing.Point(88, 702);
            this.clearBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(63, 43);
            this.clearBTN.TabIndex = 4;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = false;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // chatBox
            // 
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBox.Location = new System.Drawing.Point(1083, 18);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(349, 669);
            this.chatBox.TabIndex = 5;
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(1083, 695);
            this.sendText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(348, 22);
            this.sendText.TabIndex = 6;
            this.sendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendText_KeyPress);
            // 
            // askWordBTN
            // 
            this.askWordBTN.Location = new System.Drawing.Point(365, 702);
            this.askWordBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.askWordBTN.Name = "askWordBTN";
            this.askWordBTN.Size = new System.Drawing.Size(100, 28);
            this.askWordBTN.TabIndex = 8;
            this.askWordBTN.Text = "Get Word";
            this.askWordBTN.UseVisualStyleBackColor = true;
            this.askWordBTN.Click += new System.EventHandler(this.askWordBTN_Click);
            // 
            // DrawUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.askWordBTN);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.drawLabel);
            this.Controls.Add(this.colorChooser);
            this.Controls.Add(this.paintPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DrawUC";
            this.Size = new System.Drawing.Size(1436, 756);
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
        private System.Windows.Forms.Button askWordBTN;

    }
}
