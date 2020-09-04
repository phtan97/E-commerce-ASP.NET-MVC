using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your Password")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}