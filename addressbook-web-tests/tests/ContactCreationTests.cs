using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Test FN", "Test LN");
            contact.MiddleName = "Test MN";
            contact.Nickname = "Test Nickname";
            contact.Title = "Test Title";
            contact.Company = "Test Company";
            contact.Address = "Test Address";
            contact.Home = "Test Home";
            contact.Mobile = "Test Mobile";
            contact.Work = "Test Work";
            contact.Fax = "Test Fax";
            contact.Email = "Test Email";
            contact.Email2 = "Test Email2";
            contact.Email3 = "Test Email3";
            contact.Homepage = "Test Homepage";
            contact.Bday = "13";
            contact.Bmonth = "September";
            contact.Byear = "1990";
            contact.Aday = "15";
            contact.Amonth = "September";
            contact.Ayear = "2021";
            contact.Address2 = "Test Address2";
            contact.Phone2 = "Test Phone2";
            contact.Notes = "Test Notes";

            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.MiddleName = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";
            contact.Bday = "";
            contact.Bmonth = "-";
            contact.Byear = "";
            contact.Aday = "";
            contact.Amonth = "-";
            contact.Ayear = "";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

            app.Contacts.Create(contact);
        }
    }
}
