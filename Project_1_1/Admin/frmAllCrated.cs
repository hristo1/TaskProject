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
namespace Project_1_1.Admin
{
    public partial class frmAllCrated : Form
    {
        private TaskRepo taskRepo = new TaskRepo();
        private UserRepo userRepo = new UserRepo();
        //private User user = new User();
        public frmAllCrated(User user)
        {
            InitializeComponent();
            

            userRepo.GetGiUserByID(user.User_ID);
            userRepo.GetResponsiveUserByID(user.User_ID);
           // userRepo.GetOnlyByID(user.User_ID);
             userRepo.GetUserOnlyByID(user);
             
             //this.user = user;
           // MessageBox.Show(user.User_ID.ToString());
            
            try
            {
                label1.Text += UserRepo.GetUserOnlyByyID.Username;
                foreach (var item in taskRepo.GetTaskFromDBCreated(user.User_ID))
                {
                    
                    //MessageBox.Show(userRepo.GetUserOnlyByID2(item.Task_Responsive_User_ID));
                    //Add in grid
                    int n = Grid3.Rows.Add();
                    this.Grid3.Rows[n].Cells[0].Value = item.Task_ID;
                    this.Grid3.Rows[n].Cells[1].Value = item.Task_Title;
                    this.Grid3.Rows[n].Cells[2].Value = userRepo.GetUserOnlyByID2(item.Task_Created_User_ID);
                    this.Grid3.Rows[n].Cells[3].Value = userRepo.GetUserOnlyByID2(item.Task_Responsive_User_ID);
                    //this.Grid3.Rows[n].Cells[2].Value = UserRepo.GetGiUser.Username;
                    //this.Grid3.Rows[n].Cells[3].Value = UserRepo.GetResponsiveUser.Username;
                    this.Grid3.Rows[n].Cells[4].Value = item.Task_Created_Date;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString()); 
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Grid3.SelectedRows[0].Cells[0].Value);
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

        private void frmAllCrated_Load(object sender, EventArgs e)
        {

        }

        private void Grid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
