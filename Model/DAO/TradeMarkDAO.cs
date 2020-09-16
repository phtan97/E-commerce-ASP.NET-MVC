using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity.Migrations;

namespace Model.DAO
{
    public class TradeMarkDAO
    {
        WebBanHangDbContext data = null;
        public TradeMarkDAO()
        {
            data = new WebBanHangDbContext();
        }
        public TradeMark GetTradeMarkByID(long id)
        {
            var result = data.TradeMarks.FirstOrDefault(m => m.IDTradeMark == id);
            return result;
        }
        public List<TradeMark> GetAllTradeMark(string KeySearch = "")
        {
            var result = data.TradeMarks.AsQueryable();
            if (KeySearch != "")
            {
                result = result.Where(m => m.Name.ToLower().Contains(KeySearch.ToLower()));
            }
            return result.ToList();
        }
        public void UpdateTradeMark(TradeMark tm)
        {
            data.TradeMarks.AddOrUpdate(tm);
            data.SaveChanges();
        }
        public void AddTradeMark(TradeMark tm)
        {
            data.TradeMarks.Add(tm);
            data.SaveChanges();
        }
    }
}
