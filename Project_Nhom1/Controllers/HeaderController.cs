using Model.DAO;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Controllers
{
    public class HeaderController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Header
        [ChildActionOnly]
        public ActionResult _HeaderUser()
        {
            var model = new CategoryDAO().GetAllCategory();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult _HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }
            ViewBag.ToTal = Total();
            return PartialView(list);
        }
        public decimal? Total()
        {
            decimal? total = 0;
            var cart = Session[CartSession];
            var list = (List<CartModel>)cart;
            if (list != null)
            {
                total = list.Sum(m => m.iTotal);
            }
            return total;
        }
    }
}