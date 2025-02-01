using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity_Automation.Utilities
{
    public static class ExtentReportsUtility1
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter _spark;
        [ThreadStatic] private static ExtentTest currentTest;        

        // Initialize the report once for the test run
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

        // Create a new test entry in the report
        public static void CreateTest(string testName)
        {
            currentTest = extent.CreateTest(testName);
        }

        // Log automatically based on test result
        public static void LogTestResult()
        {
            if (currentTest == null) return;

            string status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            string message = TestContext.CurrentContext.Result.Message;

            if (status == "Passed")
                currentTest.Pass("Test Passed.");
            else if (status == "Failed")
                currentTest.Fail($"Test Failed: {message}");

            // Optionally, log additional test details
            currentTest.Info($"Execution Time: {DateTime.Now}");
        }

        // Flush the report
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
