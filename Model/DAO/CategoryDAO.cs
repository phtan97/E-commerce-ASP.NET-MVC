using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDAO
    {
        WebBanHangDTDbContext data = null;
        public CategoryDAO()
        {
            data = new WebBanHangDTDbContext();
        }
        public Category GetCategoryByID(long id)
        {
            var result = data.Categories.FirstOrDefault(m => m.IDCategory == id);
            return result;

        }
        public List<Category> GetAllCategory(string KeySearch = "")
        {
            var result = data.Categories.AsQueryable();
            if (KeySearch != "")
            {
                result = result.Where(m => m.NameCategory.ToLower().Contains(KeySearch.ToLower()));
            }
            return result.ToList();
        }
        public void UpdateCategory(Category cgy)
        {
            data.Categories.AddOrUpdate(cgy);
            data.SaveChanges();
        }
        public void AddCategory(Category cgy)
        {
            data.Categories.Add(cgy);
            data.SaveChanges();
        }
    }
}
