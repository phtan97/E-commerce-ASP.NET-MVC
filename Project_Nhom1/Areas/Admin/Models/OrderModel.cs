using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Areas.Admin.Models
{
    public class OrderModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long IDProduct { get; set; }
        public long IDOrder { get; set; }
        public int? Quantity { get; set; }
        public string NameProduct { get; set; }
    }
}