using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Service;

namespace Project_1_1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Authentication.LoggedUser = null;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Empty username or password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string username = textBox1.Text;
            string password = textBox2.Text;
           
            Authentication.AuthenticateUser(username, password);


            if (Authentication.LoggedUser !=null && Authentication.LoggedUser.Username == "NODBFOUND")
                {
                    MessageBox.Show("Oops, there is no Database", "We have a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

           
            if (Authentication.LoggedUser != null)
            {
               // MessageBox.Show(Authentication.LoggedUser.Username);
                this.DialogResult = DialogResult.OK;
                frmMain main = new frmMain();
                this.Hide();
                main.Show();
                
            }
            else
            {
                textBox2.Clear();
                MessageBox.Show("Invalid username or password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
    
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter )
            {
               button1_Click_1(sender, e);
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           System.Windows.Forms.Application.Exit();
        }
    }
}
