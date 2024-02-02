using OpenQA.Selenium;
using Tests.Helpers;
using Tests.POM.Base;

namespace Tests.POM.HomePage
{
    public class HomePage : BasePage
    {
        private readonly HomePageAssertions _homeAssertions;

        public HomePage(IWebDriver driver, WaitHelper wait, HomePageAssertions homeAssertions) : base(driver, wait)
        {
            _homeAssertions = homeAssertions;
        }

        private By searchFieldLocator = By.XPath("//input[@id='search_query_top']");
        private By searchButtonLocator = By.XPath("//button[@name='submit_search']");

        public void NavigateToBasePage()
        {
            NavigateToURL("http://www.automationpractice.pl/index.php");
        }

        public void SendTextToSearchInput(string searchText)
        {
            SendKeys(searchFieldLocator, searchText);
        }

        public void ClickOnSearchButton()
        {
            ClickElement(searchButtonLocator);
        }
    }
}
