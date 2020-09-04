using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom1.Models;

namespace Project_Nhom1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var product = new ProductDAO().GetNewProduct(8);
            return View(product);
        }
        [ChildActionOnly]
        public ActionResult CatalogProduct()
        {
            var product = new ProductDAO().GetNewProduct(3);
            return PartialView(product);
        }
    }
}