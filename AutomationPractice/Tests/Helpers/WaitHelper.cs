using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Tests.Helpers
{
    public class WaitHelper
    {
        private readonly WebDriverWait _wait;
        private readonly IWebDriver _webDriver;

        public WaitHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(new SystemClock(),
                _webDriver,
                TimeSpan.FromSeconds(10),
                sleepInterval: TimeSpan.FromMilliseconds(100)); ;
        }

        public IWebElement WaitForElement(By elementLocator, int timeout = 5)
        {
            SetUpWait(timeout);

            var element = _wait.Until(ExpectedConditions.ElementExists(elementLocator));
            element = _wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            return element;
        }

        private void SetUpWait(int timeout)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
        }
        public void WaitForJavaScriptToLoad(int delay = 10)
        {
                var jsDriver = (IJavaScriptExecutor)_webDriver;

                while (delay > 0)
                {
                    Thread.Sleep(300);
                    var jquery = (bool)jsDriver
                        .ExecuteScript("return window.jQuery == undefined");
                    if (jquery)
                    {
                        break;
                    }
                    var ajaxIsComplete = (bool)jsDriver
                        .ExecuteScript("return window.jQuery.active == 0");
                    if (ajaxIsComplete)
                    {
                        break;
                    }
                    delay--;     
            }
        }

    }
}
