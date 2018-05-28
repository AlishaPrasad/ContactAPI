using System.Collections.Generic;
using MyContacts.Models;

namespace MyContacts.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();

        bool UpdateContact(Contact contact);

        Contact GetContact(int contactId);

        bool DeleteContact(int contactId);

    }
}