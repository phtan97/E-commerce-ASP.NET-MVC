using Model.DAO;
using Model.EF;
using PagedList;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Admin/Blogs
        public ActionResult Index(string KeySearch = "", int pageNum = 1, int pageSize = 10)
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            BlogDAO blogDao = new BlogDAO();
            var ListBlog = blogDao.GetAllBlogs(KeySearch, pageNum, pageSize);
            var model = new List<BlogModel>();
            foreach (var item in ListBlog)
            {
                var blogModel = new BlogModel();
                blogModel.BlogID = item.BlogID;
                blogModel.Title = item.Title;
                blogModel.Body = item.Body;
                blogModel.Author = item.Author;
                blogModel.CreateDate = item.CreateDate;
                blogModel.BlogImg = item.BlogImg;
                model.Add(blogModel);
            }
            return View(model);
        }
        public ActionResult AddBlog()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddBlog(BlogModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var blogDAO = new BlogDAO();
                var blog = new Blog();
                blog.BlogID = model.BlogID;
                blog.Title = model.Title;
                blog.Body = model.Body;
                blog.Author = model.Author;
                blog.CreateDate = DateTime.Now;
                var fileName = Path.GetFileName(file.FileName);
                var filePath = fileName;
                string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                model.BlogImg = filePath;
                blog.BlogImg = model.BlogImg;
                blogDAO.AddBlog(blog);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}