using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.DAO
{
    public class BlogPostDAO
    {
        WebBanHangDbContext data = null;
        public BlogPostDAO()
        {
            data = new WebBanHangDbContext();
        }
        public void AddBlogPost(BlogPost post)
        {
            data.BlogPosts.Add(post);
            data.SaveChanges();
        }
        public BlogPost Details(int? id)
        {
            return data.BlogPosts.Find(id);
        }
        public List<BlogPost> GetAllBlogPost()
        {
            var result = data.BlogPosts.AsQueryable();
            return result.ToList();
        }

    }
}
