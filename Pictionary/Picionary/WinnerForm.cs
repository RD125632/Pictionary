using System;
using System.Windows.Forms;

namespace Pictionary
{
    public partial class WinnerForm : Form
    {
        public MainForm mainForm;
        public Tuple<string, string> message;

        public WinnerForm(MainForm mainForm, Tuple<string, string> chat)
        {
            this.mainForm = mainForm;
            this.message = chat;
            InitializeComponent();
        }


    }
}
