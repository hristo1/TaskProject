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
    public partial class frmAddTask : Form
    {
        private DataAccess.Task task = new DataAccess.Task();
        private TaskRepo taskRepo = new TaskRepo();
        private UserRepo userRepo = new UserRepo();

        public frmAddTask(DataAccess.Task task)
        {
            InitializeComponent();

            this.task = task;
            foreach (var item in userRepo.GetAllUsers())
            {

                comboBox2.Items.Add(item.Username);
            }

        }

        private void button1_Click(object sender, EventArgs e)      
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
                task.Task_Created_Date = now;

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

        private void frmAddTask_Load(object sender, EventArgs e)
        {

        }
    }
}
