using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace DataAccess.Repository
{
    public class ComRepo
    {
        public void DeleteComment(Comment1 item)
        {
            try
            {
                using (DBEntities db = new DBEntities())
                {
                    var x = (from y in db.Comment1
                             where y.Comment_Text == item.Comment_Text
                             select y).FirstOrDefault();
                    db.Comment1.Remove(x);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }
        public void InsertComment(Comment1 item)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Comment1.Add(item);
                
                db.SaveChanges();
            }
        }
        public List<Comment1> GetCommentsFromDB(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var comments = (from t in db.Tasks
                                join c in db.Comment1
                                on t.Task_ID equals id
                                where t.Task_ID == c.Task_ID
                             select new
                             {
                                 
                                 Comment_ID = c.Comment_ID,
                                 Comment_Text = c.Comment_Text,
                                 Task_ID = c.Task_ID,
                                 User_ID = c.User_ID,
                                  Date = c.Date,

                             }).AsEnumerable().Select(x => new Comment1
                             {
                                 Comment_ID = x.Comment_ID,
                                 Date = x.Date,
                                 Comment_Text = x.Comment_Text,
                                 Task_ID = x.Task_ID,
                                 User_ID = x.User_ID
                             });
                return comments.ToList();
            }

        }
    }
}
