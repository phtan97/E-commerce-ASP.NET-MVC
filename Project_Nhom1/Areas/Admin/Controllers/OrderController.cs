using Model.DAO;
using Model.EF;
using Project_Nhom1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(string KeySearch="")
        {
            OrderDAO orderDao = new OrderDAO();
            var listOrders = orderDao.GetAllOrder(KeySearch);

            var model = new List<OrderModel>();
            foreach(var i in listOrders)
            {
                var item = new OrderModel();
                item.Name = i.Order.Name;
                item.Address = i.Order.Address;
                item.Email = i.Order.Email;
                item.Phone = i.Order.Phone;
                item.IDProduct = i.IDProduct;
                item.IDOrder = i.IDOrder;
                item.NameProduct = i.Product.Name;
                item.Quantity = i.Quantity;
                ViewBag.Total = (i.Quantity * i.Product.Price);
                model.Add(item);
            }

            return View(model);
        }

    }
}