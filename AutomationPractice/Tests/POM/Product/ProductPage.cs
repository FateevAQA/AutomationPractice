using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.Helpers;
using Tests.POM.Base;

namespace Tests.POM.Product
{
    public class ProductPage : BasePage
    {
        private readonly ProductPageAssertions _productAssertions;

        public ProductPage(IWebDriver driver, WaitHelper wait, ProductPageAssertions productAssertions) : base(driver, wait)
        {
            _productAssertions = productAssertions;
        }

        private By quantityInputLocator = By.XPath("//input[@id='quantity_wanted']");
        private By addQuantityButtonLocator = By.XPath("//span/i[@class='icon-plus']");
        private By dropdownLocator = By.XPath("//div[@class='selector']");
        private By productPriceLocator = By.XPath("//span[@id='our_price_display']");
        private By addToCartButtonLocator = By.XPath("//button[@name='Submit']");
        private By OptionInDropdownLocator(string optionName) => By.XPath($"//option[.='{optionName}']");
        private By ColorSelectLocator(string color) => By.XPath($"//a[@name='{color}']");
        private By ButtonInModalByName(string buttonName) => By.XPath($"//*[contains(@title,'{buttonName}')]");

        public void SelectProductAttributes(TableRow productAttributes)
        {
            SelectColor(productAttributes["color"]);
            SelectSizeOptionInDropdown(productAttributes["size"]);
            AddQuantityUsingPlusButton(int.Parse(productAttributes["quantity"]));
        }

        public void SendTextToQuantityInput(string quantity)
        {
            SendKeys(quantityInputLocator, quantity);
        }

        public void AddQuantityUsingPlusButton(int quantity)
        {
            for (int i = 1; i < quantity; i++)
            {
                ClickElement(addQuantityButtonLocator);
            }
        }

        public void SelectSizeOptionInDropdown(string optionName)
        {
            ClickElement(OptionInDropdownLocator(optionName));
        }

        public void SelectColor(string color)
        {
            ClickElement(ColorSelectLocator(color));
        }

        public int GetProductPrice()
        {
            return int.Parse(GetText(productPriceLocator).Replace("$", ""));
        }

        public void AddProductToCart()
        {
            ClickElement(addToCartButtonLocator);
        }

        public void ClickButtonInModal(string buttonName)
        {
            ClickElement(ButtonInModalByName(buttonName));
        }

    }
}
