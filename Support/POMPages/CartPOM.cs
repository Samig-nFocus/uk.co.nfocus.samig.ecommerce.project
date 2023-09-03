using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class CartPOM
    {
        private IWebDriver _driver;

        // constructor
        public CartPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators for coupon field and coupon button
        private IWebElement _couponField => _driver.FindElement(By.CssSelector("#coupon_code"));
        private IWebElement _applyCouponButton => _driver.FindElement
            (By.CssSelector("button[name='apply_coupon']"));

        // locators for subtotal field and discount field using table rows
        private IWebElement _discountField => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement
            (By.CssSelector("tr.cart-discount span")));
        private IWebElement _subtotalField => _driver.FindElement
            (By.CssSelector("tr.cart-subtotal bdi"));

        // locator for total field using table rows
        private IWebElement _totalField => _driver.FindElement
            (By.CssSelector("tr.order-total bdi"));

        // locator for shipping cost us field using label and span elements
        private IWebElement _shippingCostField => _driver.FindElement
            (By.CssSelector("label span.woocommerce-Price-amount.amount bdi"));

        // locator for proceed to checkout button
        private IWebElement _proceedToCheckoutButton => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement
            (By.CssSelector("a[class = 'checkout-button button alt wc-forward']")));

        // setter for coupon code
        public CartPOM SetCouponCode(string couponCode)
        {
            _couponField.Click();
            _couponField.Clear();
            _couponField.SendKeys(couponCode);
            return this;
        }
        // method to apply coupon
        public void ApplyCoupon()
        {
            _applyCouponButton.Click();
        }
        // method to enter coupon code and press apply coupon
        public void EnterAndApplyCouponCode(string couponCode)
        {
            SetCouponCode(couponCode);
            ApplyCoupon();
        }

        // getters for discount value, subtotal value, shipping cost value and total value
        // replaces £ with empty string
        public decimal DiscountValue()
        {
            return decimal.Parse(_discountField.Text.Replace("£", ""));
        }
        public decimal SubtotalValue()
        {
            return decimal.Parse(_subtotalField.Text.Replace("£", ""));
        }
        public decimal ShippingCostValue()
        {
            return decimal.Parse(_shippingCostField.Text.Replace("£", ""));
        }
        public decimal TotalValue()
        {
            return decimal.Parse(_totalField.Text.Replace("£", ""));
        }

        // method to proceed to checkout
        public void ProceedToCheckout()
        {
            _proceedToCheckoutButton.Click();
        }


    }
}
