using System.Collections.Generic;
using ContactAPI.Models;
using ContactAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        IContactRepository _contactRepository;

        public ContactController(IConfiguration Configuration) {
            _contactRepository = new ContactRepository(Configuration);
        }
        
        // GET api/contact
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetAllContacts();
        }

        // GET api/contact/5
        [HttpGet("{contactId}")]
        public Contact Get(int contactId)
        {
            return _contactRepository.GetContact(contactId);
        }

        // POST api/contact
        [HttpPost]
        public bool Update([FromBody]Contact contact)
        {
            return _contactRepository.UpdateContact(contact);
        }

        // DELETE api/contact/5
        [HttpDelete("{contactId}")]
        public bool Delete(int contactId)
        {
            return _contactRepository.DeleteContact(contactId);
        }
    }
}
