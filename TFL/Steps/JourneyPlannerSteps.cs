using TechTalk.SpecFlow;
using TFL.Enums;
using TFL.Pages;

namespace TFL.Steps
{
    [Binding]
    [Scope(Tag = "JourneyPlanner")]
    public class JourneyPlannerSteps : BasePage
    {
        [Given(@"I go to Journey planner on (\w+)")]
        public void GivenIGoToJourneyPlannerOnTfl(Urls url)
        {
            homepage.NavigateToTfl(url);
        }

        [Given(@"I enter valid locations (.*) and (.*)")]
        public void GivenIEnterValidLocationsQueensburyAndCamden(string queensbury, string camden)
        {
            homepage.EnterValidFromAndToLocations(queensbury, camden);
        }

        [When(@"I click on Plan my journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {
            homepage.ClickPlanMyJourney();
        }

        [Then(@"I should see Journey results")]
        public void ThenIShouldSeeJourneyResults()
        {
            homepage.VerifyValidLocationsJourneyResults();
        }

        [Given(@"I enter invalid locations (.*) and (.*)")]
        public void GivenIEnterInvalidLocationsQueensburyUndergroundStationAndIsanpur(string queensbury, string isanpur)
        {
            homepage.EnterInvalidFromAndToLocations(queensbury, isanpur);
        }

        [Then(@"I should see location not maching message Journey results")]
        public void ThenIShouldSeeLocationNotMachingMessageJourneyResults()
        {
            homepage.VerifyLocationNotMatchingMessageDisplayed();
        }

        [Given(@"I enter no locations into the widget")]
        public void GivenIEnterNoLocationsIntoTheWidget()
        {
            //no action required for this step
        }

        [Then(@"I should see required field error messages")]
        public void ThenIShouldSeeRequiredFieldErrorMessages()
        {
            homepage.VerifyRequiredFieldErrorMessages();
        }

        [Given(@"I am on Journey result page on (.*)")]
        public void GivenIAmOnJourneyResultPageOnTfl(Urls url)
        {
            homepage.NavigateToTfl(url);
            homepage.EnterValidFromAndToLocations("Queensbury Underground Station", "Camden Underground Station");
            homepage.ClickPlanMyJourney();
        }

        [When(@"I click on Edit journey button")]
        public void WhenIClickOnEditJourneyButton()
        {
            homepage.ClickEditJourneyButton();
        }

        [When(@"I change stations to (.*) and (.*)")]
        public void WhenIChangeStationsToAnd(string kingsbury, string camden)
        {
            homepage.EnterAmendedLocations(kingsbury, camden);
        }

        [When(@"I click update journey button")]
        public void WhenIClickUpdateJourneyButton()
        {
            homepage.ClickUpdateJourneyButton();
        }

        [Then(@"I should see amended journey")]
        public void ThenIShouldSeeAmendedJourney()
        {
            homepage.VerifyAmendedJourney();
        }

        [When(@"I go back to journey planner widget")]
        public void WhenIGoBackToJourneyPlannerWidget()
        {
            homepage.GoBackToWidget();
        }

        [Then(@"I should see list of recently planned journeys under Recent tab")]
        public void ThenIShouldSeeListOfRecentlyPlannedJourneysUnderRecentTab()
        {
            homepage.VerifyRecentTabDisplaysRecentlyPlannedJourneys();
        }
    }
}