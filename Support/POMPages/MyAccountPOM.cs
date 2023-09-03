using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.samig.ecommerce.project.Support.POMPages
{
    internal class MyAccountPOM
    {
        private IWebDriver _driver;

        // constructor
        public MyAccountPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators 
        private IWebElement _usernameField => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.Id("username")));
        private IWebElement _passwordField => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.Id("password")));
        private IWebElement _loginButton => new WebDriverWait
            (_driver, TimeSpan.FromSeconds(5)).
            Until(drv => drv.FindElement(By.CssSelector("button[name='login']")));
        private IWebElement _logoutButton => _driver.FindElement(By.LinkText("Logout"));
        private IWebElement _dismissMessageButton => _driver.FindElement(By.CssSelector("body > p > a"));

        // setter for username
        public MyAccountPOM SetUsername(string username)
        {
            _usernameField.Clear();
            _usernameField.SendKeys(username);
            return this;
        }

        // setter for password
        public MyAccountPOM SetPassword(string password)
        {
            _passwordField.Clear();
            _passwordField.SendKeys(password);
            return this;
        }

        // submit login details
        public void SubmitLoginDetails()
        {
            _loginButton.Click();
        }

        // login method
        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            SubmitLoginDetails();
        }

        // logout method
        public void Logout()
        {
            _logoutButton.Click();
        }

        // dismiss message method
        public void DismissMessage()
        {
            if (_dismissMessageButton.Displayed)
            {
                _dismissMessageButton.Click();
            }
        }

    }
}
