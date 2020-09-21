using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Nhom1.Models
{
    public class CommentModel
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Body { get; set; }
        public int? BlogPostID { get; set; }

    }
}
