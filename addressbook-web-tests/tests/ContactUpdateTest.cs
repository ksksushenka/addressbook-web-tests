using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactUpdateTests : TestBase
    {
        [Test]
        public void ContactUpdateTest()
        {
            ContactData contact = new ContactData("Test FN upd", "Test LN upd");
            contact.MiddleName = "Test MN upd";
            contact.Nickname = "Test Nickname upd";
            contact.Title = "Test Title upd";
            contact.Company = "Test Company upd";
            contact.Address = "Test Address upd";
            contact.Home = "Test Home upd";
            contact.Mobile = "Test Mobile upd";
            contact.Work = "Test Work upd";
            contact.Fax = "Test Fax upd";
            contact.Email = "Test Email upd";
            contact.Email2 = "Test Email2 upd";
            contact.Email3 = "Test Email3 upd";
            contact.Homepage = "Test Homepage upd";
            contact.Bday = "19";
            contact.Bmonth = "May";
            contact.Byear = "1991";
            contact.Aday = "22";
            contact.Amonth = "May";
            contact.Ayear = "2022";
            contact.Address2 = "Test Address2 upd";
            contact.Phone2 = "Test Phone2 upd";
            contact.Notes = "Test Notes upd";

            app.Contacts.Update(contact);
        }
    }
}
