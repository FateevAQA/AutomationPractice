using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Tests.Helpers;

namespace Tests.POM.Base
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;

        protected BasePage(IWebDriver driver, WaitHelper wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public string GetText(By elementLocator)
        {
            _wait.WaitForElement(elementLocator);
            return _driver.FindElement(elementLocator).Text;
        }

        public void SendKeys(By elementLocator, string textToSend)
        {
            _wait.WaitForElement(elementLocator);
            _driver.FindElement(elementLocator).SendKeys(textToSend);
        }

        public void NavigateToURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By elementLocator)
        {
            _wait.WaitForElement(elementLocator);
            _driver.FindElement(elementLocator).Click();
        }

        public ReadOnlyCollection<IWebElement> GetElements(By elementLocator)
        {
            _wait.WaitForElement(elementLocator);
            return _driver.FindElements(elementLocator);
        }
    }
}
