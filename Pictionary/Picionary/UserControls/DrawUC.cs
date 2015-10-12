using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Pictionary.UserControls
{
    public partial class DrawUC : UserControl
    {
        private Pen myPen;
        private Graphics g;
        private bool isDrawing = false;
        private Point lastPoint = new Point(-1, -1); 

        public DrawUC()
        {
            InitializeComponent();
        }

        public void setWord(string word)
        {
            drawLabel.Text = word;
        }
        public void setImage(byte[] bytesArray)
        {
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(bytesArray);
            this.paintPanel.BackgroundImage = img;
        }


        private void colorChooser_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.colorChooser.BackColor = dialog.Color;
                myPen.Color = dialog.Color;
            }
        }

        private void DrawUC_VisibleChanged(object sender, EventArgs e)
        {
            myPen = new Pen(this.colorChooser.BackColor, 4);
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            g = this.paintPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void paintPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void paintPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

            if (lastPoint.X == -1)
            {
                lastPoint = new Point(e.X, e.Y);
            }
        }

        private void paintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing == true)
            {
                g.DrawLine(myPen, lastPoint.X, lastPoint.Y, e.X, e.Y);
            }

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;

            ((MainForm) this.Parent).SendImage(new Bitmap(1055, 669, g));
        }

        private void clearBTN_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void sendText_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MainForm parentForm = (MainForm)this.Parent;
                chatBox.AppendText(parentForm.username + ": " +  sendText.Text);
                chatBox.AppendText(Environment.NewLine);

                parentForm.chatMessages.Add(new Tuple<string, string>(parentForm.username, sendText.Text));

                //Done
                sendText.Text = "";
                e.Handled = true;
            }
        }
    }
}
