﻿using System;
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

            List<ProjectData> oldCount = app.API.CountOfProject(account);

            app.Project.AutoProjMenu(account);
            app.Project.Delete(0);

            List<ProjectData> newCount = app.API.CountOfProject(account);
            Assert.AreEqual(oldCount.Count - 1, newCount.Count);

            oldCount.RemoveAt(0);
            oldCount.Sort();
            newCount.Sort();
            Assert.AreEqual(oldCount, newCount);
        }
    }
}
