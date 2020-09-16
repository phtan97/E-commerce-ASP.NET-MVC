using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class AdminDAO
    {
        WebBanHangDbContext data = null;
        public AdminDAO()
        {
            data = new WebBanHangDbContext();
        }
        public string Insert(Admin entity)
        {
            data.Admins.Add(entity);
            data.SaveChanges();
            return entity.UserName;
        }
        public Admin GetByUserName(string UserName)
        {
            return data.Admins.FirstOrDefault(x => x.UserName == UserName);
        }
        public int Login(string UserName, string Password)
        {
            var result = data.Admins.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == Password)
                {
                    return 1;
                }
                else
                    return 2;
            }
        }
    }
}
