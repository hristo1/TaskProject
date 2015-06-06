using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_1.Admin
{
    public partial class frmAddUser : Form
    {
        private User user;
        public frmAddUser(User user)
        {
            this.user = user;
            InitializeComponent();
            textBox1.Text = user.Username;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            user.Username = textBox1.Text;
            user.Password = textBox2.Text;
            if ( checkBox1.Checked == true)
            {
                user.User_Admin = true;
            }
            

            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
