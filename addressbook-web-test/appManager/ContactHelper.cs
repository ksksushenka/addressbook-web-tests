using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Remove(int x)
        {
            SelectContact(x);
            RemoveContact();
            return this;
        }
        public ContactHelper Modify(ContactData newContactData)
        {
            EditContact();
            FillContactData(newContactData);
            ModifyContact();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewContactPage();
            FillContactData(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type2(By.Name("bday"), contact.Bday);
            Type2(By.Name("bmonth"), contact.Bmonth);
            Type2(By.Name("aday"), contact.Aday);
            Type2(By.Name("amonth"), contact.Amonth);
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.CssSelector("input[name=\"update\"]")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index+1) +"]/td/input")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
