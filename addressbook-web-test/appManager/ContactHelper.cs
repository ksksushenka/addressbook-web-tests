using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public string baseURL;
        public ContactHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                Thread.Sleep(200);
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    var td = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(td[2].Text, td[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }
        public ContactHelper RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            return this;
        }
        public ContactHelper Remove(int x)
        {
            SelectContactForEdit(x);
            RemoveContact();
            return this;
        }
        public ContactHelper Remove(ContactData contact)
        {
            SelectContactForEdit(contact.Id);
            RemoveContact();
            return this;
        }
        public ContactHelper Modify(int p, ContactData newContactData)
        {
            EditContact(p);
            FillContactData(newContactData);
            ModifyContact();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(ContactData oldContactData, ContactData newContactData)
        {
            EditContact(oldContactData.Id);
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
            contactCache = null;
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper EditContact(string id)
        {
            IList<IWebElement> lines = driver.FindElements(By.Name("entry"));
            foreach (IWebElement line in lines)
            {
                string idForm = line.FindElement(By.XPath("td[1]")).FindElement(By.TagName("input")).GetAttribute("id");
                if (idForm == id)
                {
                    line.FindElement(By.XPath("td[8]")).Click();
                    break;
                }
            }
            return this;
        }
        public ContactHelper DetailContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td[7]/a/img")).Click();
            return this;
        }
        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.CssSelector("input[name=\"update\"]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContactForEdit(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ (index + 2) +"]/td/input")).Click();
            return this;
        }
        public ContactHelper SelectContactForEdit(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCache = null;
            return this;
        }
        public ContactHelper CreateContactIfElementNotPresent()
        {
            if (driver.Url == baseURL + "/addressbook/"
               && !IsElementPresent(By.Name("selected[]")))
            {
                Create(new ContactData("firstname", "lastname"));
            }
            return this;
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }
        public ContactData GetContactInformationFromEditForm(int x)
        {
            manager.Navigator.GoToHomePage();
            EditContact(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string modilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).FindElement(By.XPath("option[1]")).Text;
            string bmonth = driver.FindElement(By.Name("bmonth")).FindElement(By.XPath("option[1]")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).FindElement(By.XPath("option[1]")).Text;
            string amonth = driver.FindElement(By.Name("amonth")).FindElement(By.XPath("option[1]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Nickname = nickName,
                Title = title,
                Company = company,
                Address = address,
                Home = homePhone,
                Mobile = modilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }
        public ContactData GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            DetailContact(0);
            string data = GetDetailData();
            return new ContactData(null, null)
            {
                View = data
            };
        }
        private string GetDetailData()
        {
            return driver.FindElement(By.Id("content")).Text;
        }
        public ContactHelper ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            return this;
        }
        public ContactHelper SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
            return this;
        }
        public ContactHelper SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
            return this;
        }
        public ContactHelper CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }
        public ContactHelper SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
            return this;
        }
        public ContactHelper CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
            return this;
        }
    }
}

