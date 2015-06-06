using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Service;

namespace Project_1_1
{
    public partial class frmMain : Form
    {
        
        private UserRepo usrRepo = new UserRepo();
        public frmMain()
        {
            InitializeComponent();
            toolStripStatusLabel2.Text = Authentication.LoggedUser.Username;
            if (Authentication.LoggedUser.User_Admin == true)
            {
                toolStripStatusLabel4.Text = "admin";
                menuStrip1.Visible = true;

            }
            else
            {
                toolStripStatusLabel4.Text = "user";
            }

            TaskRepo taskRepoTest = new TaskRepo();

            //MessageBox.Show(Authentication.LoggedUser.User_ID.ToString());
            label1.Text += " " + Authentication.LoggedUser.Username;
            foreach (var item in taskRepoTest.GetTaskFromDB(Authentication.LoggedUser.User_ID))
            {

                int n = Grid1.Rows.Add();
                this.Grid1.Rows[n].Cells[0].Value = item.Task_ID;
                this.Grid1.Rows[n].Cells[1].Value = item.Task_Title;
                this.Grid1.Rows[n].Cells[2].Value = item.Task_Difficulty_Time;
                this.Grid1.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                this.Grid1.Rows[n].Cells[4].Value = item.Task_Created_Date;
                this.Grid1.Rows[n].Cells[5].Value = item.Task_Status;
            }

            foreach (var item in taskRepoTest.GetTaskFromDBCreated(Authentication.LoggedUser.User_ID))
            {
                usrRepo.GetResponsiveUserByID(item.Task_Responsive_User_ID);
                int n = Grid5.Rows.Add();
                this.Grid5.Rows[n].Cells[0].Value = item.Task_ID;
                this.Grid5.Rows[n].Cells[1].Value = item.Task_Title;
                this.Grid5.Rows[n].Cells[2].Value = UserRepo.GetResponsiveUser.Username;
                this.Grid5.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                this.Grid5.Rows[n].Cells[4].Value = item.Task_Created_Date;
                this.Grid5.Rows[n].Cells[5].Value = item.Task_Status;
            }

            Grid5.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Grid1.SelectedRows[0].Cells[0].Value);
                if (id < 1)
                    return;
                else
                {
                    frmTaskView frmT = new frmTaskView(id);
                    if (frmT.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            Grid1.Rows.Clear();
                            TaskRepo taskRepo = new TaskRepo();
                            foreach (var item in taskRepo.GetTaskFromDB(Authentication.LoggedUser.User_ID))
                            {

                                int n = Grid1.Rows.Add();
                                this.Grid1.Rows[n].Cells[0].Value = item.Task_ID;
                                this.Grid1.Rows[n].Cells[1].Value = item.Task_Title;
                                this.Grid1.Rows[n].Cells[2].Value = item.Task_Difficulty_Time;
                                this.Grid1.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                                this.Grid1.Rows[n].Cells[4].Value = item.Task_Created_Date;
                                this.Grid1.Rows[n].Cells[5].Value = item.Task_Status;
                            }
                            Grid5.Rows.Clear();
                            foreach (var item in taskRepo.GetTaskFromDBCreated(Authentication.LoggedUser.User_ID))
                            {
                                usrRepo.GetResponsiveUserByID(item.Task_Responsive_User_ID);

                                int n = Grid5.Rows.Add();
                                this.Grid5.Rows[n].Cells[0].Value = item.Task_ID;
                                this.Grid5.Rows[n].Cells[1].Value = item.Task_Title;
                                this.Grid5.Rows[n].Cells[2].Value = UserRepo.GetResponsiveUser.Username;
                                this.Grid5.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                                this.Grid5.Rows[n].Cells[4].Value = item.Task_Created_Date;
                                this.Grid5.Rows[n].Cells[5].Value = item.Task_Status;
                            }
                            Grid5.ClearSelection();
                            return;
                        }
                        catch (Exception) { MessageBox.Show("Ooops, Error!!!"); }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ooops, Error!!!");
            }
            try
            {
                int id = Convert.ToInt32(Grid5.SelectedRows[0].Cells[0].Value);
                if (id < 1)
                    return;
                else
                {
                    frmTaskView frmT = new frmTaskView(id);

                    if (frmT.ShowDialog() == DialogResult.OK)
                    {
                        Grid1.Rows.Clear();
                        TaskRepo taskRepo = new TaskRepo();
                        foreach (var item in taskRepo.GetTaskFromDB(Authentication.LoggedUser.User_ID))
                        {

                            int n = Grid1.Rows.Add();
                            this.Grid1.Rows[n].Cells[0].Value = item.Task_ID;
                            this.Grid1.Rows[n].Cells[1].Value = item.Task_Title;
                            this.Grid1.Rows[n].Cells[2].Value = item.Task_Difficulty_Time;
                            this.Grid1.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                            this.Grid1.Rows[n].Cells[4].Value = item.Task_Created_Date;
                            this.Grid1.Rows[n].Cells[5].Value = item.Task_Status;
                        }
                        Grid5.Rows.Clear();
                        foreach (var item in taskRepo.GetTaskFromDBCreated(Authentication.LoggedUser.User_ID))
                        {
                            usrRepo.GetResponsiveUserByID(item.Task_Responsive_User_ID);

                            int n = Grid5.Rows.Add();
                            this.Grid5.Rows[n].Cells[0].Value = item.Task_ID;
                            this.Grid5.Rows[n].Cells[1].Value = item.Task_Title;
                            this.Grid5.Rows[n].Cells[2].Value = UserRepo.GetResponsiveUser.Username;
                            this.Grid5.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                            this.Grid5.Rows[n].Cells[4].Value = item.Task_Created_Date;
                            this.Grid5.Rows[n].Cells[5].Value = item.Task_Status;
                        }

                        Grid5.ClearSelection();
                    }
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ooops, Error!!!");
            }

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            DataAccess.Task task = new DataAccess.Task();
            frmAddTask test = new frmAddTask(task);

            if (test.ShowDialog() == DialogResult.OK)
            {
                TaskRepo taskRepo = new TaskRepo();

                taskRepo.InsertTask(task);

                Grid1.Rows.Clear();

                foreach (var item in taskRepo.GetTaskFromDB(Authentication.LoggedUser.User_ID))
                {
                    //Add in grid
                    int n = Grid1.Rows.Add();
                    this.Grid1.Rows[n].Cells[0].Value = item.Task_ID;
                    this.Grid1.Rows[n].Cells[1].Value = item.Task_Title;
                    this.Grid1.Rows[n].Cells[2].Value = item.Task_Difficulty_Time;
                    this.Grid1.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                    this.Grid1.Rows[n].Cells[4].Value = item.Task_Created_Date;
                    this.Grid1.Rows[n].Cells[5].Value = item.Task_Status;
                }
                Grid5.Rows.Clear();
                foreach (var item in taskRepo.GetTaskFromDBCreated(Authentication.LoggedUser.User_ID))
                {
                    usrRepo.GetResponsiveUserByID(item.Task_Responsive_User_ID);

                    int n = Grid5.Rows.Add();
                    this.Grid5.Rows[n].Cells[0].Value = item.Task_ID;
                    this.Grid5.Rows[n].Cells[1].Value = item.Task_Title;
                    this.Grid5.Rows[n].Cells[2].Value = UserRepo.GetResponsiveUser.Username;
                    this.Grid5.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                    this.Grid5.Rows[n].Cells[4].Value = item.Task_Created_Date;
                    this.Grid5.Rows[n].Cells[5].Value = item.Task_Status;
                }

                Grid5.ClearSelection();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void viewAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.frmAdminUsers aUsers = new Admin.frmAdminUsers();

            if (aUsers.ShowDialog() == DialogResult.OK)
            {
                TaskRepo taskRepo = new TaskRepo();

                Grid1.Rows.Clear();

                foreach (var item in taskRepo.GetTaskFromDB(Authentication.LoggedUser.User_ID))
                {
                    //Add in grid
                    int n = Grid1.Rows.Add();
                    this.Grid1.Rows[n].Cells[0].Value = item.Task_ID;
                    this.Grid1.Rows[n].Cells[1].Value = item.Task_Title;
                    this.Grid1.Rows[n].Cells[2].Value = item.Task_Difficulty_Time;
                    this.Grid1.Rows[n].Cells[3].Value = item.Task_TimeWorked;
                }
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin log = new frmLogin();
            frmMain main = new frmMain();
            log.Show();


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Grid5.ClearSelection();
        }
        private void Grid1_Click(object sender, EventArgs e)
        {
            Grid5.ClearSelection();
        }

        private void Grid5_Click(object sender, EventArgs e)
        {
            Grid1.ClearSelection();
        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Grid1.SelectedRows[0].Cells[0].Value);
                if (id < 1)
                    return;
                else
                {
                    frmTaskView frmT = new frmTaskView(id);

                    if (frmT.ShowDialog() == DialogResult.OK)
                    {
                        //frmT.Show();
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Ooops, Error!!!"); }
        }

        private void Grid5_Click_1(object sender, EventArgs e)
        {
            Grid1.ClearSelection();
        }

        private void Grid5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Grid5.SelectedRows[0].Cells[0].Value);
                if (id < 1)
                    return;
                else
                {
                    frmTaskView frmT = new frmTaskView(id);

                    if (frmT.ShowDialog() == DialogResult.OK)
                    {
                      //  frmT.Show();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ooops, Error!!!" + ex.ToString()); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Grid1.SelectedRows[0].Cells[0].Value);
                if (id < 1)
                    return;
                else
                {
                    DataAccess.Task task = new DataAccess.Task();
                    task.Task_ID = id;
                    frmAddTime addTime = new frmAddTime(task);
                    if (addTime.ShowDialog() == DialogResult.OK)
                    {
                        TaskRepo taskRepo = new TaskRepo();
                        taskRepo.EditTask(task);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void viewAllUsersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.frmAdminUsers info = new Admin.frmAdminUsers();
            if (info.ShowDialog() == DialogResult.OK)
            {

            }
           // info.Show();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
         

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult dialog = MessageBox.Show(this, "Good bye "+toolStripStatusLabel2.Text+"", "Logging out...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                frmLogin log = new frmLogin();
                this.Hide();
                log.Show();
            }
        }
        
        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
