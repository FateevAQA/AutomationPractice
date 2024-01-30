using OpenQA.Selenium;
using Tests.POM;

namespace Tests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public SearchSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
        }

        [Given(@"I open Automationpractice site")]
        public void GivenIOpenAutomationpracticeSite()
        {
            _homePage.NavigateToBasePage();
        }

        [When(@"I search for '([^']*)'")]
        public void WhenISearchFor(string searchtext)
        {
            _homePage.SendTextToSearchInput(searchtext);
        }
    }
}
