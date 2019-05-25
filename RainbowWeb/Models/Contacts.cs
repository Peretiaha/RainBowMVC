using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RainbowWeb.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}