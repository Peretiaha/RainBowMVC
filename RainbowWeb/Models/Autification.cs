using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainbowWeb.Models
{
    public static class Autification
    {

        public static bool IsRegstered(Users user)
        {
            using (DbModel db = new DbModel())
            {
                LoginUser lus = new LoginUser();
                if (db.Users.Any(x => x.Login == user.Login && x.Password == user.Password && x.Status == true))
                {

                    lus.LoginDate = DateTime.Now;
                    lus.Login = user.Login;
                    lus.Password = user.Password;
                    lus.Status = true;

                    db.LoginUsers.Add(lus);
                    db.SaveChanges();
                    return true;
                }
                else if (db.Users.Any(x => x.Login == user.Login && x.Password == user.Password && x.Status == false))
                {
                    lus.LoginDate = DateTime.Now;
                    lus.Login = user.Login;
                    lus.Password = user.Password;
                    lus.Status = false;
                    

                    db.LoginUsers.Add(lus);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        public static bool UserStatus(Users user)
        {
            using (DbModel db = new DbModel())
            {
                if (db.Users.Any(x => x.Login == user.Login && x.Status == true))
                return true;
                else return false;
            }
        }



    }
}