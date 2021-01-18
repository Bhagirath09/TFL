using OpenQA.Selenium;
using TFL.Enums;
using FluentAssertions;

namespace TFL.Pages
{
    public class HomePage : Utils
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateToTfl(Urls url) 
        {
            string newUrl = GetEnumDescription(url);
            driver.Navigate().GoToUrl(newUrl);

            //If Coockie Policy pop-up appears accept it
            var cookiePolicyPopup = driver.FindElement(By.CssSelector("*[class='cb-cookiebanner'][lang='en']"));

            if (cookiePolicyPopup.Displayed)
            {
                var acceptAllCookiesPopupButton = driver.FindElement(By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll > strong"));             
                ClickElement(acceptAllCookiesPopupButton);

                var coockieSettingDoneButton = driver.FindElement(By.CssSelector("a[onclick^='endCookieProcess']"));
                ClickElement(coockieSettingDoneButton);
            }
        }

        public void EnterValidFromAndToLocations(string queensbury, string camden)
        {
            EnterFromAndToLocations(queensbury, camden);
        }

        public void ClickPlanMyJourney()
        {
            var planMyJourneyButton = driver.FindElement(By.CssSelector("#plan-journey-button"));
            ClickElement(planMyJourneyButton);
        }

        public void VerifyValidLocationsJourneyResults()
        {
            string expectedFromStation = "Queensbury";
            string expectedToStation = "Camden";
            VerifyFromAndToJourneyResults(expectedFromStation, expectedToStation);
        }

        public void EnterInvalidFromAndToLocations(string queensbury, string isanpur)
        {
            EnterFromAndToLocations(queensbury, isanpur);
        }

        public void VerifyLocationNotMatchingMessageDisplayed() 
        {
            var disambiguationMessage = driver.FindElement(By.CssSelector("*[class='info-message disambiguation']")).Text;
            disambiguationMessage.Should().Be("We found more than one location matching 'isanpur'");
        }

        public void VerifyRequiredFieldErrorMessages()
        { 
            var fromFieldErrorMessage = driver.FindElement(By.CssSelector("#InputFrom-error")).Text;
            var toFieldErrorMessage = driver.FindElement(By.CssSelector("#InputTo-error")).Text;

            fromFieldErrorMessage.Should().Be("The From field is required.");
            toFieldErrorMessage.Should().Be("The To field is required.");
        }

        public void ClickEditJourneyButton() 
        {
            var editJourneyButton = driver.FindElement(By.CssSelector("*[class='edit-journey'] > span"));
            ClickElement(editJourneyButton);
        }

        public void EnterAmendedLocations(string kingsbury, string euston)
        {
            EnterFromAndToLocations(kingsbury, euston);
        }

        public void ClickUpdateJourneyButton()
        { 
            var updateJourneyButton = driver.FindElement(By.CssSelector("#plan-journey-button"));
            ClickElement(updateJourneyButton);
        }

        public void VerifyAmendedJourney()
        {
            string expectedFromStation = "Kingsbury";
            string expectedToStation = "Camden";
            VerifyFromAndToJourneyResults(expectedFromStation, expectedToStation);
        }

        public void GoBackToWidget()
        {
            var planAJourney = driver.FindElement(By.CssSelector("*[class='breadcrumbs clearfix'] a[href*='plan-a-journey']"));
            ClickElement(planAJourney);
        }

        public void VerifyRecentTabDisplaysRecentlyPlannedJourneys()
        {
            var recentlyPlannedJourneyList = driver.FindElements(By.CssSelector("#jp-recent-content-jp-"));
            recentlyPlannedJourneyList.Should().NotBeEmpty();
        }
    }
}
