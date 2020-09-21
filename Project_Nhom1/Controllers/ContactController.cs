using Model.DAO;
using Model.EF;
using Project_Nhom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(ContactModel model) 
        {
            var contactDao = new ContactDAO();
            var contact = new Contact();
            contact.ContactID = model.ContactID;
            contact.Name = model.Name;
            contact.Email = model.Email;
            contact.Message = model.Message;
            contactDao.SendMessage(contact);
            return RedirectToAction("Index");
        }
    }
}