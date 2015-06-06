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
namespace Project_1_1
{
    public partial class Comments : Form
    {
        private ComRepo comRepo = new ComRepo();
        private UserRepo userRepo = new UserRepo();
        private int id1;
        public Comments(int id)
        {

            InitializeComponent();
            id1 = id;
            Grid6.Rows.Clear();
            foreach (var item in comRepo.GetCommentsFromDB(id1))
            {

                int n = Grid6.Rows.Add();
                this.Grid6.Rows[n].Cells[0].Value = item.Date;
                this.Grid6.Rows[n].Cells[1].Value = userRepo.GetUserOnlyByID2(item.User_ID);
                this.Grid6.Rows[n].Cells[2].Value = item.Comment_Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComments_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    userRepo.GetUserByTaskID(id1);
                    DateTime now = DateTime.Now;
                    Comment1 com = new Comment1();
                    //Comment1 comm = new Comment1();
                    com.User_ID = Authentication.LoggedUser.User_ID;
                    com.Task_ID = id1;

                    com.Date = now;
                    com.Comment_Text = textBox1.Text;
                    comRepo.InsertComment(com);
                    textBox1.Clear();
                    Grid6.Rows.Clear();
                    foreach (var item in comRepo.GetCommentsFromDB(id1))
                    {

                        int n = Grid6.Rows.Add();
                        this.Grid6.Rows[n].Cells[0].Value = item.Date;
                        this.Grid6.Rows[n].Cells[1].Value = userRepo.GetUserOnlyByID2(item.User_ID);
                        this.Grid6.Rows[n].Cells[2].Value = item.Comment_Text;
                    }
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ComRepo comRepo = new ComRepo();
                Comment1 comm = new Comment1();
               // int id = Convert.ToInt32(Grid6.SelectedRows[0].Cells[0].Value);
               // string test  = Grid6.SelectedRows[0].Cells[1].Value.ToString();
              //  comm.Date = Convert.ToDateTime(Grid6.SelectedRows[0].Cells[0].Value);
                string test = Grid6.SelectedRows[0].Cells[2].Value.ToString();

               // MessageBox.Show(test);

                comRepo.DeleteComment(comm);
                Grid6.Rows.Clear();
                foreach (var item in comRepo.GetCommentsFromDB(id1))
                {

                    int n = Grid6.Rows.Add();
                    this.Grid6.Rows[n].Cells[0].Value = item.Date;
                    this.Grid6.Rows[n].Cells[1].Value = UserRepo.GetUserByyTaskID.Username;
                    this.Grid6.Rows[n].Cells[2].Value = item.Comment_Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
