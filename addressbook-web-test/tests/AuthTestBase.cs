using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            //driver = new FirefoxDriver();
            //baseURL = "https://www.google.com/";
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
