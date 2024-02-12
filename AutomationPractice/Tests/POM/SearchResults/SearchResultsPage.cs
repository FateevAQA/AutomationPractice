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
        private By quickViewButtonLocator = By.XPath("//a[@class='quick-view']");
        private By iframeLocator = By.XPath("//iframe[@class='fancybox-iframe']");
        private By ProductByNameLocator(string productName) => By.XPath($"//div[@class='product-container']//a[contains(., '{productName}')]");

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

        public void OpenProductPage(string productName)
        {
            ClickElement(ProductByNameLocator(productName));
        }

        public void OpenQuickViewForProduct(string productName)
        {
            HoverElement(ProductByNameLocator(productName));
            ClickElement(quickViewButtonLocator);
        }

        public void SwitchToModalWindow()
        {
            SwitchToFrame(iframeLocator);
        }

        public void SwitchToDefaultWindow()
        {
            SwitchToDefaultFrame();
        }
    }
}
