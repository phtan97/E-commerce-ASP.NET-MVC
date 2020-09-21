using Model.DAO;
using PagedList;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index(string KeySearch = "", int page = 1, int pageSize = 4)
        {
            var blogDao = new BlogDAO();
            var ListBlog = blogDao.GetAllBlogs(KeySearch, page, pageSize);
            var model = new List<BlogModel>();
            foreach (var item in ListBlog)
            {
                var blogModel = new BlogModel();
                blogModel.BlogID = item.BlogID;
                blogModel.Title = item.Title;
                blogModel.Body = item.Body;
                blogModel.Author = item.Author;
                blogModel.CreateDate = DateTime.Now;
                blogModel.BlogImg = item.BlogImg;
                model.Add(blogModel);
            }
            return View(ListBlog);
        }
        public ActionResult Details(int id)
        {
            var blogDao = new BlogDAO().BlogDetails(id);
            return View(blogDao);
        }
        [ChildActionOnly]
        public PartialViewResult NewBlog(int page, int pageSize)
        {
            var blogDao = new BlogDAO().GetNewBlog(3);
            return PartialView(blogDao.ToPagedList(page,pageSize));
        }
        [ChildActionOnly]
        public PartialViewResult BloginHome()
        {
            var blogdao = new BlogDAO().GetNewBlog(3);
            return PartialView(blogdao);
        }
    
    }
}