using Model.DAO;
using Project_Nhom1.Common;
using Project_Nhom1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var admin = dao.GetByUserName(model.UserName);
                    var AdminSession = new AdminLogin();
                    AdminSession.UserName = admin.UserName;
                    Session.Add(Constant.ADMIN_SESSION, AdminSession);
                    return RedirectToAction("Index", "Product");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "The requested user could not be found.");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Password incorrect");
                }
                else
                {
                    ModelState.AddModelError("", "E-mail incorrect");
                }

            }
            return View("Index");
        }
    }
}