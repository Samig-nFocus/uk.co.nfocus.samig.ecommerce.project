using OpenQA.Selenium;

namespace uk.co.nfocus.samig.ecommerce.project.Support
{
    internal class ScreenshotHelper
    {
        private IWebDriver _driver;

        // constructor
        public ScreenshotHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        // screenshot method
        public void ScreenshotTaker(string screenshotFileName)
        {
            // screenshot driver
            ITakesScreenshot ssdriver = _driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();

            // returns the full path, from folder of executeables to the main repos solution folder
            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // combines solution path to path to TestResults Folder
            string testResultsFolder = Path.Combine(solutionPath, "TestResults");

            // combines TestResults path to save screenshot
            string screenshotPath = Path.Combine(testResultsFolder, screenshotFileName);

            // saves screenshot on TestResults Folder
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}

