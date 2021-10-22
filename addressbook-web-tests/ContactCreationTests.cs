using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewContactPage();
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
            group.Ayear = "2020";
            group.Address2 = "Test Address2";
            group.Phone2 = "Test Phone2";
            group.Notes = "Test Notes";
            FillContactData(group);
            SubmitContactCreation();
            ReturnToHomePage();
            LogOut();
        }
    }
}
