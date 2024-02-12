using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.POM.Base;

namespace Tests.POM.Cart
{
    public class CartPageAssertions : BaseAssertions
    {
        private readonly ScenarioContext _scenarioContext;
        public CartPageAssertions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void VerifyProductDetailsInTheCart(Table expectedProductsInTheCart, List<string> actualUnitPrices,
            List<string> actualTotalPrices, List<string> actualProductNames,
            List<string> actualProductSizes, List<string> actualProductColors, List<string> actualproductQuantity)
        {
            var expectedDetails = expectedProductsInTheCart.Rows;

            Assert.Multiple(() =>
                {
                    for (int i = 0; i < expectedDetails.Count; i++)
                    {
                        var expectedUnitPrice = _scenarioContext.Get<int>(expectedDetails[i]["name"]);
                        var expectedTotalPrice = expectedUnitPrice * int.Parse(expectedDetails[i]["quantity"]);

                        AreEqual(expectedDetails[i]["name"], actualProductNames[i],
                            "Name of the product was incorrect");
                        AreEqual(expectedDetails[i]["size"], actualProductSizes[i],
                            $"Size of the product '{expectedDetails[i]["name"]}' was incorrect");
                        AreEqual(expectedDetails[i]["color"], actualProductColors[i],
                            $"Color of the product '{expectedDetails[i]["name"]}' was incorrect");
                        AreEqual(expectedUnitPrice, int.Parse(actualUnitPrices[i].Trim('$')),
                            $"Unit price of the product '{expectedDetails[i]["name"]}' was incorrect");
                        AreEqual(expectedTotalPrice, int.Parse(actualTotalPrices[i].Trim('$')),
                            $"Total price of the product '{expectedDetails[i]["name"]}' was incorrect");
                        AreEqual(expectedDetails[i]["quantity"], actualproductQuantity[i],
                            $"Quantity of the product '{expectedDetails[i]["name"]}' was incorrect");
                    }
                });

        }
    }
}
