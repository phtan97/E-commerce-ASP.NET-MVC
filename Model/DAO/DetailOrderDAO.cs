using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DetailOrderDAO
    {
        WebBanHangDTDbContext data = null;
        public DetailOrderDAO()
        {
            data = new WebBanHangDTDbContext();
        }
        public bool Insert(DetailOrder detail)
        {
            try
            {
                data.DetailOrders.Add(detail);
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
