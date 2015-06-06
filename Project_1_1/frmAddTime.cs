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
namespace Project_1_1
{
    public partial class frmAddTime : Form
    {
        private DataAccess.Task task;
        private TaskRepo taskRepo = new TaskRepo();
        public frmAddTime(DataAccess.Task task)
        {
            InitializeComponent();

            this.task = task;
            task = taskRepo.GetTask(task.Task_ID);

            label1.Text = task.Task_Title;
            richTextBox1.Text = task.Task_Text;
            label4.Text = task.Task_TimeWorked.ToString();
            richTextBox1.Text = task.Task_Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            //userRepo.GetUserByNameM(comboBox2.Text);

            task.Task_Title = label1.Text;
            task.Task_Text = richTextBox1.Text;
            task.Task_Difficulty_Time = Convert.ToInt32(comboBox1.Text);
           // task.Task_Responsive_User_ID = userRepo.GetUserByName.User_ID;
            //task.Task_Created_User_ID = Authentication.LoggedUser.User_ID;
            task.Task_Last_Edit_Date = now;
            task.Task_TimeWorked += 2;
            this.DialogResult = DialogResult.OK;
        }

        private void frmAddTime_Load(object sender, EventArgs e)
        {

        }
    }
}
