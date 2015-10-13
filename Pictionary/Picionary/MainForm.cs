using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictionary
{
    public partial class MainForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public string username;
        public List<Tuple<string, string>> chatMessagesLocal, chatMessagesRecieved;
        public TcpConnection _connection;

        public MainForm()
        { 
            InitializeComponent();
            chatMessagesLocal = new List<Tuple<string, string>>();

            _connection = new TcpConnection(this);
        }

        public void SendUsername()
        {
            _connection.SendString("1|" + username + "|");   
        }

        public void repopulateChat()
        {
            drawUC2.newChat(this);
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            login2.Visible = true;
            pictureBox1.Visible = true;
            drawUC2.Visible = false;
        }


        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void setDrawUC()
        {
            login2.Visible = false;
            pictureBox1.Visible = false;
            drawUC2.Visible = true;                
        }

        public void setWord(string word)
        {
            drawUC2.setWord(word);
        }

        public void setImage(byte[] bytesArray)
        {
            drawUC2.setImage(bytesArray);
        }

        public void setConnectLBL()
        {
            login2.setConnectLBL();
        }

        public void SendImage(Bitmap bmp)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Close();

                byteArray = stream.ToArray();
            }
            _connection.SendImage("0|", byteArray, "|");
        }
    }
}
