using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(6)]

namespace Tests.Drivers
{
    [Binding]
    public class WebDriverFactory
    {
        private IObjectContainer _objectContainer;
        private ChromeDriver _driver;

        public WebDriverFactory(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments(new[] {
                "--start-maximized",
                "--headless",
                 });

            _driver = new ChromeDriver(_chromeOptions);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
