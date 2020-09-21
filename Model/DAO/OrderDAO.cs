using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDAO
    {
        WebBanHangDbContext data = null;
        public OrderDAO()
        {
            data = new WebBanHangDbContext();
        }
        public long Insert(Order order)
        {
            data.Orders.Add(order);
            data.SaveChanges();
            return order.IDOrder;
        }
        public List<DetailOrder> GetAllOrder(string KeySearch = "")
        {
            var result = data.DetailOrders.AsQueryable();
            if (KeySearch != "")
            {
                result = result.Where(m => m.Product.Name.ToLower().Contains(KeySearch.ToLower()));
            }
            return result.ToList();
        }
    }
}
