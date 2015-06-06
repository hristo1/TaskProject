using DataAccess.Repository;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_1
{
    public partial class frmEditTask : Form
    {
        private DataAccess.Task task;
        private TaskRepo taskRepo = new TaskRepo();
        private UserRepo userRepo = new UserRepo();

        public frmEditTask(DataAccess.Task task)
        {
            InitializeComponent();

            this.task = task;
            foreach (var item in userRepo.GetAllUsers())
            {

                comboBox2.Items.Add(item.Username);
            }

            try
            {
                userRepo.GetGiUserByID(task.Task_Responsive_User_ID);

                textBox1.Text = task.Task_Title;
                richTextBox1.Text = task.Task_Text;
                comboBox1.SelectedIndex = task.Task_Difficulty_Time - 1;
                comboBox2.SelectedIndex = comboBox2.FindString(UserRepo.GetGiUser.Username);
            }
            catch (Exception)
            {
                MessageBox.Show("No task");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && richTextBox1.Text != "" && comboBox2.SelectedIndex > -1)
            {
                DateTime now = DateTime.Now;
                userRepo.GetUserByNameM(comboBox2.Text);

                task.Task_Title = textBox1.Text;
                task.Task_Text = richTextBox1.Text;
                task.Task_Difficulty_Time = Convert.ToInt32(comboBox1.Text);
                task.Task_Responsive_User_ID = userRepo.GetUserByName.User_ID;
                task.Task_Created_User_ID = Authentication.LoggedUser.User_ID;
                task.Task_Last_Edit_Date = now;
                this.DialogResult = DialogResult.OK;


            }
            else
            {
                MessageBox.Show("Empty field");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = -1;
            
        }

        private void frmEditTask_Load(object sender, EventArgs e)
        {

        }
    }
}
