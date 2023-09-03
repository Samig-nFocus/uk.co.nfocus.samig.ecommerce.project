using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class OrderPOM
    {
        private IWebDriver _driver;

        // constructor
        public OrderPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators 
        private IWebElement _generatedOrderNumber => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.CssSelector("li.woocommerce-order-overview__order strong")));
        private IWebElement _ordersButton => _driver.FindElement(By.LinkText("Orders"));
        private IWebElement _firstOrderNumberFromOrdersPage => _driver.FindElement
            (By.CssSelector("td.woocommerce-orders-table__cell-order-number:first-child a"));

        // getter for the newly generated Order Number after placing order
        public int GetGeneratedOrderNumber()
        {
            return int.Parse(_generatedOrderNumber.Text);
        }
        // getter for the first Order Number in Orders Page
        public int GetFirstOrderNumberFromOrderPage()
        {
            return int.Parse(_firstOrderNumberFromOrdersPage.Text.Replace("#", ""));
        }

        // method to navigate to orders page
        public void ViewOrders()
        {
            _ordersButton.Click();
        }
    }
}
    

