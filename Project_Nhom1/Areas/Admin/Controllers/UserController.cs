using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom1.Areas.Admin.Models;
using Model.DAO;
using Model.EF;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string KeySearch = "")
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserDAO userdao = new UserDAO();
            var ListUser = userdao.GetAllUser(KeySearch);
            var model = new List<UserModel>();
            foreach(var u in ListUser)
            {
                var item = new UserModel();
                item.IDUser = u.IDUser;
                item.UserName = u.UserName;
                item.Name = u.Name;
                item.Address = u.Address;
                item.NumberPhone = u.NumberPhone;
                item.Image = u.Image;
                model.Add(item);
            }
            return View(model);
        }
    }
}