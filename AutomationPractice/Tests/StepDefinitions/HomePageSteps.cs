using TechTalk.SpecFlow;
using Tests.POM.HomePage;

namespace Tests.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly HomePage _homePage;

        public HomePageSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [StepArgumentTransformation]
        public List<string> TransformToListOfString(string commaSeparatedList) =>
            commaSeparatedList.Split(",").ToList();

        [Then(@"I see categories names are '([^']*)'")]
        public void ThenISeeCategoriesNamesAre(List<string> expectedCategoreisNames) =>
            _homePage.VerifyCategoriesNames(expectedCategoreisNames);

        [When(@"I hover '([^']*)' category")]
        public void WhenIHoverCategory(string categoryName) =>
            _homePage.HoverCategory(categoryName);

        [Then(@"I see next subcategories '([^']*)' for the '([^']*)' category")]
        public void ThenISeeNextSubcategoriesForCategory(List<string> expectedSubcategoriesNames, string categoryName) =>
           _homePage.VerifySubCategoryNames(categoryName, expectedSubcategoriesNames);


        [Then(@"I see next subcategories titles '([^']*)' for the '([^']*)' category")]
        public void ThenISeeNextSubcategoriesTitlesForTheCategory(List<string> expectedSubcategoriesTitles, string categoryName) =>
           _homePage.VerifySubCategoryTitles(categoryName, expectedSubcategoriesTitles);


    }
}
