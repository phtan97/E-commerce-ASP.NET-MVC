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
    public class TradeMarkController : Controller
    {
        // GET: Admin/TradeMark
        public ActionResult Index(string KeySearch = "")
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            TradeMarkDAO tmdao = new TradeMarkDAO();
            CategoryDAO pcdao = new CategoryDAO();
            var ListTM = tmdao.GetAllTradeMark(KeySearch);
            var model = new List<TradeMarkModel>();
            foreach (var item in ListTM)
            {
                var tmModel = new TradeMarkModel();
                var category = pcdao.GetCategoryByID(item.IDCategory);
                tmModel = TradeMarktoTradeMarkModel(item);
                tmModel.NameCategory = category.NameCategory;
                model.Add(tmModel);
            }
            return View(model);
        }
        public ActionResult EditTradeMark(int id)
        {
            TradeMarkDAO tmdao = new TradeMarkDAO();
            var trademark = tmdao.GetTradeMarkByID(id);
            if (trademark != null)
            {
                var tmModel = new TradeMarkModel();
                tmModel.IDTradeMark = trademark.IDTradeMark;
                tmModel.Name = trademark.Name;
                return View(tmModel);
            }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditTradeMark(TradeMarkModel tmModel)
        {
            if (tmModel.IDTradeMark != 0)
            {
                TradeMarkDAO tmdao = new TradeMarkDAO();
                var trademark = tmdao.GetTradeMarkByID(tmModel.IDTradeMark);
                trademark.Name = tmModel.Name;
                tmdao.UpdateTradeMark(trademark);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddTradeMark()
        {
            var tmModel = new TradeMarkDAO();
            return View(tmModel);
        }
        [HttpPost]
        public ActionResult AddTradeMark(TradeMarkModel tmModel)
        {
            var trademark = new TradeMark();
            trademark.Name = tmModel.Name;
            TradeMarkDAO tmdao = new TradeMarkDAO();
            tmdao.UpdateTradeMark(trademark);
            return RedirectToAction("Index");
        }
        private TradeMarkModel TradeMarktoTradeMarkModel(TradeMark tm)
        {
            var tmModel = new TradeMarkModel();
            tmModel.IDTradeMark = tm.IDTradeMark;
            tmModel.Name = tm.Name;
            tmModel.IDCategory = tm.IDCategory;
            return tmModel;
        }
    }
}