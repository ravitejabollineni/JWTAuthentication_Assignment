using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsLib.Models
{
    public interface IContactsRepo
    {
        Task<int> AddContact(Contact c);
        Task<List<Contact>> GetContacts();
        Task UpdateContact(Contact c);
        Task<int> DeleteContact(int contactid);
        Task<List<Contact>> GetContactsByCity(string city);
    }
}
