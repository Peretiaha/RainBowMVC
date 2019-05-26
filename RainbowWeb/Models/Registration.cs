using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainbowWeb.Models
{
    public static class Registration
    {

        public static bool Add(Users user)
        {
            using (DbModel db = new DbModel())
            {
                if (db.Users.Any(x => x.Login == user.Login)) return false;

                else {
                    user.ConfirmPassword = user.Password;
                    user.PromoCode = PromocodeCreate.Promo();
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            return true;

        }


    }
}