using NUnit.Framework;
using OpenQA.Selenium;
using uk.co.nfocus.samig.ecommerce.project.Support.POMPages;

namespace uk.co.nfocus.samig.ecommerce.project.StepDefinitions
{
    [Binding]
    public class CouponDiscountSteps
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public CouponDiscountSteps(ScenarioContext scenarioContext)
        {
            // container that holds information about the scenario
            _scenarioContext = scenarioContext;
            // finds the key and assigns it as web driver
            _driver = scenarioContext["mydriver"] as IWebDriver;
        }

        [Given(@"that i have logged in using valid credentials")]
        public void GivenThatIHaveLoggedInUsingValidCredentials()
        {
            // navigates to my account page
            NavigationPOM loginPage = new(_driver);
            loginPage.NavigateTo("My Account");

            // logs in with following credentials
            MyAccountPOM loginAccount = new(_driver);
            loginAccount.Login("abc19072023@gmail.com", "ecommerce123$");
        }

        [When(@"i add an '([^']*)' to the cart")]
        public void WhenIAddAnToTheCart(string item)
        {
            // navigates shop page
            NavigationPOM shopPage = new(_driver);
            shopPage.NavigateTo("Shop");

            // adds parameterised items from examples table
            ShopItemPOM shopItem = new(_driver);
            shopItem.AddItemToCart(item);

            // navigates to cart after adding item
            ShopItemPOM viewItem = new(_driver);
            viewItem.ViewCart();
        }

        [When(@"i apply a valid coupon '([^']*)'")]
        public void WhenIApplyAValidCoupon(string couponCode)
        {
            // applies coupon code
            CartPOM coupon = new(_driver);
            coupon.EnterAndApplyCouponCode(couponCode);
        }

        [Then(@"discount of '([\d]*)'% is applied")]
        public void ThenDiscountOfIsApplied(int discountPercentage)
        {
            CartPOM cartValues = new(_driver);

            // discount and subtotal variables
            decimal discount = cartValues.DiscountValue();
            Console.WriteLine($"Discount: - £{discount}");
            decimal subtotal = cartValues.SubtotalValue();
            Console.WriteLine($"Subtotal: £{subtotal}");

            // assert discount value is equal to (item value * (discount percentage/100))
            Assert.That(discount, 
                Is.EqualTo(subtotal * discountPercentage/100),
                $"Coupon value does not equal to {discountPercentage}%.");

            Console.WriteLine("Test Complete.");
        }

        [Then(@"the total is calculated with shipping and discount")]
        public void ThenTheTotalIsCalculatedWithShippingPlusDiscount()
        {
            CartPOM cartValues = new(_driver);

            // discount, subtotal, shipping, and total variables
            decimal discount = cartValues.DiscountValue();
            Console.WriteLine($"Discount: - £{discount}");
            decimal subtotal = cartValues.SubtotalValue();
            Console.WriteLine($"Subtotal: £{subtotal}");
            decimal shippingCost = cartValues.ShippingCostValue();
            Console.WriteLine($"Shipping Cost: £{shippingCost}");
            decimal total = cartValues.TotalValue();
            Console.WriteLine($"Total: £{total}");

            // expected total
            decimal expectedTotal = subtotal - discount + shippingCost;
            Console.WriteLine($"Expected Total: £{expectedTotal}");

            // assert total and expected total is the same
            Assert.That(total, Is.EqualTo(expectedTotal),
                $"Total value is not equal to expected total £{expectedTotal}.");

            Console.WriteLine("Test Complete.");

        }
    }
}
