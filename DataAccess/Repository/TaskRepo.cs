using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TaskRepo
    {


        public List<Task> GetTaskFromDBCrated(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var tasks = (from a in db.Users
                             join m in db.Tasks
                             on a.User_ID equals id
                             where a.User_ID == m.Task_Created_User_ID
                             //ToString where m.User_ID == id
                             select new
                             {
                                 Task_ID = m.Task_ID,
                                 Task_Title = m.Task_Title,
                                 Task_Text = m.Task_Text,
                                 Task_Responsive_User_ID = m.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = m.Task_Difficulty_Time,
                                 Task_Created_User_ID = m.Task_Created_User_ID,
                                 Task_Created_Date = m.Task_Created_Date,
                                 Task_Last_Edit_Date = m.Task_Last_Edit_Date,
                                 Task_Status = m.Task_Status,
                                 Task_TimeWorked = m.Task_TimeWorked

                             }).AsEnumerable().Select(x => new Task
                             {
                                 Task_ID = x.Task_ID,
                                 Task_Title = x.Task_Title,
                                 Task_Text = x.Task_Text,
                                 Task_Responsive_User_ID = x.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = x.Task_Difficulty_Time,
                                 Task_Created_User_ID = x.Task_Created_User_ID,
                                 Task_Created_Date = x.Task_Created_Date,
                                 Task_Last_Edit_Date = x.Task_Last_Edit_Date,
                                 Task_Status = x.Task_Status,
                                 Task_TimeWorked = x.Task_TimeWorked
                             });

                return tasks.ToList();
            }

        }
        /// ///////////////////////////

        public List<Task> GetTaskFromDB(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var tasks = (from a in db.Users
                             join m in db.Tasks
                             on a.User_ID equals id
                             where a.User_ID == m.Task_Responsive_User_ID
                             //ToString where m.User_ID == id
                             select new
                             {
                                 Task_ID = m.Task_ID,
                                 Task_Title = m.Task_Title,
                                 Task_Text = m.Task_Text,
                                 Task_Responsive_User_ID = m.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = m.Task_Difficulty_Time,
                                 Task_Created_User_ID = m.Task_Created_User_ID,
                                 Task_Created_Date = m.Task_Created_Date,
                                 Task_Last_Edit_Date = m.Task_Last_Edit_Date,
                                 Task_Status = m.Task_Status,
                                 Task_TimeWorked = m.Task_TimeWorked
                                 
                             }).AsEnumerable().Select(x => new Task
                             {
                                 Task_ID = x.Task_ID,
                                 Task_Title = x.Task_Title,
                                 Task_Text = x.Task_Text,
                                 Task_Responsive_User_ID = x.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = x.Task_Difficulty_Time,
                                 Task_Created_User_ID = x.Task_Created_User_ID,
                                 Task_Created_Date = x.Task_Created_Date,
                                 Task_Last_Edit_Date = x.Task_Last_Edit_Date,
                                 Task_Status = x.Task_Status,
                                 Task_TimeWorked = x.Task_TimeWorked
                             });

                return tasks.ToList();
            }

        }


        /// /////////////////////////////////
        public List<Task> GetTaskFromDBCreated(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var tasks = (from a in db.Users
                             join m in db.Tasks
                             on a.User_ID equals id
                             where a.User_ID == m.Task_Created_User_ID 
                             //ToString where m.User_ID == id
                             select new
                             {
                                 Task_ID = m.Task_ID,
                                 Task_Title = m.Task_Title,
                                 Task_Text = m.Task_Text,
                                 Task_Responsive_User_ID = m.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = m.Task_Difficulty_Time,
                                 Task_Created_User_ID = m.Task_Created_User_ID,
                                 Task_Created_Date = m.Task_Created_Date,
                                 Task_Last_Edit_Date = m.Task_Last_Edit_Date,
                                 Task_Status = m.Task_Status,
                                 Task_TimeWorked = m.Task_TimeWorked

                             }).AsEnumerable().Select(x => new Task
                             {
                                 Task_ID = x.Task_ID,
                                 Task_Title = x.Task_Title,
                                 Task_Text = x.Task_Text,
                                 Task_Responsive_User_ID = x.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = x.Task_Difficulty_Time,
                                 Task_Created_User_ID = x.Task_Created_User_ID,
                                 Task_Created_Date = x.Task_Created_Date,
                                 Task_Last_Edit_Date = x.Task_Last_Edit_Date,
                                 Task_Status = x.Task_Status,
                                 Task_TimeWorked = x.Task_TimeWorked
                             }).ToList();
              
                return tasks.ToList();
            }

        }
        //////////////////////////////////////
        public Task GetTask(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var tasks = (from m in db.Tasks
                             where m.Task_ID == id
                             select new
                             {
                                 Task_ID = m.Task_ID,
                                 Task_Title = m.Task_Title,
                                 Task_Text = m.Task_Text,
                                 Task_Responsive_User_ID = m.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = m.Task_Difficulty_Time,
                                 Task_Created_User_ID = m.Task_Created_User_ID,
                                 Task_Created_Date = m.Task_Created_Date,
                                 Task_Last_Edit_Date = m.Task_Last_Edit_Date,
                                 Task_Status = m.Task_Status,
                                 Task_TimeWorked = m.Task_TimeWorked
                             }).AsEnumerable().Select(x => new Task
                             {
                                 Task_ID = x.Task_ID,
                                 Task_Title = x.Task_Title,
                                 Task_Text = x.Task_Text,
                                 Task_Responsive_User_ID = x.Task_Responsive_User_ID,
                                 Task_Difficulty_Time = x.Task_Difficulty_Time,
                                 Task_Created_User_ID = x.Task_Created_User_ID,
                                 Task_Created_Date = x.Task_Created_Date,
                                 Task_Last_Edit_Date = x.Task_Last_Edit_Date,
                                 Task_Status = x.Task_Status,
                                 Task_TimeWorked = x.Task_TimeWorked
                             }).FirstOrDefault();
                return tasks;
            }
        }

        public void InsertTask(Task item)
        {
            DBEntities db = new DBEntities();
            using (db)
            {
                db.Tasks.Add(item);
                db.SaveChanges();
            }
        }
        public void DeleteTask(Task item)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var x = (from y in db.Tasks
                             where y.Task_ID == item.Task_ID
                             select y).FirstOrDefault();
                    db.Tasks.Remove(x);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }
        public void EditTask(Task item)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var x = (from y in db.Tasks
                             where y.Task_ID == item.Task_ID
                             select y).FirstOrDefault();
                    if (x == null)
                        return;

                    x.Task_Title = item.Task_Title;
                    x.Task_Text = item.Task_Text;
                    x.Task_Difficulty_Time = item.Task_Difficulty_Time;
                    x.Task_Responsive_User_ID = item.Task_Responsive_User_ID;
                    x.Task_Created_User_ID = item.Task_Created_User_ID;
                    x.Task_Last_Edit_Date = item.Task_Last_Edit_Date;
                    x.Task_TimeWorked = item.Task_TimeWorked;
                    x.Task_Status = item.Task_Status;
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
