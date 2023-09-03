using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using uk.co.nfocus.samig.ecommerce.project.Support.POMPages;

namespace uk.co.nfocus.samig.ecommerce.project.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Before]
        public void SetUp() 
        {
            string Browser = Environment.GetEnvironmentVariable("BROWSER");

            // browsers
            switch (Browser)
            {
                case "firefox":
                    _driver = new FirefoxDriver();  
                    break;
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "edge":
                    _driver = new EdgeDriver();
                    break;
                case "ie":
                    _driver = new InternetExplorerDriver();
                    break;
                case "remotechrome":
                    ChromeOptions options = new ChromeOptions();
                    _driver = new RemoteWebDriver(new Uri("http://172.30.190.244.4444/wd/hub"), options);
                    break;
                default:
                    Console.WriteLine("Default browser is set as chrome");
                    _driver = new ChromeDriver();
                    break;
            }

            // key passes driver as value
            _scenarioContext["mydriver"] = _driver;

            // maximize browser
            _driver.Manage().Window.Maximize();

            // main page
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";

            // dismiss demo message
            MyAccountPOM demoMessage = new (_driver);
            demoMessage.DismissMessage();
        }

        [AfterScenario]
        public void TearDown()
        {
            // navigates to My Account page
            NavigationPOM myAccountPage = new(_driver);
            myAccountPage.NavigateTo("My Account");

            // logout 
            MyAccountPOM logout = new (_driver);
            logout.Logout();

            Console.WriteLine("Logout successful...");

            Thread.Sleep(2000);
            _driver.Quit();
        }
    }
}
