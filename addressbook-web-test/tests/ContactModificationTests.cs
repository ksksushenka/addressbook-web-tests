using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
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

            app.Contacts.Modify(newContactData);
        }
    }
}
