using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupUpdateTests : TestBase
    {
        [Test]
        public void GroupUpdateTest()
        {
            GroupData group = new GroupData("test name upd");
            group.Header = "test header upd";
            group.Footer = "test footer upd";

            app.Groups.Update(group);
        }
    }
}