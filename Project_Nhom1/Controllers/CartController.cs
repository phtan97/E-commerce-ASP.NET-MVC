using Model.DAO;
using Model.EF;
using Project_Nhom1.Common;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Project_Nhom1.Controllers
{
    public class CartController : Controller
    {
        public const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }
            ViewBag.ToTal = Total();
            return View(list);
        }

        public JsonResult Delete(long id)
        {
            var Sessioncart = (List<CartModel>)Session[CartSession];
            Sessioncart.RemoveAll(m => m.Product.IDProduct == id);
            Session[CartSession] = Sessioncart;
            return Json(new
            {
                status = true
            });

        }
        public JsonResult Update(string cartModel)
        {
            var Jsoncart = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);
            var Sessioncart = (List<CartModel>)Session[CartSession];
            foreach (var item in Sessioncart)
            {
                var Jsonitem = Jsoncart.SingleOrDefault(m => m.Product.IDProduct == item.Product.IDProduct);
                if (Jsonitem != null)
                {
                    item.Quantity = Jsonitem.Quantity;
                }
            }
            Session[CartSession] = Sessioncart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult AddCart(long productID, int quantity)
        {
            var product = new ProductDAO().Detail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(m => m.Product.IDProduct == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.IDProduct == productID)
                        {
                            item.Product.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartModel();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartModel();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartModel>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return Json(new
            {
                status = true
            });
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
        public ActionResult Checkout()
        {
            if (Session[Constant.USER_SESSION] != null)
            {
                var cart = Session[CartSession];
                var list = new List<CartModel>();
                ViewBag.ToTal = Total();
                if (cart != null)
                {
                    list = (List<CartModel>)cart;
                }
                return View(list);
            }
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Checkout(string Name, string Address, string Phone, string Email)
        {
            var order = new Order();
            //User user = (User)Session["Account"];
            //order.IDUser = user.IDUser;
            order.Name = Name;
            order.Email = Email;
            order.Address = Address;
            order.Phone = Phone;
            order.DateOrder = DateTime.Now;
            order.DateDelivery = DateTime.Now.AddDays(3);
            var id = new OrderDAO().Insert(order);
            var cart = (List<CartModel>)Session[CartSession];
            var detailDao = new DetailOrderDAO();
            decimal total = 0;
            foreach (var item in cart)
            {
                var orderDetail = new DetailOrder();
                orderDetail.IDProduct = item.Product.IDProduct;
                orderDetail.IDOrder = id;
                orderDetail.UnitPrice = item.Product.Price;
                orderDetail.Quantity = item.Quantity;
                detailDao.Insert(orderDetail);

                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.ToTal = total;
            }
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/client/template/neworder.html"));

            content = content.Replace("{{CustomerName}}", Name);
            content = content.Replace("{{Phone}}", Phone);
            content = content.Replace("{{Email}}", Email);
            content = content.Replace("{{Address}}", Address);
            content = content.Replace("{{Total}}", ViewBag.ToTal.ToString("N0"));
            //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            //new MailHelper().SendMail(order.Email, "new order", content);
            //new MailHelper().SendMail(toEmail, "new order", content);

            return Redirect("InformationOrder");
        }
        public ActionResult InformationOrder()
        {
            Session.Remove(CartSession);
            return View();
        }
    }
}