using OpenQA.Selenium;

namespace Tests.POM
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement searchField => _driver.FindElement(By.XPath("//input[@id='search_query_top']"));

        public void NavigateToBasePage()
        {
            _driver.Navigate().GoToUrl("http://www.automationpractice.pl/index.php");
        }

        public void SendTextToSearchInput(string searchText)
        {
            searchField.SendKeys(searchText);
            Thread.Sleep(3000);
        }
    }
}
