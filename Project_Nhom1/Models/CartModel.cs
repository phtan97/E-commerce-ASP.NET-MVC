using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    [Serializable]
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal? iTotal
        {
            get { return Quantity * Product.Price; }
        }
    }
}