using Enfinity_Automation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using RealTimeProject.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity_Automation.TestCases.HRMS.HRCore
{
    [TestFixture]
    public class SampleTests1
    {
        public static string ReportName()
        {
            string timeStamp = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss"); // time stamp
            string repName = "Test-Report-" + timeStamp + ".html";
            return repName;
        }

        private static string reportPath = $"{TestContext.CurrentContext.WorkDirectory}\\ExtentReport\\"+ ReportName();
        public IWebDriver driver;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            
            ExtentReportsUtility2.InitializeReport(reportPath);
        }

        [SetUp]
        public void TestSetup()
        {
            driver = new ChromeDriver(); // Start browser for each test
            ExtentReportsUtility2.SetDriver(driver); // Set driver for screenshot capture
            ExtentReportsUtility2.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.AreEqual("Google", driver.Title); // Pass case
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.AreEqual("WrongTitle", driver.Title); // Fail case (Intentional)
        }

        [TearDown]
        public void TestTearDown()
        {
            ExtentReportsUtility2.LogTestResult();
            driver.Close();
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentReportsUtility2.FlushReport();
            
        }
    }
}
