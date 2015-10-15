using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictionary.UserControls
{
    public partial class Winner : UserControl
    {
        private WinnerForm winnerForm;
        public Winner(Tuple<string, string> answer, WinnerForm winnerForm)
        {
            this.winnerForm = winnerForm;
            InitializeComponent();
            nameLBL.Text = answer.Item1;
            sswLBL.Text = answer.Item2;
        }

        private void nxtWord_Click(object sender, EventArgs e)
        {
            winnerForm.mainForm.resetGame();
            winnerForm.Dispose();
        }
    }
}
