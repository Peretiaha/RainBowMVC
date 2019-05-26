using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RainbowWeb.Models
{
    public static class AddContacts
    {
        public static bool Add(Users user)
        {
            using (DbModel db = new DbModel())
            {
                Contacts con = new Contacts();
                con.Email = user.Email;
                if (db.Contacts.Any(x => x.Email.ToUpper() == con.Email.ToUpper())) return false;
                else
                {
                    db.Contacts.Add(con);
                    db.SaveChanges();
                }
            }
            return true;
        }

    }
}