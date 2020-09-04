using Model.DAO;
using Model.EF;
using Project_Nhom1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string KeySearch = "")
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index","Login");
            }
            ProductDAO prdao = new ProductDAO();
            CategoryDAO pcdao = new CategoryDAO();
            var ListProduct = prdao.GetAllProduct(KeySearch);
            var model = new List<ProductModel>();
            foreach (var item in ListProduct)
            {
                var ModelItem = new ProductModel();
                var Category = pcdao.GetCategoryByID(item.IDCategory);
                ModelItem = ProducttoProductModel(item);
                ModelItem.NameCategory = Category.NameCategory;
                model.Add(ModelItem);
            }

            return View(model);
        }
        public ActionResult EditProduct(int id)
        {
            if (id > 0)
            {
                ProductDAO prodao = new ProductDAO();
                var product = prodao.GetProductByID(id);
                if (product != null)
                {
                    var model = ProducttoProductModel(product);
                    model.Categories = GetCategorySelectList(product.IDCategory);
                    model.TradeMarks = GetTradeMarkSelectList(product.IDTradeMark);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditProduct(ProductModel prdm, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var prdao = new ProductDAO();
                var prd = new Product();
                prd.Name = prdm.Name;
                prd.IDCategory = prdm.IDCategory;
                prd.IDTradeMark = prdm.IDTradeMark;
                prd.Description = prdm.Description;
                prd.Price = prdm.Price;
                prd.CreateDate = DateTime.Now;
                if (file != null)
                {
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    var filePath = "/Content/Images/" + fileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    prdm.Image = filePath;
                    prd.Image = prdm.Image;
                }
                prdao.UpdateProduct(prd);
                return RedirectToAction("Index");
            }
            prdm.Categories = GetCategorySelectList(0);
            prdm.TradeMarks = GetTradeMarkSelectList(0);
            return View(prdm);
        }
        public ActionResult AddProduct()
        {
            var model = new ProductModel();
            model.Categories = GetCategorySelectList(0);
            model.TradeMarks = GetTradeMarkSelectList(0);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var producDao = new ProductDAO();
                var product = new Product();
                product.Name = model.Name;
                product.IDCategory = model.IDCategory;
                product.IDTradeMark = model.IDTradeMark;
                product.Description = model.Description;
                product.Price = model.Price;
                product.CreateDate = DateTime.Now;
                var fileName = Path.GetFileName(file.FileName);
                var filePath = fileName;
                string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                model.Image = filePath;
                product.Image = model.Image;
                producDao.AddProduct(product);
                return RedirectToAction("Index");
            }
            model.Categories = GetCategorySelectList(0);
            model.TradeMarks = GetTradeMarkSelectList(0);
            return View(model);
        }

        [HttpDelete]
        public ActionResult DelProduct(int id)
        {
            new ProductDAO().DelProduct(id);
            return RedirectToAction("Index");
        }

        private ProductModel ProducttoProductModel(Product item)
        {
            var model = new ProductModel();
            model.IDProduct = item.IDProduct;
            model.Name = item.Name;
            model.Description = item.Description;
            model.Image = item.Image;
            model.Price = item.Price.HasValue ? item.Price.Value : 0;
            model.IDCategory = item.IDCategory;
            return model;
        }
        private IEnumerable<SelectListItem> GetCategorySelectList(long CategoryID)
        {
            CategoryDAO pcdao = new CategoryDAO();
            var category = pcdao.GetAllCategory();
            return category.Select(m => new SelectListItem()
            {
                Text = m.NameCategory,
                Value = m.IDCategory.ToString(),
                Selected = m.IDCategory == CategoryID
            });
        }
        private IEnumerable<SelectListItem> GetTradeMarkSelectList(long TradeMarkID)
        {
            TradeMarkDAO tmdao = new TradeMarkDAO();
            var trademark = tmdao.GetAllTradeMark();
            return trademark.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.IDTradeMark.ToString(),
                Selected = m.IDTradeMark == TradeMarkID
            });
        }
    }
}