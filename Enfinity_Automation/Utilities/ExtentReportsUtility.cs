using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace RealTimeProject.Reporting
{
    public static class ExtentReportsUtility
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter _spark;
        private static ExtentTest currentTest;

        // Initialize the Extent Report
        public static void InitializeReport(string reportPath)
        {
            _spark = new ExtentSparkReporter(reportPath);
            _spark.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(_spark);

            // Add System Info
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", "Your Name");
        }

        // Create a test instance
        public static void CreateTest(string testName)
        {
            currentTest = extent.CreateTest(testName);
        }

        // Log status
        public static void LogStatus(string status, string message)
        {
            switch (status.ToLower())
            {
                case "pass":
                    currentTest.Pass(message);
                    break;
                case "fail":
                    currentTest.Fail(message);
                    break;
                case "info":
                    currentTest.Info(message);
                    break;
                case "warning":
                    currentTest.Warning(message);
                    break;
            }
        }

        // Add Screenshot
        public static void AddScreenshot(string screenshotPath)
        {
            currentTest.AddScreenCaptureFromPath(screenshotPath);
        }

        // Flush the report
        public static void FlushReport()
        {
            extent.Flush();
        }

        
    }
}
