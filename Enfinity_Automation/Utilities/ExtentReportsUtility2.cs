using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Enfinity_Automation.TestCases.HRMS.HRCore;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;


namespace RealTimeProject.Reporting
{
    public static class ExtentReportsUtility2
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter _spark;
        [ThreadStatic] private static ExtentTest currentTest;
        [ThreadStatic] private static IWebDriver driver;

        // Initialize the report
        public static void InitializeReport(string reportPath)
        {
            _spark = new ExtentSparkReporter(reportPath);
            _spark.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(_spark);

            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", "Your Name");
        }

        // Set WebDriver instance (to capture screenshots)
        public static void SetDriver(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Create a test in the report
        public static void CreateTest(string testName)
        {
            currentTest = extent.CreateTest(testName);
        }

        // Capture Screenshot and return file path
        public static string CaptureScreenshot(IWebDriver driver)
        {
            try
            {
                string screenshotPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots", $"{TestContext.CurrentContext.Test.Name}.png");
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath); // Remove the second argument (ScreenshotImageFormat.Png)
                return screenshotPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing screenshot: {ex.Message}");
                return null;
            }
        }

        // Log test result and attach screenshot if failed
        public static void LogTestResult()
        {
            if (currentTest == null) return;

            string status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            string message = TestContext.CurrentContext.Result.Message;
            string testName = TestContext.CurrentContext.Test.Name;

            if (status == "Passed")
            {
                currentTest.Pass("Test Passed.");
            }
            else if (status == "Failed")
            {
                // Assuming 'driver' is your IWebDriver instance (replace with your actual way of obtaining it)
                string screenshotPath = CaptureScreenshot(driver);  // Pass the WebDriver instance
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    currentTest.Fail($"Test Failed: {message}").AddScreenCaptureFromPath(screenshotPath);
                }
                else
                {
                    currentTest.Fail($"Test Failed: {message} (Screenshot not available)");
                }
            }

            currentTest.Info($"Execution Time: {DateTime.Now}");

            // optional code, it will automatically open the report on the browser
            string reportPath = $"{TestContext.CurrentContext.WorkDirectory}\\ExtentReport\\" +SampleTests1.ReportName();
            FileInfo extentReport = new FileInfo(reportPath);

            if (extentReport.Exists)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = extentReport.FullName,
                        UseShellExecute = true
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error opening the report: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Report not found at: " + reportPath);
            }

        }     
        

        // Flush the report
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
