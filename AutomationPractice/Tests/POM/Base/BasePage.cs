using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using Tests.Helpers;

namespace Tests.POM.Base
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;
        private readonly Actions _actions;

        protected BasePage(IWebDriver driver, WaitHelper wait)
        {
            _driver = driver;
            _wait = wait;
            _actions = new Actions(_driver);
        }

        public string GetText(By elementLocator)
        {
            _wait.WaitForElement(elementLocator);
            return _driver.FindElement(elementLocator).Text;
        }

        public List<string> GetAllTexts(By elementsLocator)
        {
            return GetElements(elementsLocator).Select(element => element.Text).ToList();
        }

        public List<string>? GetAllTextsWithoutWait(By elementsLocator)
        {
            return GetElementsWithoutWait(elementsLocator).Select(element => element.Text).ToList();
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

        public IWebElement GetElement(By elementLocator)
        {
            _wait.WaitForElement(elementLocator);
            return _driver.FindElement(elementLocator);
        }

        public ReadOnlyCollection<IWebElement> GetElements(By elementsLocator)
        {
            _wait.WaitForElement(elementsLocator);
            return _driver.FindElements(elementsLocator);
        }

        public ReadOnlyCollection<IWebElement> GetElementsWithoutWait(By elementsLocator)
        {
            return _driver.FindElements(elementsLocator);
        }

        public void HoverElement(By elementLocator)
        {
            _actions.MoveToElement(GetElement(elementLocator)).Perform();
        }
    }
}
