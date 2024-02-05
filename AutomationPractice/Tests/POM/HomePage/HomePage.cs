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

        private readonly By searchFieldLocator = By.XPath("//input[@id='search_query_top']");
        private readonly By searchButtonLocator = By.XPath("//button[@name='submit_search']");
        private readonly By allCategoriesLocator = By.XPath("//ul[contains(@class, 'menu-content')]/li");
        private By CategoryByNameLocator(string categoryName) => By.XPath($"//ul[contains(@class,'menu-content')]/li[a='{categoryName}']");
        private By AllSubcategoriesForCategoryLocator(string categoryName) => By.XPath($"//a[.='{categoryName}']/following-sibling::ul[contains(@class,'submenu-container')]//ul/li");
        private By AllSubcategoryTitlesForCategory(string categoryName) => By.XPath($"//a[.='{categoryName}']/following-sibling::ul[contains(@class,'submenu-container')]/li/a");

        public void NavigateToHomePage()
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

        public void VerifyCategoriesNames(List<string> expectedCategoriesNames)
        {
            var actualCategoriesNames = GetAllTexts(allCategoriesLocator);

            _homeAssertions.AreEqual(expectedCategoriesNames, actualCategoriesNames, 
                "One or more categories names were incorrect");
        }

        public void HoverCategory(string categoryName)
        {
            HoverElement(CategoryByNameLocator(categoryName));
        }

        public void VerifySubCategoryNames(string categoryName, List<string> expectedSubCategoriesNames)
        {
            var actualSubCategoriesNames = GetAllTextsWithoutWait(AllSubcategoriesForCategoryLocator(categoryName));
            //exclusion for cases when there are no sub-categories therefore List will have only one empty string inside
            if (string.IsNullOrEmpty(expectedSubCategoriesNames[0]))
            {
                expectedSubCategoriesNames.RemoveAt(0);
            }
            _homeAssertions.AreEqual(expectedSubCategoriesNames, actualSubCategoriesNames,
                $"One or more subcategories names for '{categoryName}' category were incorrect.");
        }

        public void VerifySubCategoryTitles(string categoryName, List<string> expectedSubCategoryTitles)
        {
            var actualSubCategoriesTitles = GetAllTexts(AllSubcategoryTitlesForCategory(categoryName));
           
            _homeAssertions.AreEqual(expectedSubCategoryTitles, actualSubCategoriesTitles,
                $"One or more subcategories names for '{categoryName}' category were incorrect.");
        }
    }
}
