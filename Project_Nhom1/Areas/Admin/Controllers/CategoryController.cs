using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Project_Nhom1.Areas.Admin.Models;

namespace Project_Nhom1.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string KeySearch = "")
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            CategoryDAO catedao = new CategoryDAO();
            var ListCategory = catedao.GetAllCategory(KeySearch);
            var model = new List<CategoryModel>();
            foreach(var i in ListCategory)
            {
                var item = new CategoryModel();
                item.IDCategory = i.IDCategory;
                item.Name = i.NameCategory;
                model.Add(item);
            }
            return View(model);
        }
        public ActionResult EditCategory(int id)
        {
            CategoryDAO catedao = new CategoryDAO();
            var category = catedao.GetCategoryByID(id);
            if (category != null)
            {
                var catemodel = new CategoryModel();
                catemodel.IDCategory = category.IDCategory;
                catemodel.Name = category.NameCategory;
                return View(catemodel);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryModel catemodel)
        {
            if (catemodel.IDCategory != 0)
            {
                CategoryDAO catedao = new CategoryDAO();
                var category = catedao.GetCategoryByID(catemodel.IDCategory);
                category.NameCategory = catemodel.Name;
                catedao.UpdateCategory(category);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddCategory()
        {
            var catemodel = new CategoryDAO();
            return View(catemodel);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel catemodel)
        {
            var category = new Category();
            category.NameCategory = catemodel.Name;
            CategoryDAO catedao = new CategoryDAO();
            catedao.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}