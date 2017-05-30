using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeleteTests : TestBase
    {
        [Test]
        public void ProjectDelete()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };

            app.Project.Cheking(account);

            var oldCount = app.Project.CountOfProjects();

            app.Project.Delete(0);

            var newCount = app.Project.CountOfProjects();
            Assert.AreEqual(oldCount - 1, newCount);
        }
    }
}
