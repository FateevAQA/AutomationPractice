using TechTalk.SpecFlow;
using Tests.POM.Cart;

namespace Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private readonly CartPage _cartPage;

        public CartSteps(CartPage cartPage)
        {
            _cartPage = cartPage;
        }

        [Then(@"I see correct summary about added products")]
        public void ThenISeeCorrectSummaryAboutAddedProductsDontForgetToCountTotalls(Table expectedProductsDetails) =>
            _cartPage.VerifyProductDetailsInTheCart(expectedProductsDetails);

    }
}
