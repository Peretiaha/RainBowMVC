using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace RainbowWeb.Models
{
    public static class PromocodeCreate
    {

        public static string Generate()
        {
            char[] promocode = new char[6];
            Random rand = new Random();

            for (int i = 0; i < promocode.Length; i++)
            {
                promocode[i] = (char)rand.Next(0x0041, 0x007A);
                Thread.Sleep(1);
            }   
            string promo = new string(promocode);
            return promo;
            

        }


        public static string Cheak(string promocode)
        {
            using (DbModel db = new DbModel())
            {
                while(db.Users.Any(x => x.PromoCode == promocode)) Generate();                
            }

            return promocode;


        }

        public static string Promo()
        {
            string promo = Generate();
            string finalpromo = Cheak(promo);
            return finalpromo;
        }
    }
}