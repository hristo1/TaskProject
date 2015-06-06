using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public static class Authentication
    {
        public static User LoggedUser { get;  set; }

        public static void AuthenticateUser(string username, string password)
        {
            User usr = new User();
            try
            {
                
                using (DBEntities db = new DBEntities())
                {
                    var query = (from p in db.Users
                                 where p.Username == username
                                 && p.Password == password
                                 select p).FirstOrDefault();
                    if (query == null)
                        return;

                    usr.Username = query.Username;
                    usr.Password = query.Password;
                    usr.User_Admin = query.User_Admin;
                    usr.User_ID = query.User_ID;

                    LoggedUser = usr;
                }
            }
            catch (Exception)
            {
                usr.Username = "NODBFOUND";
                LoggedUser = usr;
            }
     
        }
    }
}
