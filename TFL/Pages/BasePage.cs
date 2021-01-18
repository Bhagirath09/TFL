using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TFL.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

        internal HomePage homepage => new HomePage(Driver);
    }
}
