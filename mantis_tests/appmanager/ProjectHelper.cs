using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Add(ProjectData project)
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            FillNewProjectForm(project);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.XPath("//tbody/tr/td/a")).Count > 0);
            //.Until(d => d.FindElements(By.CssSelector("div.col-md-12.col-xs-12")).Count > 0);
            //System.Threading.Thread.Sleep(3000);
        }

        public void Delete(int index)
        {
            ChoiseProject(index);
            DeleteProject();
        }

        private void DeleteProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            //driver.FindElement(By.XPath("//input[@value='Удалить проект' and @type='submit']")).Click();
            //driver.FindElement(By.XPath("//input[@value='Удалить проект' and @type='submit']")).Click();
        }

        public void ChoiseProject(int index)
        {
            driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
            .FindElements(By.XPath("//tbody/tr/td/a"))[index].Click();
        }

        public void AutoProjMenu(AccountData account)
        {
            //manager.Registration.OpenMainPage();
            manager.Login.Autorization(account);
            manager.Menu.GoToProjectControl();
        }

        public void FillNewProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            //driver.FindElement(By.Name("description")).SendKeys(project.Description);
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public List<ProjectData> CountOfProjects()
        {
            List<ProjectData> list = new List<ProjectData>();
            if (IsElementPresent(By.XPath("//div/table/tbody/tr/td/i")))
            {
                ICollection<IWebElement> elements = driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
                    .FindElements(By.XPath(".//tbody/tr"));
                foreach(IWebElement element in elements)
                {
                    
                    list.Add(new ProjectData(element.FindElement(By.XPath(".//td/a")).Text));
                }
                return list;
                //return driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
                //.FindElements(By.CssSelector("td.center")).Count;
            }
            else
            {
                return list;
            }
        }

        public void Cheking(AccountData account)
        {
            List<ProjectData> list = manager.API.CountOfProject(account);
            if(list.Count == 0)
            {
                ProjectData project = new ProjectData("NewProjectApi");
                manager.API.AddProject(account, project);
            }
        }
    }
}
