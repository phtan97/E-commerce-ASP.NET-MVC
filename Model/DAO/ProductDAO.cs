using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDAO
    {
        WebBanHangDbContext data = null;
        public ProductDAO()
        {
            data = new WebBanHangDbContext();
        }
        //lay san pham tu id
        public Product GetProductByID(long id)
        {
            return data.Products.FirstOrDefault(m => m.IDProduct == id);
        }
        public List<Product> GetProductByIDCategory(long CategoryID)
        {
            var result = data.Products.Where(m => m.IDCategory == CategoryID).ToList();
            return result;
        }
        public Product Detail(long id)
        {
            return data.Products.Find(id);
        }
        public List<Product> GetLastestProduct(long productid)
        {
            var product = data.Products.Find(productid);
            return data.Products.Where(m => m.IDProduct != productid && m.IDCategory == product.IDCategory).ToList();
        }
        public List<Product> GetProductByIDTradeMark(long id)
        {
            var result = data.Products.Where(m => m.IDTradeMark == id).ToList();
            return result;
        }
        public List<Product> GetAllProduct(string search)
        {
            var result = data.Products.ToList();
            if(search != "")
            {
                result = result.Where(m => m.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return result;
        }
        public List<Product> GetNewProduct(int count)
        {
            return data.Products.OrderByDescending(m => m.CreateDate).Take(count).ToList();
        }
        public void UpdateProduct(Product prd)
        {
            data.Products.AddOrUpdate(prd);
            data.SaveChanges();
        }
        public void AddProduct (Product prd)
        {
            data.Products.Add(prd);
            data.SaveChanges();
        }
        public void DelProduct(int id)
        {
            var product = data.Products.Find(id);
            data.Products.Remove(product);
            data.SaveChanges();
        }
    }
}
