using System.Collections.Generic;
using ContactAPI.Models;
using ContactAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        ContactRepository contactRepository = new ContactRepository();
        // GET api/contact
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contactRepository.GetAllContacts();
        }

        // GET api/contact/5
        [HttpGet("{contactId}")]
        public Contact Get(int contactId)
        {
            return contactRepository.GetContact(contactId);
        }

        // POST api/contact
        [HttpPost]
        public bool Post([FromBody]Contact contact)
        {
            return contactRepository.AddContact(contact);
        }

        // POST api/contact/update
        [HttpPost("{id}")]
        public bool Update([FromBody]Contact contact)
        {
            return contactRepository.UpdateContact(contact);
        }

        // DELETE api/contact/5
        [HttpDelete("{contactId}")]
        public bool Delete(int contactId)
        {
            return contactRepository.DeleteContact(contactId);
        }
    }
}
