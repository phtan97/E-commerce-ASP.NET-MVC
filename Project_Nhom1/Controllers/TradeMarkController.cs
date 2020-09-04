using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Nhom1.Controllers
{
    public class TradeMarkController : Controller
    {
        // GET: TradeMark
        public ActionResult Index(string KeySearch = "")
        {
            var trademark = new TradeMarkDAO().GetAllTradeMark(KeySearch);
            return PartialView(trademark);
        }
    }
}