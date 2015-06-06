using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using DataAccess;
using DataAccess.Service;
namespace Project_1_1.Admin
{
    public partial class frmAdminUsers : Form
    {
        public frmAdminUsers()
        {
            InitializeComponent();

            UserRepo userRepo = new UserRepo();

            if (Authentication.LoggedUser.User_Admin == true)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            foreach (var item in userRepo.GetAllUsers())
            {
                int n = Grid2.Rows.Add();
                this.Grid2.Rows[n].Cells[0].Value = item.User_ID;
                this.Grid2.Rows[n].Cells[1].Value = item.Username;
                this.Grid2.Rows[n].Cells[2].Value = item.User_Admin;

            }
        }

        private void frmAdminUsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepo userRepo = new UserRepo();
            User user = new User();

            frmAddUser test = new frmAddUser(user);

            if (test.ShowDialog() == DialogResult.OK)
            {
                
                userRepo.InsertUser(user);
            }
            Grid2.Rows.Clear();
            foreach (var item in userRepo.GetAllUsers())
            {
                int n = Grid2.Rows.Add();
                this.Grid2.Rows[n].Cells[0].Value = item.User_ID;
                this.Grid2.Rows[n].Cells[1].Value = item.Username;
                this.Grid2.Rows[n].Cells[2].Value = item.User_Admin;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserRepo userRepo = new UserRepo();
            int id = Convert.ToInt32(Grid2.SelectedRows[0].Cells[0].Value);
            user.User_ID = id;
            string username = Grid2.SelectedRows[0].Cells[1].Value.ToString();
           
            
            
            DialogResult result =  MessageBox.Show("Are you sure you want to delete user ",  username, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                userRepo.DeleteUser(user);
            }

            Grid2.Rows.Clear();
            foreach (var item in userRepo.GetAllUsers())
            {
                int n = Grid2.Rows.Add();
                this.Grid2.Rows[n].Cells[0].Value = item.User_ID;
                this.Grid2.Rows[n].Cells[1].Value = item.Username;
                this.Grid2.Rows[n].Cells[2].Value = item.User_Admin;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserRepo usrR = new UserRepo();

            int id = Convert.ToInt32(Grid2.SelectedRows[0].Cells[0].Value);
            user.User_ID = id;
            frmEdit frmE = new frmEdit(user);

            if (frmE.ShowDialog() == DialogResult.OK)
            {
               // MessageBox.Show("" + user.User_ID + " " + user.Username+ " " + user.Password +" ");
                usrR.EditUser(user);
            }
            Grid2.Rows.Clear();
            foreach (var item in usrR.GetAllUsers())
            {
                int n = Grid2.Rows.Add();
                this.Grid2.Rows[n].Cells[0].Value = item.User_ID;
                this.Grid2.Rows[n].Cells[1].Value = item.Username;
                this.Grid2.Rows[n].Cells[2].Value = item.User_Admin;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                int id = Convert.ToInt32(Grid2.SelectedRows[0].Cells[0].Value);
                user.User_ID = id;

                frmAllCrated frmCr = new frmAllCrated(user);

                if (frmCr.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception)
            {
               
            }
  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User user = new User();
            int id = Convert.ToInt32(Grid2.SelectedRows[0].Cells[0].Value);
            user.User_ID = id;

            frmAllResponsive frmAllRes = new frmAllResponsive(user);
            if (frmAllRes.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
