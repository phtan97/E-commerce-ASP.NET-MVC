using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Models
{

    public class ProductModel
    {
        public ProductModel()
        {
            this.Categories = new List<SelectListItem>();
            this.TradeMarks = new List<SelectListItem>();
        }
        public long IDProduct { get; set; }
        [Required(ErrorMessage ="Please enter name product")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter price product")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter ID Category")]
        public long IDCategory { get; set; }
        public string NameCategory { get; set; }
        [Required(ErrorMessage = "Please enter ID TradeMark")]
        public long IDTradeMark { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> TradeMarks { get; set; }

    }
}