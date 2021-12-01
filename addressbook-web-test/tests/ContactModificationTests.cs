using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateContactIfElementPresent();

            ContactData newContactData = new ContactData("Test FN upd", "Test LN upd");
            newContactData.MiddleName = null;
            newContactData.Nickname = null;
            newContactData.Title = null;
            newContactData.Company = null;
            newContactData.Address = null;
            newContactData.Home = null;
            newContactData.Mobile = null;
            newContactData.Work = null;
            newContactData.Fax = null;
            newContactData.Email = null;
            newContactData.Email2 = null;
            newContactData.Email3 = null;
            newContactData.Homepage = null;
            newContactData.Bday = null;
            newContactData.Bmonth = null;
            newContactData.Byear = null;
            newContactData.Aday = null;
            newContactData.Amonth = null;
            newContactData.Ayear = null;
            newContactData.Address2 = null;
            newContactData.Phone2 = null;
            newContactData.Notes = null;

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactData = oldContacts[0];

            app.Contacts.Modify(oldContactData, newContactData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContactData.FirstName = newContactData.FirstName;
            oldContactData.LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.FirstName, contact.FirstName);
                    Assert.AreEqual(newContactData.LastName, contact.LastName);
                }
            }
        }
    }
}
