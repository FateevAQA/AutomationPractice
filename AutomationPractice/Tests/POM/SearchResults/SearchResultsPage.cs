using OpenQA.Selenium;
using Tests.Helpers;
using Tests.POM.Base;


namespace Tests.POM.SearchResults
{
    public class SearchResultsPage : BasePage
    {
        private readonly SearchResultsAssertions _searchAssertions;

        public SearchResultsPage(IWebDriver driver, WaitHelper wait, SearchResultsAssertions searchAssertions) : base(driver, wait)
        {
            _searchAssertions = searchAssertions;
        }

        private By numberOfResultsFoundLocator = By.XPath("//span[@class='heading-counter']");
        private By allResultsShownLocator = By.XPath("//div[@class='product-container']");

        public void VerifyNumberOfTotalResultsFound(string expectedNumberOfResults)
        {
            var actualNumberOfresults = GetText(numberOfResultsFoundLocator);

            _searchAssertions.StringContains(actualNumberOfresults, expectedNumberOfResults, $"Total number of the results found was incorrect. " +
                $"Expected string: '{expectedNumberOfResults}', was not part of the actual result: '{actualNumberOfresults}'");
        }

        public void VerifyTotalNumberOfShownSearchResultItems(int expectedNumberOfShownItems)
        {
            var totalNumberOfShownItems = GetElements(allResultsShownLocator).Count();

            _searchAssertions.AreEqual(expectedNumberOfShownItems, totalNumberOfShownItems, 
                "Total number of shown search results items was incorrect");
        }
    }
}
