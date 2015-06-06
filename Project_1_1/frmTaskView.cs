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
    public partial class frmTaskView : Form
    {
        private int a1;
        private DataAccess.Task task;
        private TaskRepo taskRepo = new TaskRepo();
        private UserRepo userRepo = new UserRepo();
        private int a;
        public frmTaskView(int id)
        {
            InitializeComponent();

            a1 = id;
           
           userRepo.GetGiUserByID(id);
           // userRepo.GetResponsiveUserByID(id);

            task = taskRepo.GetTask(id);
            try
            {
                userRepo.GetUserByTaskID(id);
                a = id;
                labelTitle.Text = task.Task_Title;
                richTextBox1.Text = task.Task_Text;
                labelGiveUser.Text = UserRepo.GetGiUser.Username;
                labelResUser.Text = " Username: " + UserRepo.GetUserByyTaskID.Username;
                labelTime.Text = task.Task_Difficulty_Time.ToString();
                // Add worked time
                labelTimeWorked.Text = task.Task_TimeWorked.ToString();
                labelDateCr.Text = task.Task_Created_Date.ToString();
                labelDateLastUp.Text = task.Task_Last_Edit_Date.ToString();
                //MessageBox.Show(task.Task_Status.ToString());
                if (task.Task_Status == true)
                {
                    label10.Text = "Complete";
                }
                if (task.Task_Status == false)
                {
                    label10.Text = "In progres";
                }
                checkBox1.Checked = task.Task_Status;


               if (Authentication.LoggedUser.User_Admin == true || task.Task_Created_User_ID == Authentication.LoggedUser.User_ID)
               {
                   button3.Visible = true;
                    button2.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No task");
            }

        }
        public void button2_Click(object sender, EventArgs e)
        {
            TaskRepo raskR = new TaskRepo();
            frmEditTask frmEdit = new frmEditTask(task);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                raskR.EditTask(task);

                userRepo.GetGiUserByID(a);
                userRepo.GetResponsiveUserByID(a);
                task = taskRepo.GetTask(a);
                try
                {
                    labelTitle.Text = task.Task_Title;
                    richTextBox1.Text = task.Task_Text;
                    labelGiveUser.Text = UserRepo.GetGiUser.Username;
                    labelResUser.Text = UserRepo.GetResponsiveUser.Username;
                    labelTime.Text = task.Task_Difficulty_Time.ToString();
                    // Add worked time
                    labelTimeWorked.Text = "0";
                    labelDateCr.Text = task.Task_Created_Date.ToString();
                    labelDateLastUp.Text = task.Task_Last_Edit_Date.ToString();


                    if (Authentication.LoggedUser.User_Admin == true || task.Task_Created_User_ID == UserRepo.GetResponsiveUser.User_ID)
                    {
                        button2.Visible = true;
                        button3.Visible = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No task");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmTaskView_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  int selectedrowindex = Grid1.SelectedCells[0].RowIndex;
          //  DataGridViewRow selectedRow = Grid1.Rows[selectedrowindex];

           // int a = Convert.ToInt32(selectedRow.Cells[0].Value);

            DataAccess.Task task = new DataAccess.Task();
            task.Task_ID = a1;

            DialogResult result = MessageBox.Show("Are you sure","Deleteing user", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TaskRepo taskRepo = new TaskRepo();
                taskRepo.DeleteTask(task);
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Comment1 com = new Comment1();
            ComRepo comRepo = new ComRepo();

            Comments frmCom = new Comments(task.Task_ID);
            if (frmCom.ShowDialog() == DialogResult.OK)
            {
                comRepo.InsertComment(com);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                task = taskRepo.GetTask(a);
                //MessageBox.Show("Add time " + task.Task_TimeWorked.ToString() + "");
                task.Task_TimeWorked += Convert.ToInt32(comboBox1.Text);
                DateTime now = DateTime.Now;
                task.Task_Last_Edit_Date = now;
                taskRepo.EditTask(task);

                userRepo.GetGiUserByID(a1);
                // userRepo.GetResponsiveUserByID(id);

                task = taskRepo.GetTask(a1);
                try
                {
                    userRepo.GetUserByTaskID(a1);
                  //  a = id1;
                    labelTitle.Text = task.Task_Title;
                    richTextBox1.Text = task.Task_Text;
                    labelGiveUser.Text = UserRepo.GetGiUser.Username;
                    labelResUser.Text = UserRepo.GetUserByyTaskID.Username;
                    labelTime.Text = task.Task_Difficulty_Time.ToString();
                    // Add worked time
                    labelTimeWorked.Text = task.Task_TimeWorked.ToString();
                    labelDateCr.Text = task.Task_Created_Date.ToString();
                    labelDateLastUp.Text = task.Task_Last_Edit_Date.ToString();
                    if (task.Task_Status == true)
                    {
                        label10.Text = "Complete";
                    }
                    if (task.Task_Status == false)
                    {
                        label10.Text = "In progres";
                    }


                    if (Authentication.LoggedUser.User_Admin == true || task.Task_Created_User_ID == Authentication.LoggedUser.User_ID)
                    {
                        button3.Visible = true;
                        button2.Visible = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No task");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ooops, Error!!!");
            }
      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        bool isIt = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (isIt == false)
            {
                Comments frmCom = new Comments(task.Task_ID);
                if (frmCom.ShowDialog() == DialogResult.OK)
                {
                    DataAccess.Task task1 = new DataAccess.Task();
                    task1 = taskRepo.GetTask(a1);
                    if (checkBox1.Checked == true)
                    {
                        task1.Task_Status = true;
                        taskRepo.EditTask(task1);
                        // checkBox1.Checked == true;
                    }
                    else
                    {
                        task1.Task_Status = false;
                        taskRepo.EditTask(task1);
                    }
                    //MessageBox.Show(task1.Task_Status.ToString());
                    task = taskRepo.GetTask(a1);
                    try
                    {
                        userRepo.GetUserByTaskID(a1);
                        a = a1;
                        labelTitle.Text = task.Task_Title;
                        richTextBox1.Text = task.Task_Text;
                        labelGiveUser.Text = UserRepo.GetGiUser.Username;
                        labelResUser.Text = UserRepo.GetUserByyTaskID.Username;
                        labelTime.Text = task.Task_Difficulty_Time.ToString();
                        // Add worked time
                        labelTimeWorked.Text = task.Task_TimeWorked.ToString();
                        labelDateCr.Text = task.Task_Created_Date.ToString();
                        labelDateLastUp.Text = task.Task_Last_Edit_Date.ToString();
                        //MessageBox.Show(task.Task_Status.ToString());
                        if (task.Task_Status == true)
                        {
                            label10.Text = "Complete";
                        }
                        if (task.Task_Status == false)
                        {
                            label10.Text = "In progres";
                        }

                        if (Authentication.LoggedUser.User_Admin == true || task.Task_Created_User_ID == Authentication.LoggedUser.User_ID)
                        {
                            button3.Visible = true;
                            button2.Visible = true;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No task");
                    }
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        isIt = true;
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        isIt = true;
                        checkBox1.Checked = true;
                    }
                    
                    return;
                }
                
            }
            isIt = false;

        }

        private void frmTaskView_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
