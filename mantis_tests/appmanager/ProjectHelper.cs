using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Add(ProjectData project)
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            FillNewProjectForm(project);
            System.Threading.Thread.Sleep(3000);
        }

        public void Delete(int index)
        {
            ChoiseProject(index);
            DeleteProject();
        }

        private void DeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект' and @type='submit']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект' and @type='submit']")).Click();
        }

        public void ChoiseProject(int index)
        {
            driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
            .FindElements(By.XPath("//tbody/tr/td/a"))[index].Click();
        }

        public void AutoProjMenu(AccountData account)
        {
            manager.Registration.OpenMainPage();
            manager.Login.Autorization(account);
            manager.Menu.GoToProjectControl();
        }

        public void FillNewProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public int CountOfProjects()
        {
            if (IsElementPresent(By.XPath("//div/table/tbody/tr/td/i")))
            {
                return driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
                .FindElements(By.CssSelector("td.center")).Count;
            }
            else
            {
                return 0;
            }
        }

        public void Cheking(AccountData account)
        {
            AutoProjMenu(account);
           if (!IsElementPresent(By.XPath("//div/table/tbody/tr/td/i")))
                {
                    ProjectData project = new ProjectData()
                    {
                        Name = "new1",
                        Description = "rew1",
                    };

                    Add(project);
                }
        }
    }
}
