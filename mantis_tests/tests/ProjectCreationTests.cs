using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };

            ProjectData project = new ProjectData()
            {
                Name = "admin6",
                Description = "What is love6",
            };

            app.Project.AutoProjMenu(account);


            var oldCount = app.Project.CountOfProjects();

            app.Project.Add(project);

            var newCount = app.Project.CountOfProjects();
            Assert.AreEqual(oldCount + 1, newCount);
        }
    }
}
