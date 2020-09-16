using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Project_Nhom1.Models;
using PagedList;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using PusherServer;

namespace Project_Nhom1.Controllers
{
    public class ProductController : Controller
    {
        WebBanHangDbContext data = new WebBanHangDbContext();
        // GET: Product
        public ActionResult Index(string KeySearch = "", int pageNum = 1, int pageSize = 9)
        {
            var product = new ProductDAO().GetAllProduct(KeySearch);
            return View(product.ToPagedList(pageNum, pageSize));
        }
        public ActionResult DetailProduct(long id)
        {
            var product = new ProductDAO().Detail(id);          
            return View(product);
        }
        public ActionResult TradeMarkProduct(long id)
        {
            var product = new ProductDAO().GetProductByIDTradeMark(id);
            return View(product);
        }
        public ActionResult CategoryProduct(long id)
        {
            var product = new ProductDAO().GetProductByIDCategory(id);
            return View(product);
        }
        [ChildActionOnly]
        public PartialViewResult ListComments()
        {

            var comment = new Comment();
            var commentDao = new CommentDAO().GetAllComments();
            return PartialView(commentDao);
        }
        public ActionResult Comments(long id)
        {
            var comments = data.Comments.Where(x => x.ProductID == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            CommentDAO cmtDao = new CommentDAO();
            cmtDao.AddComment(data);
            var options = new PusherOptions();
            options.Cluster = "ap1";
            var pusher = new Pusher("1072058", "b50b10f861de3e38c121", "50c05543df2a7eab8101", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }
    }
}