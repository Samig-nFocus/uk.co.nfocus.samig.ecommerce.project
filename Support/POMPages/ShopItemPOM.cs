using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class ShopItemPOM
    {
        private IWebDriver _driver;

        // constructor
        public ShopItemPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locator for view cart button
        private IWebElement _viewCartButton =>
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.LinkText("View cart")));

        // method to add item to cart
        public void AddItemToCart(string itemName)
        {
            // string locator of add to cart button using <a> element aria-label
            // contains (*=) parameterised item (itemName)
            string itemLabelLocator = $"a[aria-label*='Add “{itemName}” to your cart']";

            // webdriver instance finds and clicks add to cart button of the parameterised item
            var _addToCartButton = new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until(drv => drv.FindElement(By.CssSelector(itemLabelLocator)));
            _addToCartButton.Click();
        }

        // method to view item in cart
        public void ViewCart()
        {
            _viewCartButton.Click();
        }
    }
}
