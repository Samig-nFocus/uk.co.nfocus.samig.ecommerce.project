using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class BillingPOM
    {
        private IWebDriver _driver;

        // constructor 
        public BillingPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators
        private IWebElement _nameField => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement _lastnameField => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement _companyNameField => _driver.FindElement(By.Id("billing_company"));
        private IWebElement _streetAddressField => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement _cityField => _driver.FindElement(By.Id("billing_city"));
        private IWebElement _postcodeField => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement _phoneField => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement _emailField => _driver.FindElement(By.Id("billing_email"));
        private IWebElement _chequePaymentOption => _driver.FindElement(By.CssSelector("label[for='payment_method_cheque']"));
        private IWebElement _cashPaymentOption => _driver.FindElement(By.CssSelector("label[for='payment_method_cod']"));
        private IWebElement _placeOrderButton => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.CssSelector("#place_order")));

        // setters
        public BillingPOM SetName(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
            return this;

        }
        public BillingPOM SetLastname(string lastname)
        {
            _lastnameField.Clear();
            _lastnameField.SendKeys(lastname);
            return this;
        }
        public BillingPOM SetCompany(string company)
        {
            _companyNameField.Clear();
            _companyNameField.SendKeys(company);
            return this;
        }
        public BillingPOM SetAddress(string address)
        {
            _streetAddressField.Clear();
            _streetAddressField.SendKeys(address);
            return this;
        }
        public BillingPOM SetCity(string city)
        {
            _cityField.Clear();
            _cityField.SendKeys(city);
            return this;
        }
        public BillingPOM SetPostcode(string postcode)
        {
            _postcodeField.Clear();
            _postcodeField.SendKeys(postcode);
            return this;
        }
        public BillingPOM SetPhone(string phone)
        {
            _phoneField.Clear();
            _phoneField.SendKeys(phone);
            return this;
        }
        public BillingPOM SetEmail(string email)
        {
            _emailField.Clear();
            _emailField.SendKeys(email);
            return this;
        }
        // setter for payment option with error handling
        public BillingPOM SetPaymentOption(string paymentOption)
        {
            if (paymentOption == "Cheque Payment")
            {
                try
                {
                    _chequePaymentOption.Click();
                }

                catch
                {
                    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    Console.WriteLine("Selecting Cheque Payment Option...");
                }

            }
            else
            {
                try
                {
                    _cashPaymentOption.Click();
                }

                catch
                {
                    var wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    Console.WriteLine("Selecting Cash Payment Option...");
                }
            }

            return this;
        }

        // method to set all the billing details
        public void SetBillingDetails(string name, string lastname, string company, string address,
            string city, string postcode, string phone, string email, string paymentOption)
        {
            SetName(name);
            SetLastname(lastname);
            SetCompany(company);
            SetAddress(address);
            SetCity(city);
            SetPostcode(postcode);
            SetPhone(phone);
            SetEmail(email);
            SetPaymentOption(paymentOption);
        }

        // method to place order
        public void PlaceOrder()
        {
            _placeOrderButton.Click();
        }
    }
}
