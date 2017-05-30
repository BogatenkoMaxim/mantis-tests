using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagmentMenuHelper : HelperBase
    {
        public ManagmentMenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToProjectControl()
        {
            driver.FindElement(By.LinkText("управление")).Click();
            //driver.FindElements(By.CssSelector("span.menu-text"))[6].Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
