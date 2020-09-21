using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    public class ContactModel
    {
        public long ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}