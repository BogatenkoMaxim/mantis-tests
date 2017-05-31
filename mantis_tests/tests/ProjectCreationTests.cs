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

            ProjectData project = new ProjectData("admin7");

            app.Project.AutoProjMenu(account);


            List<ProjectData> oldCount = app.Project.CountOfProjects();

            app.Project.Add(project);

            List<ProjectData> newCount = app.Project.CountOfProjects();

            Assert.AreEqual(oldCount.Count + 1, newCount.Count);
            oldCount.Add(project);
            oldCount.Sort();
            newCount.Sort();
            Assert.AreEqual(oldCount, newCount);
        }
    }
}
