using PusherServer;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace Project_Nhom1.Controllers
{
    public class BlogPostController : Controller
    {
        public ActionResult Index()
        {           
            var post = new BlogPost();
            var bpDao = new BlogPostDAO();
             var listBlog = bpDao.GetAllBlogPost();
            var Listmodel = new List<BlogPostModel>();
            foreach(var item in listBlog.ToList())
            {
                var model = new BlogPostModel();
                model.BlogPostID = item.BlogPostID;
                model.Body = item.Body;
                model.Title = item.Title;
                Listmodel.Add(model);
            }            
            //var blogmodel = model as IEnumerable<BlogPostModel>;
            return View(Listmodel);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BlogPost post)
        {
            var blogpost = new BlogPost();                       
            blogpost.BlogPostID = post.BlogPostID;
            blogpost.Body = post.Body;
            blogpost.Title = post.Title;
            BlogPostDAO bpDao = new BlogPostDAO();
            bpDao.AddBlogPost(post);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            var blogDao = new BlogPostDAO().Details(id);
            return View(blogDao);
        }

        

        //[HttpPost]
        //public async Task<ActionResult> Comment(Model.EF.Comment data)
        //{
        //    CommentDAO cmtDao = new CommentDAO();
        //    cmtDao.AddComment(data);
        //    var options = new PusherOptions();
        //    options.Cluster = "ap1";
        //    var pusher = new Pusher("1072058", "b50b10f861de3e38c121", "50c05543df2a7eab8101", options);
        //    ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
        //    return Content("ok");
        //}
    }
}
