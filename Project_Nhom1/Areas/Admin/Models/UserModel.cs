﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Areas.Admin.Models
{
    public class UserModel
    {
        public long IDUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Image { get; set; }

    }
}