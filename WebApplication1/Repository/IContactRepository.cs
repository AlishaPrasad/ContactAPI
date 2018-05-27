using System.Collections.Generic;
using ContactAPI.Models;

namespace ContactAPI.Repository {
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();

        bool UpdateContact(Contact contact);

        Contact GetContact(int contactId);

        bool DeleteContact(int contactId);

    }
}