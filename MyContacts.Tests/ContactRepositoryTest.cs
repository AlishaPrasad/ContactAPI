using System.Collections.Generic;
using System.Linq;
using ContactAPI.Models;
using ContactAPI.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyContacts.Tests
{
    [TestClass]
    public class ContactRepositoryTest
    {
        [TestMethod]
        public void GetAllContacts_ReturnsAllContacts()
        {
            var expectedContacts = new List<Contact>(){
                    new Contact {
                        ContactId = 1,
                        FirstName = "first",
                        LastName = "last",
                        Email = "first.last@test.com",
                        PhoneNumber = "1234567890",
                        Status = "Active"
                    }
                };
            var contactRepository = new ContactRepository();
            var result = contactRepository.GetAllContacts();
            Assert.IsNotNull(result);
            var actualContacts = result.ToList();
            Assert.AreEqual(expectedContacts.Count, actualContacts.Count, "Expected and actual count should be equal");
            Assert.AreEqual(actualContacts[0].FirstName, expectedContacts[0].FirstName, "Expected and actual first name should be equal");
        }

        [TestMethod]
        public void GetContact_ReturnsAllContacts()
        {
            var expectedContact = CreateContactData();
            var contactRepository = new ContactRepository();
            var actualContact = contactRepository.GetContact(expectedContact.ContactId);
            Assert.IsNotNull(actualContact);
            Assert.AreEqual(actualContact.FirstName, expectedContact.FirstName, "Expected and actual first name should be equal");
        }

        private IEnumerable<Contact> CreateContactList()
        {
            return new List<Contact>() {
                        CreateContactData()
                    };
        }

        private Contact CreateContactData()
        {
            return new Contact {
                        ContactId = 1,
                        FirstName = "first",
                        LastName = "last",
                        Email = "first.last@test.com",
                        PhoneNumber = "1234567890",
                        Status = "Active"
                    };
        }
    }
}
