using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsLib.Models
{
    public class ContactsRepo : IContactsRepo
    {
        private WebApiCoreAssignmentContext _context; 
        public ContactsRepo(WebApiCoreAssignmentContext context)
        {
            _context = context;
        }
        public async Task<int> AddContact(Contact c)
        {
            if (_context != null)
            {
                _context.Contacts.Add(c);
                await _context.SaveChangesAsync();
                return c.ContactNo;
            }
            return 0;
        }

        public async Task<int> DeleteContact(int contactid)
        {
            int result = 0;
            if (_context != null)
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.ContactNo == contactid);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    result = await _context.SaveChangesAsync();
                }
                
            }
            return result;
        }

        public async Task<List<Contact>> GetContacts()
        {
            if (_context != null)
            {
                return await _context.Contacts.ToListAsync();
            }
            return null;
        }

        public async Task<List<Contact>> GetContactsByCity(string city)
        {
            var contacts = _context.Contacts.Where(con => con.CityName.ToLower() == city.ToLower());
            if (contacts != null)
            {
                return await contacts.ToListAsync();
            }
            return null;
        }

        public async Task UpdateContact(Contact c)
        {
            if (_context != null)
            {                
                _context.Contacts.Update(c);                
                await _context.SaveChangesAsync();
            }
        }
    }
}
