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

namespace Project_Nhom1.Controllers
{
    public class ProductController : Controller
    {
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
        //public JsonResult DetailAddCart(string productModel)
        //{
        //    var Jsoncart = new JavaScriptSerializer().Deserialize<List<Product>>(productModel);
        //    var Sessioncart = (List<Product>)Session[CartSession];
        //    foreach (var item in Sessioncart)
        //    {
        //        var Jsonitem = Jsoncart.SingleOrDefault(m => m.IDProduct == item.IDProduct);
        //        item.Quantity = Jsonitem.Quantity;
        //    }
        //    Session[CartSession] = Sessioncart;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}
    }
}