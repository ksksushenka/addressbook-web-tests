using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Test FN upd", "Test LN upd");
            newContactData.MiddleName = "Test MN upd";
            newContactData.Nickname = "Test Nickname upd";
            newContactData.Title = "Test Title upd";
            newContactData.Company = "Test Company upd";
            newContactData.Address = "Test Address upd";
            newContactData.Home = "Test Home upd";
            newContactData.Mobile = "Test Mobile upd";
            newContactData.Work = "Test Work upd";
            newContactData.Fax = "Test Fax upd";
            newContactData.Email = "Test Email upd";
            newContactData.Email2 = "Test Email2 upd";
            newContactData.Email3 = "Test Email3 upd";
            newContactData.Homepage = "Test Homepage upd";
            newContactData.Bday = "19";
            newContactData.Bmonth = "May";
            newContactData.Byear = "1991";
            newContactData.Aday = "22";
            newContactData.Amonth = "May";
            newContactData.Ayear = "2022";
            newContactData.Address2 = "Test Address2 upd";
            newContactData.Phone2 = "Test Phone2 upd";
            newContactData.Notes = "Test Notes upd";

            app.Contacts.Modify(newContactData);
        }
    }
}
