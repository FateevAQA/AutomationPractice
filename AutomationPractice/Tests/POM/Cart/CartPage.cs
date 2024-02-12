using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.Helpers;
using Tests.POM.Base;

namespace Tests.POM.Cart
{
    public class CartPage : BasePage
    {
        private readonly CartPageAssertions _cartAssertions;

        private By allUnitPricesLocator = By.XPath("//li[@class='price' or @class='price special-price']");
        private By allTotalPricesLocator = By.XPath("//td//span[@class='price']");
        private By allProductsNamesLocator = By.XPath("//td/p[@class='product-name']");
        private By allProductsDetailsLocator = By.XPath("//td//small[not(@class)]");
        private By allProductsQuantityLocator = By.XPath("//input[contains(@class,'cart_quantity_input')]");
        public CartPage(IWebDriver driver, WaitHelper wait, CartPageAssertions cartAssertions) : base(driver, wait)
        {
            _cartAssertions = cartAssertions;
        }

        public void VerifyProductDetailsInTheCart(Table expectedProductsInTheCart)
        {
            var actualUnitPrices = GetAllTexts(allUnitPricesLocator);
            var actualTotalPrices = GetAllTexts(allTotalPricesLocator);
            var actualProductNames = GetAllTexts(allProductsNamesLocator);
            var actualproductQuantity = GetAllValues(allProductsQuantityLocator);
            var actualProductSizes = ExtractSizes();
            var actualProductColors = ExtractColors();

            _cartAssertions.VerifyProductDetailsInTheCart(expectedProductsInTheCart, actualUnitPrices, 
                actualTotalPrices, actualProductNames, actualProductSizes, actualProductColors, actualproductQuantity) ;
        }


        //in Cart details of product are put into one string like 'Size : L, Color : Yellow'.
        //Methods ExtractSizes and ExtractColors are needed to get specific values of Size and Color and trim all extra text
        private List<string> ExtractSizes()
        {
            var sizes = new List<string>();
            var fullDescriptions = GetAllTexts(allProductsDetailsLocator);

            foreach (string description in fullDescriptions)
            {
                var parts = description.Split(',');
                foreach (string part in parts)
                {
                    if (part.Trim().StartsWith("Size : "))
                    {
                        var size = part.Trim().Replace("Size : ", "");
                        sizes.Add(size);
                    }
                }
            }
            return sizes;
        }

        private List<string> ExtractColors()
        {
            var colors = new List<string>();
            var fullDescriptions = GetAllTexts(allProductsDetailsLocator);

            foreach (string description in fullDescriptions)
            {
                var parts = description.Split(',');
                foreach (string part in parts)
                {
                    if (part.Trim().StartsWith("Color : "))
                    {
                        var color = part.Trim().Replace("Color : ", "");
                        colors.Add(color);
                    }
                }
            }
            return colors;
        }
    }
}
