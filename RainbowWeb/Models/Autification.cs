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
                if (db.Users.Any(x => x.Login == user.Login && x.Password == user.Password))
                {
                    LoginUser lus = new LoginUser() {LoginDate=DateTime.Now, Login=user.Login, Password=user.Password, Status = db.Users.Any(x=>x.Status)};
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