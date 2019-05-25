using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RainbowWeb.Models;
using System.IO;

namespace RainbowWeb.Models
{
    public class AddOrRevisionCommands
    {

        public static bool Add(Commands command, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] img = null; // считываем переданный файл в массив байтов

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    img = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                command.Img = img;

                using (DbModel db = new DbModel())
                {
                    if (db.Commands.Any(x => x.Name != command.Name))
                    {
                        db.Commands.Add(command);
                        db.SaveChanges();
                    }
                    else return false;
                }

                return true;
            }
            else return false;


        }

    }
}