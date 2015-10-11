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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            
        }

        private void submitNameBTN_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            else
            {
                MainForm parentForm = (MainForm)this.Parent;
                parentForm.username = textBox1.Text;
                parentForm.setDrawUC();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                submitNameBTN_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
