I have created this framework using below versions:

Selenium WebDriver: 3.14.0
Selenium.WebDriver.ChromeDriver: 87.0.4280.8800
SpecFlow Version: 3.0
Used Test Runner: SpecFlow+Runner
Assertion: FluentAssertions 5.10.3
Visual Studio Version: VS 2019
.NET Framework: 4.7.2
Project Format of the SpecFlow project: Classic project format using packages.config
Test Execution Method: Visual Studio Test Explorer 

This is a PageObjectModel framework where feature files can be found under Features package. All the pages like BasePage, HomePage etc.. are under Pages package. Stepdef can be found under Steps folder.
For url data I have created Enum class Urls under Enums folder.

Run settings like parallel test run (testThreadCount), reRun failed test (stopAfterFailures) are under default.srprofile file.  

I have created following 5 tests for Journey Planner feature.

1) Verify Valid Journey
   In order to verify valid journey, I am asserting that page header is "Journey results", From and To stations names are there, Fasted by public transport and Bus only options are there in result.

2) Verify Invalid Journey
   In order to verify invalid journey, I have used disambiguation message for assertion because search result was giving options for any invalid location.

3) Verify Invalid Journey - no location
   Verification for journey was easy as site is displaying error message when no location is entered.

4) Verify journey can be amended by using Edit journey
   To verify Edit journey feature, first I have used valid journey tests steps to get the journey result. Then edited journey by entering new from location and finally asserting that amended journey as new location.

5) Verify recent journey list
   In order to test Recent feature, I have used valid journey tests steps to get the journey result. Then came back to widget to see list in Recent tab. Asserting that Recent tab list is not empty. 