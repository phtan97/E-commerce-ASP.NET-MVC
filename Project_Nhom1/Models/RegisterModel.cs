using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    public class RegisterModel
    {
        [Display(Name ="Name Account")]
        [Required(ErrorMessage = "Enter your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your Password")]
        [StringLength(20,MinimumLength =6,ErrorMessage = "Password length is at least 6 characters")]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm password incorrect")]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}