using Model.DAO;
using Model.EF;
using Model.ViewModel;
using Project_Nhom1.Common;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constant.USER_SESSION] = null;
            return Redirect("/");
        }
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var UserSession = new AdminLogin();
                    UserSession.UserName = user.UserName;
                    Session.Add(Constant.USER_SESSION, UserSession);
                    TempData["UserName"] = checked(user.UserName);
                    TempData["Name"] = checked(user.Name);
                    TempData["Address"] = checked(user.Address);
                    TempData["Phone"] = checked(user.NumberPhone);
                    TempData["Email"] = checked(user.Email);
                    if (Session["CartSession"] == null)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    return RedirectToAction("Checkout", "Cart");
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
                    ModelState.AddModelError("", "Account incorrect");
                }

            }
            return View("Index");
        }
        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    UserDAO userDao = new UserDAO();


                    //check user existing
                    if (userDao.CheckUserExist(model.UserName))
                    {
                        ViewBag.UserExistError = "Account name already exist.";
                    }
                    else
                    {
                        User user = new User();
                        //map regiter model to user entity
                        user.Name = model.Name;
                        user.UserName = model.UserName;
                        user.Address = model.Address;
                        user.Email = model.Email;
                        user.Password = Encryptor.MD5Hash(model.Password);
                        user.ConfirmPassword = Encryptor.MD5Hash(model.ConfirmPassword);
                        user.CreateDate = DateTime.Now;
                        userDao.AddUser(user);
                        ViewBag.Success = "Welcome" + model.UserName;
                        model = new RegisterModel();
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ViewBag.Error = "Password not match.";
                }
            }

            return View(model);
        }

        //[HttpPost]
        //public ActionResult UserComment(UserCommentViewModel viewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var comment = new Feedback();
        //        var commentDao = new CommentDAO();
        //        comment.Comment = viewmodel.Comment;
        //        comment.User.UserName = viewmodel.UserName;
        //        commentDao.InserComment(comment);
        //        return new EmptyResult();

        //    }
        //    return new EmptyResult();   
        //}
    }
}