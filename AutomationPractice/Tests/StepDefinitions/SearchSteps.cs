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

        [Given(@"I search for '([^']*)'")]
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

        [Given(@"I open '([^']*)' product page")]
        public void GivenIOpenProductPage(string productName) =>
            _searchPage.OpenProductPage(productName);

        [Given(@"I open ""Quick View"" for '([^']*)' product")]
        public void GivenIOpenForProduct(string productName) =>
            _searchPage.OpenQuickViewForProduct(productName);

        //steps to switch to specific frame needed because modal window is placed inside of separate 'iframe' in DOM
        //and to make WebDriver work with that frame- we need to explicitly switch to it.
        //And then Switch back to Default frame to continue work with main window.
        [Given(@"I switch to modal window frame")]
        public void GivenISwitchToModalWindowFrame() =>
            _searchPage.SwitchToModalWindow();

        [Given(@"I switch back to default frame")]
        public void GivenISwitchBackToDefaultFrame() =>
            _searchPage.SwitchToDefaultFrame();


    }
}
