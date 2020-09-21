using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PusherServer;

namespace Model.DAO
{
    public class CommentDAO
    {
        WebBanHangDbContext data = null;
        public CommentDAO()
        {
            data = new WebBanHangDbContext();
        }
        public void AddComment(Comment comment)
        {
            data.Comments.Add(comment);
            data.SaveChanges();
        }

        public List<Comment> GetAllComments()
        {
            var result = data.Comments.AsQueryable();
            return result.ToList();
        }
    }
}
