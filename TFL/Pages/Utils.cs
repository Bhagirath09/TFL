using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.ComponentModel;

namespace TFL.Pages
{
    public class Utils
    {
        public IWebDriver driver;

        public Utils(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes == null || attributes.Length == 0) throw new NullReferenceException();
            return attributes[0].Description;
        }

        public void EnterText(IWebElement element, string input)
        {
            if (!String.IsNullOrEmpty(element.GetAttribute("value")))
            {
                var clearFromLocation = driver.FindElement(By.CssSelector("#search-filter-form-0 > div > div > a"));
                var clearToLocation = driver.FindElement(By.CssSelector("#search-filter-form-1 > div > a"));
                              
                ClickElement(clearFromLocation);
                element.SendKeys(Keys.Tab);
                ClickElement(clearToLocation);
                element.SendKeys(Keys.Tab);
            }

            ClickElement(element);
            element.SendKeys(input);
        }

        public void ClickElement(IWebElement element) 
        {
            element.Click();
        }

        public void VerifyFromAndToJourneyResults(string expectedFromStation, string expectedToStation)
        {
            var journeyResultHeader = driver.FindElement(By.CssSelector("span[class='jp-results-headline']")).Text;
            var actualFromStation = driver.FindElement(By.CssSelector("div.from-to-wrapper > div:nth-child(1) > span.notranslate > strong")).Text;
            var actualTostation = driver.FindElement(By.CssSelector("div.from-to-wrapper > div:nth-child(2) > span.notranslate > strong")).Text;
            var publicTransportOptionHeader = driver.FindElement(By.CssSelector("*[class='jp-result-transport publictransport clearfix']")).Text;
            var busOnlyOptionHeader = driver.FindElement(By.CssSelector("*[class='jp-result-transport inner-heading clearfix']")).Text;


            journeyResultHeader.Should().Be("Journey results");
            actualFromStation.Should().Contain(expectedFromStation);
            actualTostation.Should().Contain(expectedToStation);            
            publicTransportOptionHeader.Should().Be("Fastest by public transport");
            busOnlyOptionHeader.Should().Be("Bus only");
        }

        public void EnterFromAndToLocations(string fromLocation, string toLocation)
        {
            var from = driver.FindElement(By.CssSelector("#InputFrom"));
            var to = driver.FindElement(By.CssSelector("#InputTo"));

            EnterText(from, fromLocation);
            EnterText(to, toLocation);
        }
    }
}