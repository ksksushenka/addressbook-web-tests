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
            ContactData group = new ContactData("Test FN", "Test LN");
            group.MiddleName = "Test MN";
            group.Nickname = "Test Nickname";
            group.Title = "Test Title";
            group.Company = "Test Company";
            group.Address = "Test Address";
            group.Home = "Test Home";
            group.Mobile = "Test Mobile";
            group.Work = "Test Work";
            group.Fax = "Test Fax";
            group.Email = "Test Email";
            group.Email2 = "Test Email2";
            group.Email3 = "Test Email3";
            group.Homepage = "Test Homepage";
            group.Bday = "13";
            group.Bmonth = "September";
            group.Byear = "1990";
            group.Aday = "15";
            group.Amonth = "September";
            group.Ayear = "2021";
            group.Address2 = "Test Address2";
            group.Phone2 = "Test Phone2";
            group.Notes = "Test Notes";

            app.Contacts.Create(group);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData group = new ContactData("", "");
            group.MiddleName = "";
            group.Nickname = "";
            group.Title = "";
            group.Company = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            group.Email2 = "";
            group.Email3 = "";
            group.Homepage = "";
            group.Bday = "";
            group.Bmonth = "-";
            group.Byear = "";
            group.Aday = "";
            group.Amonth = "-";
            group.Ayear = "";
            group.Address2 = "";
            group.Phone2 = "";
            group.Notes = "";

            app.Contacts.Create(group);
        }
    }
}
