using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BlogDAO
    {
        WebBanHangDbContext data = null;
        public BlogDAO()
        {
            data = new WebBanHangDbContext();
        }
        public IPagedList<Blog> GetAllBlogs(string search, int page, int pageSize)
        {
            IQueryable<Blog> result = data.Blogs.OrderBy(x => x.BlogID);
            if (search != "")
            {
                result = result.Where(m => m.Title.ToLower().Contains(search.ToLower()));
            }
            return new PagedList<Blog>(result, page, pageSize);
        }
        public void AddBlog(Blog blog)
        {
            data.Blogs.Add(blog);
            data.SaveChanges();
        }
        public List<Blog> GetNewBlog(int count)
        {
            return data.Blogs.OrderByDescending(x => x.CreateDate).Take(count).ToList();
        }
        public Blog BlogDetails(long id)
        {
            return data.Blogs.Find(id);
        }
    }
}
