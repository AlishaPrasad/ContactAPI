using System.Collections.Generic;
using System.Linq;
using MyContacts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyContacts.Repository;
using MyContacts.DAL;
using Moq;
using System;

namespace MyContacts.Tests
{
    [TestClass]
    public class ContactRepositoryTest
    {
        private ContactRepository _contactRepository = null;
        protected Mock<IContactDAL> MockContactDAL { get; private set; }

        #region Initialize and Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            MockContactDAL = new Mock<IContactDAL>();
            _contactRepository = new ContactRepository(MockContactDAL.Object);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            MockContactDAL.VerifyAll();
        }
        #endregion

        #region Tests
        [TestMethod]
        public void GetAllContacts_ReturnsSuccess()
        {
            IEnumerable<Contact> contacts = CreateContactList();
            List<Contact> expectedContacts = contacts.ToList();

            MockContactDAL.Setup(x => x.GetAllContacts()).Returns(contacts);

            var result = _contactRepository.GetAllContacts();
            Assert.IsNotNull(result);
            var actualContacts = result.ToList();
            Assert.AreEqual(expectedContacts.Count, actualContacts.Count, "Expected and actual count should be equal");
            Assert.AreEqual(actualContacts[0].FirstName, expectedContacts[0].FirstName, "Expected and actual first name should be equal");
        }

        [TestMethod]
        public void GetContact_ReturnsSuccess()
        {
            Contact expectedContact = CreateContactData();

            MockContactDAL.Setup(x => x.GetContact(It.IsAny<int>())).Returns(expectedContact);

            var actualContact = _contactRepository.GetContact(expectedContact.ContactId);
            Assert.IsNotNull(actualContact);
            Assert.AreEqual(actualContact.FirstName, expectedContact.FirstName, "Expected and actual first name should be equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetContact_InvalidContactId_ThrowsArgumentException()
        {
            int contactId = 0;
            var result = _contactRepository.GetContact(contactId);
        }

        [TestMethod]
        public void UpdateContact_ReturnsSuccess()
        {
            Contact contact = CreateContactData();

            MockContactDAL.Setup(x => x.UpdateContact(It.Is<Contact>(e => e == contact))).Returns(true);

            var result = _contactRepository.UpdateContact(contact);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateContact_NullContact_ThrowsArgumentNullException()
        {
            Contact contact = null;
            var result = _contactRepository.UpdateContact(contact);
        }

        [TestMethod]
        public void DeleteContact_ReturnsSuccess()
        {
            var contact = CreateContactData();

            MockContactDAL.Setup(x => x.DeleteContact(It.IsAny<int>())).Returns(true);

            var result = _contactRepository.DeleteContact(contact.ContactId);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteContact_InvalidContactId_ThrowsArgumentException()
        {
            int contactId = 0;
            var result = _contactRepository.DeleteContact(contactId);
        }
        #endregion

        #region Private Methods
        private IEnumerable<Contact> CreateContactList()
        {
            return new List<Contact>() { CreateContactData() };
        }

        private Contact CreateContactData()
        {
            return new Contact
            {
                ContactId = 1,
                FirstName = "first",
                LastName = "last",
                Email = "first.last@test.com",
                PhoneNumber = "1234567890",
                Status = "Active"
            };
        }
        #endregion
    }
}
