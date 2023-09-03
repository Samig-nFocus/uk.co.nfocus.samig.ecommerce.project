using OpenQA.Selenium;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class NavigationPOM
    {
        private IWebDriver _driver;

        // constructor
        public NavigationPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators
        private IWebElement _homeButton => _driver.FindElement(By.LinkText("Home"));
        private IWebElement _shopButton => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement _cartButton => _driver.FindElement(By.LinkText("Cart"));
        private IWebElement _checkoutButton => _driver.FindElement(By.LinkText("Checkout"));
        private IWebElement _myaccountButton => _driver.FindElement(By.LinkText("My account"));
        private IWebElement _blogButton => _driver.FindElement(By.LinkText("Blog"));

        // method to navigate to pages
        public void NavigateTo(string pageName)
        {
            switch (pageName)
            {
                case "Home":
                    _homeButton.Click();
                    break;
                case "Shop":
                    _shopButton.Click();
                    break;
                case "Cart":
                    _cartButton.Click();
                    break;
                case "Checkout":
                    _checkoutButton.Click();
                    break;
                case "My Account":
                    _myaccountButton.Click();
                    break;
                case "Blog":
                    _blogButton.Click();
                    break;
                default:
                    break;
            }

        }
    }
}
