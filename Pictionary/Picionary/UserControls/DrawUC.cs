using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Pictionary.UserControls
{
    public partial class DrawUC : UserControl
    {
        private Pen myPen;
        private Graphics g;
        private bool isDrawing = false;
        private Point lastPoint = new Point(-1, -1);
        public List<ImagePoint> pixelPainted;
        private MainForm parentForm;

        public DrawUC(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            pixelPainted = new List<ImagePoint>();
        }

        public void setWord(string word)
        {
            drawLabel.Text = word;
        }

        public string GetWord()
        {
            return drawLabel.Text;
        }


        public void newChat()
        {
                chatBox.AppendText(parentForm.chatMessagesLocal.Last().Item1 + ": " + parentForm.chatMessagesLocal.Last().Item2);
                chatBox.AppendText(Environment.NewLine);
        }

        public void setImage()
        {
            myPen.Color = pixelPainted.Last().color;
            g.DrawLine(myPen, pixelPainted.Last().p1, pixelPainted.Last().p2);
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
            if (((MainForm)this.Parent)._connection.isActiveClient == true)
            {
                isDrawing = true;

                if (lastPoint.X == -1)
                {
                    lastPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void paintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing == true)
            {
                ImagePoint newPoint = new ImagePoint(new Point(lastPoint.X, lastPoint.Y), new Point(e.X, e.Y), myPen.Color);
                parentForm.SendImage(newPoint);
            }

            lastPoint.X = e.X;
            lastPoint.Y = e.Y; 
        }

        private void clearBTN_Click(object sender, EventArgs e)
        {
            if (parentForm._connection.isActiveClient == true)
            { 
                clearImage();
                parentForm._connection.SendString("6|");
            }
        }

        public void clearImage()
        {
            pixelPainted.Clear();
            g.Clear(Color.White);
        }

        private void sendText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                parentForm._connection.SendString("2|" + sendText.Text + "|");

                //Done
                sendText.Text = "";
                e.Handled = true;
            }
        }
        
    }
}
