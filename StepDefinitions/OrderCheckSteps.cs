using NUnit.Framework;
using OpenQA.Selenium;
using uk.co.nfocus.samig.ecommerce.project.Support;
using uk.co.nfocus.samig.ecommerce.project.Support.POMPages;

namespace uk.co.nfocus.samig.ecommerce.project.StepDefinitions
{
    [Binding]
    public class OrderCheckSteps
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public OrderCheckSteps(ScenarioContext scenarioContext)
        {
            // container that holds information about the scenario
            _scenarioContext = scenarioContext;
            // finds the key and assigns it as web driver
            _driver = scenarioContext["mydriver"] as IWebDriver;
        }

        [When(@"i checkout my cart")]
        public void WhenICheckoutMyCart()
        {
            // navigates shop page
            NavigationPOM shopPage = new(_driver);
            shopPage.NavigateTo("Shop");

            // add an item to the cart
            ShopItemPOM shopItem = new(_driver);
            shopItem.AddItemToCart("Long Sleeve Tee");

            // navigates to cart after adding item
            ShopItemPOM viewItem = new(_driver);
            viewItem.ViewCart();

            // proceeds to checkout 
            CartPOM checkoutItem = new(_driver);
            checkoutItem.ProceedToCheckout();
        }

        [When(@"complete the billing form")]
        public void WhenCompleteTheBillingForm()
        {
            // provides billing information to the fields
            BillingPOM billingDetails = new(_driver);
            billingDetails.SetBillingDetails("Agile", "Tester", "nFocus Testing", "e-Innovation Centre", 
                "Telford", "TF2 9FT", "0370 242 6235", "abc19072023@gmail.com", "Cheque Payment");

            // places order
            BillingPOM placeOrder = new(_driver);
            placeOrder.PlaceOrder();
        }

        [Then(@"order number is generated and viewable in order page")]
        public void ThenOrderNumberIsGenerated()
        {
            // captures order number generated
            OrderPOM orderConfirmation = new(_driver);
            int generatedOrderNumber = orderConfirmation.GetGeneratedOrderNumber();
            Console.WriteLine($"Order Number generated is: {generatedOrderNumber}");

            // takes screenshot of order confirmation which includes order number
            ScreenshotHelper screenshotOrderNumber = new ScreenshotHelper(_driver);
            screenshotOrderNumber.ScreenshotTaker("Order Number.png");

            // navigates my account page
            NavigationPOM myAccountPage = new(_driver);
            myAccountPage.NavigateTo("My Account");

            // navigates to orders page from my account page amd captures the first order displayed
            OrderPOM orderPage = new(_driver);
            orderPage.ViewOrders();
            int firstOrderNumber = orderPage.GetFirstOrderNumberFromOrderPage();
            Console.WriteLine($"The first Order Number is: {firstOrderNumber}");

            // assert generated order number is equal to first order number in orders page
            Assert.That(generatedOrderNumber, Is.EqualTo(firstOrderNumber),
                $"The generated order number {generatedOrderNumber} does not exist in Orders Page.");

            Console.WriteLine("Test Complete.");
        }
    }
}
