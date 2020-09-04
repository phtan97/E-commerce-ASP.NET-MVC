using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    public class ProductModel
    {
        public long IDProduct { get; set; }
        public string NameProduct { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long IDCategory { get; set; }
        public string NameCategory { get; set; }
        public long IDTradeMark { get; set; }
        public string NameTradeMark { get; set; }
        public int Quantity { get; set; }
    }
}