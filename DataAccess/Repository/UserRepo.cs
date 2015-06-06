using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
     public class UserRepo
    {
        DBEntities db = new DBEntities();

        public static User GetUserByID { get; private set; }
       
         public void GetUsersByID(User id)
        {
            User usr = new User();
            using (db)
            {
                var results = (from c in db.Users
                               where c.User_ID == id.User_ID
                               select c).FirstOrDefault();
                if (results == null)
                    return;

                usr.User_ID = results.User_ID;
                usr.Username = results.Username;
                usr.Password = results.Password;
                usr.User_Admin = results.User_Admin;
                GetUserByID = usr;
            }
        }

        public User GetUser(User item)
        {

            using (db)
            {
                var results = (from c in db.Users
                               where c.User_ID == item.User_ID
                               select c).FirstOrDefault();
                return results;
            }
        }

        public void InsertUser(User item)
        {
            using (db)
            {
                db.Users.Add(item);
                db.SaveChanges();
            }
        }

        public void DeleteUser(User item)
        {
            try
            {
                using (db)
                {
                    var x = (from y in db.Users
                             where y.User_ID == item.User_ID
                             select y).FirstOrDefault();
                    db.Users.Remove(x);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        public void EditUser(User item)
        {
            try
            {
                using (db)
                {
                    var x = (from y in db.Users
                             where y.User_ID == item.User_ID
                             select y).FirstOrDefault();
                    x.Username = item.Username;
                    x.Password = item.Password;
                    x.User_Admin = item.User_Admin;
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {

            }
        }
        public static User GetGiUser { get; private set; }

        public void GetGiUserByID(int id)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             join ts in db.Tasks
                             on p.User_ID equals ts.Task_Created_User_ID
                             where ts.Task_ID == id
                             select p).FirstOrDefault();
                if (query == null)
                    return;

                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                GetGiUser = usr;

            }
        }

        ///////////////////////////////////////////////////////////////

        public static User GetResponsiveUser { get; private set; }

        public void GetResponsiveUserByID(int id)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             join ts in db.Tasks
                             on p.User_ID equals ts.Task_Responsive_User_ID
                             where ts.Task_Responsive_User_ID == id
                             select p).FirstOrDefault();
                if (query == null)
                    return;

                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                GetResponsiveUser = usr;
                
            }
        }


        public List<User> GetAllUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                var users = (from u in db.Users
                             select new
                             {
                                 User_ID = u.User_ID,
                                 Password = u.Password,
                                 Username = u.Username,
                                 User_Admin = u.User_Admin
                             }).AsEnumerable().Select(x => new User
                             {
                                 User_ID = x.User_ID,
                                 Password = x.Password,
                                 Username = x.Username,
                                 User_Admin = x.User_Admin

                             });

                return users.ToList();

            }

        }




        public User GetUserByName { get; private set; }


        public void GetUserByNameM(string username)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             where p.Username == username
                             select p).FirstOrDefault();
                if (query == null)
                    return;

                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                GetUserByName = usr;

            }
        }


        public static User GetUserOnlyByyID { get; private set; }

        public void GetUserOnlyByID(User id)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             where p.User_ID == id.User_ID
                             select p).FirstOrDefault();
                if (query == null)
                    return;
                
                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                GetUserOnlyByyID = usr;

            }
        }

        public static User GetUserByyTaskID { get; private set; }

        public void GetUserByTaskID(int id)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             join ts in db.Tasks
                             on p.User_ID equals ts.Task_Responsive_User_ID
                             where ts.Task_ID == id
                             select p).FirstOrDefault();
                if (query == null)
                    return;


                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                GetUserByyTaskID = usr;

            }
        }
        public string GetUserOnlyByID2(int id)
        {
            User usr = new User();
            using (DBEntities db = new DBEntities())
            {
                var query = (from p in db.Users
                             where p.User_ID == id
                             select p).FirstOrDefault();
                //if (query == null)
                //    return ;

                usr.Username = query.Username;
                usr.Password = query.Password;
                usr.User_Admin = query.User_Admin;
                usr.User_ID = query.User_ID;

                return usr.Username;

            }
        }
    }
}
