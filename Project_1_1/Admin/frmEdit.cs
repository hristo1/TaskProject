using DataAccess;
using DataAccess.Repository;
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
    public partial class frmEdit : Form
    {
        private User user  = new User();
        private UserRepo userRepo = new UserRepo();
        public frmEdit(User user)
        {
            InitializeComponent();

            this.user = user;
            userRepo.GetUsersByID(user);

            try
            {
               
                textBox1.Text = UserRepo.GetUserByID.Username;
                textBox2.Text = UserRepo.GetUserByID.Password;
                if (UserRepo.GetUserByID.User_Admin == true)
                {
                    checkBox1.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Something get wrong");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                user.Username = textBox1.Text;
                user.Password = textBox2.Text;
                if (checkBox1.Checked == true)
                {
                    user.User_Admin = true;             
                }
                else
                {
                    user.User_Admin = false;      
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Empty field");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
