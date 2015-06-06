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
using DataAccess.Repository;
namespace Project_1_1.Admin
{
    public partial class frmAllResponsive : Form
    {
        TaskRepo taskRepo = new TaskRepo();
        UserRepo userRepo = new UserRepo();
        public frmAllResponsive(User user)
        {
            InitializeComponent();
            try
            {
                userRepo.GetGiUserByID(user.User_ID);
                userRepo.GetResponsiveUserByID(user.User_ID);
              
                userRepo.GetUserOnlyByID(user);
                label1.Text += UserRepo.GetUserOnlyByyID.Username;
                User userTest = new User();
                foreach (var item in taskRepo.GetTaskFromDB(user.User_ID))
                {
                    //Add in grid
                    //this.Grid3.Rows[n].Cells[2].Value = userRepo.GetUserOnlyByID2(item.Task_Created_User_ID);
                    //this.Grid3.Rows[n].Cells[3].Value = userRepo.GetUserOnlyByID2(item.Task_Responsive_User_ID);
                    int n = Grid4.Rows.Add();
                    this.Grid4.Rows[n].Cells[0].Value = item.Task_ID;
                    this.Grid4.Rows[n].Cells[1].Value = item.Task_Title;
                    this.Grid4.Rows[n].Cells[2].Value = userRepo.GetUserOnlyByID2(item.Task_Created_User_ID);
                    this.Grid4.Rows[n].Cells[3].Value = item.Task_Difficulty_Time;
                    this.Grid4.Rows[n].Cells[4].Value = item.Task_Created_Date;
                }

            }
            catch (Exception)
            {
                
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Grid4.SelectedRows[0].Cells[0].Value);
            if (id < 1)
                return;
            else
            {
                frmTaskView frmT = new frmTaskView(id);

                if (frmT.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void frmAllResponsive_Load(object sender, EventArgs e)
        {

        }

        private void Grid4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
