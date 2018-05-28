using System.Collections.Generic;
using MyContacts.Models;

namespace MyContacts.DAL
{
    public interface IContactDAL
    {
        IEnumerable<Contact> GetAllContacts();

        bool UpdateContact(Contact contact);

        Contact GetContact(int contactId);

        bool DeleteContact(int contactId);

    }
}