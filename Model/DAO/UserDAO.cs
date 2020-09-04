using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity.Migrations;

namespace Model.DAO
{
   public class UserDAO
    {
        WebBanHangDTDbContext data = null;
        public UserDAO()
        {
            data = new WebBanHangDTDbContext();
        }

        //public long Insert(User entity)
        //{
        //    data.Users.Add(entity);
        //    data.SaveChanges();
        //    return entity.IDUser;
        //}

        public int Login(string userName, string Password)
        {
            var result = data.Users.FirstOrDefault(m => m.UserName == userName && m.Password == Password);
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

        public bool CheckUserExist(string userName)
        {
            var user = data.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user != null;
        }

        public User GetUserByID(long id)
        {
            var result = data.Users.FirstOrDefault(m => m.IDUser == id);
            return result;

        }
        public User GetByID(string userName)
        {
            return data.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public List<User> GetAllUser(string KeySearch = "")
        {
            var result = data.Users.AsQueryable();
            if (KeySearch != "")
            {
                result = result.Where(m => m.UserName.ToLower().Contains(KeySearch.ToLower()));
            }
            return result.ToList();
        }
        public void UpdateUser(User user)
        {
            data.Users.AddOrUpdate(user);
            data.SaveChanges();
        }
        public void AddUser(User user)
        {
            data.Users.Add(user);
            data.SaveChanges();
        }

    }
}
