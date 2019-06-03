using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RainbowWeb.Models
{
    public class LoginUser
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage = "Enter your Login")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoginDate { get; set; }

        public bool Status { get; set; }
    }
}