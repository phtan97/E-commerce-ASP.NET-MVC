using Model.DAO;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        public ActionResult Index(string KeySearch)
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var contactDao = new ContactDAO();
            var ListContact = contactDao.GetAllContact(KeySearch);
            var model = new List<ContactModel>();
            foreach (var u in ListContact)
            {
                var item = new ContactModel();
                item.ContactID = u.ContactID;
                item.Name = u.Name;
                item.Email = u.Email;
                item.Message = u.Message;
                model.Add(item);
            }
            return View(model);
        }
    }
}