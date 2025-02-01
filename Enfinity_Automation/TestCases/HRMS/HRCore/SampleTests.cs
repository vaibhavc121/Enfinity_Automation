using RealTimeProject.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity_Automation.TestCases.HRMS.HRCore
{
    [TestFixture]
    public class SampleTests
    {
        private static string reportPath = $"{TestContext.CurrentContext.WorkDirectory}\\ExtentReport1.html";

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ExtentReportsUtility.InitializeReport(reportPath);
        }

        [SetUp]
        public void TestSetup()
        {
            ExtentReportsUtility.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Test1()
        {
            try
            {
                Assert.AreEqual(5, 5);
                ExtentReportsUtility.LogStatus("pass", "Test1 passed successfully.");
            }
            catch (AssertionException ex)
            {
                ExtentReportsUtility.LogStatus("fail", $"Test1 failed. Exception: {ex.Message}");
                throw;
            }
        }

        [Test]
        public void Test2()
        {
            try
            {
                Assert.AreEqual(5, 6);
                ExtentReportsUtility.LogStatus("pass", "Test2 passed successfully.");
            }
            catch (AssertionException ex)
            {
                ExtentReportsUtility.LogStatus("fail", $"Test2 failed. Exception: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void TestTearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            var message = TestContext.CurrentContext.Result.Message;

            if (status == "Passed")
            {
                ExtentReportsUtility.LogStatus("pass", "Test passed.");
            }
            else if (status == "Failed")
            {
                ExtentReportsUtility.LogStatus("fail", $"Test failed: {message}");
            }
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentReportsUtility.FlushReport();
        }
    }
}
