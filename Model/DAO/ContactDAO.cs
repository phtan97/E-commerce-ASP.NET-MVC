using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        WebBanHangDbContext data = null;
        public ContactDAO()
        {
            data = new WebBanHangDbContext();
        }
        public List<Contact> GetAllContact(string search)
        {
            var result = data.Contacts.AsQueryable();
            return result.ToList();
        }
        public void SendMessage(Contact contact)
        {
            data.Contacts.Add(contact);
            data.SaveChanges();
        }
    }
}
