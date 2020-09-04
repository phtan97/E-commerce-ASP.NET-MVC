using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CommentDAO
    {
        WebBanHangDTDbContext data = null;
        public CommentDAO()
        {
            data = new WebBanHangDTDbContext();
        }
        public List<UserCommentViewModel> ListByUserID()
        {
            var comment = from a in data.Feedbacks
                          join b in data.Users
                            on a.IDUser equals b.IDUser
                          where a.IDUser == b.IDUser
                          select new UserCommentViewModel()
                          {
                              IDUser = b.IDUser,
                              UserName = b.UserName,
                              Comment = a.Comment
                          };
            return comment.ToList();
        }
        public void InserComment(Feedback fb)
        {
            data.Feedbacks.Add(fb);
            data.SaveChanges();
        }
    }
}
