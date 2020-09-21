using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Models
{
    public class BlogModel
    {
        public long BlogID { get; set; }


        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime? CreateDate { get; set; }
        public string BlogImg { get; set; }

    }
}