using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Models
{
    public class TradeMarkModel
    {
        public TradeMarkModel()
        {
            this.Categories = new List<SelectListItem>();
        }
        public long IDTradeMark { get; set; }
        public string Name { get; set; }
        public long IDCategory { get; set; }
        public string NameCategory { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
}
}