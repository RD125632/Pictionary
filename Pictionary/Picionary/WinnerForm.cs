using System;
using System.Windows.Forms;

namespace Pictionary
{
    public partial class WinnerForm : Form
    {
        public MainForm mainForm;
        public Tuple<string, string> message;

        public WinnerForm(Tuple<string, string> chat)
        {
            mainForm = (MainForm)Application.OpenForms["MainForm"];
            this.message = chat;
            InitializeComponent();
        }


    }
}
