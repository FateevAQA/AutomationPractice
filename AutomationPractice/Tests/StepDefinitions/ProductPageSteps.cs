using TechTalk.SpecFlow;
using Tests.POM.Product;

namespace Tests.StepDefinitions
{
    [Binding]
    public class ProductPageSteps
    {

        private readonly ProductPage _productPage;
        private readonly ScenarioContext _scenarioContext;

        public ProductPageSteps(ProductPage productPage, ScenarioContext scenarioContext)
        {
            _productPage = productPage;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I select next attributes of the product")]
        public void GivenISelectNextCharacteristicsOfTheProduct(Table productAttributes) =>
            _productPage.SelectProductAttributes(productAttributes.Rows[0]);

        [Given(@"I memorize price of '([^']*)'")]
        public void GivenIMemorizePriceOf(string productName)
        {
            var priceOfproduct = _productPage.GetProductPrice();
            _scenarioContext.Add(productName, priceOfproduct);
        }

        [Given(@"I add product to cart")]
        public void GivenIAddProductToCart() =>
            _productPage.AddProductToCart();

        [Given(@"I choose to '([^']*)'")]
        [When(@"I choose to '([^']*)'")]
        public void GivenISelectTo(string buttonName) =>
            _productPage.ClickButtonInModal(buttonName);

    }
}
