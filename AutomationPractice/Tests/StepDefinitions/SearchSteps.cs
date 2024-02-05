using TechTalk.SpecFlow;
using Tests.POM.HomePage;
using Tests.POM.SearchResults;

namespace Tests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {      
        private readonly HomePage _homePage;
        private readonly SearchResultsPage _searchPage;

        public SearchSteps(HomePage homePage, SearchResultsPage searchPage)
        {
            _homePage = homePage;
            _searchPage = searchPage;
        }

        [Given(@"I open AutomationPractice site")]
        public void GivenIOpenAutomationpracticeSite() =>
            _homePage.NavigateToHomePage();

        [Then(@"Results page have '([^']*)' results")]
        public void ThenResultsPageHaveResults(string expectedNumberOfResults) =>
            _searchPage.VerifyNumberOfTotalResultsFound(expectedNumberOfResults);

        [When(@"I search for '([^']*)'")]
        public void WhenISearchFor(string searchtext)
        {
            _homePage.SendTextToSearchInput(searchtext);
            _homePage.ClickOnSearchButton();
        }

        [Then(@"I see that total number of shown results is '([^']*)'")]
        public void ThenISeeThatTotalNumberOfShownResultsIs(int expectedNumberOfResults)
        {
            _searchPage.VerifyTotalNumberOfShownSearchResultItems(expectedNumberOfResults);
            _searchPage.VerifyNumberOfTotalResultsFound(expectedNumberOfResults.ToString());
        }



    }
}
