using System;
using System.Collections.Generic;
using MyContacts.DAL;
using MyContacts.Models;

namespace MyContacts.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactDAL _contactDAL;
        public ContactRepository(IContactDAL contactDAL) {
            _contactDAL = contactDAL;
        }
        
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactDAL.GetAllContacts();
        }

        public bool UpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException();
            }
            return _contactDAL.UpdateContact(contact);
        }

        public Contact GetContact(int contactId)
        {
            if (contactId <= 0)
            {
                throw new ArgumentException();
            }
            return _contactDAL.GetContact(contactId);
        }
        
        public bool DeleteContact(int contactId)
        {
            if (contactId <= 0)
            {
                throw new ArgumentException();
            }
            return _contactDAL.DeleteContact(contactId);
        }
    }
}