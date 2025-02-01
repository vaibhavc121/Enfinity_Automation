using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;

[TestFixture]
public class MyTestClass
{
    private ExtentReports _extent;
    private ExtentTest _test;

    [OneTimeSetUp] // For setup before all tests in the fixture
    public void Setup()
    {
        _extent = ExtentManager.Instance; // Get the singleton instance
    }

    [Test]
    public void MyFirstTest()
    {
        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name); // Create a test node
        _test.Log(Status.Info, "Starting the test");

        try
        {
            // Your test logic here
            int result = 10 / 2;
            _test.Pass("Test Passed. Result: " + result); // Log pass status
        }
        catch (Exception e)
        {
            _test.Fail("Test Failed. Exception: " + e.Message); // Log fail status with exception
        }

        _test.Log(Status.Info, "Test Completed");
    }

    [Test]
    public void MySecondTest()
    {
        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        _test.Log(Status.Info, "Another test started");
        // ... your test logic ...
        _test.Warning("This is a warning message.");
        _test.Skip("This test was skipped."); // Log a skipped status
        _test.Log(Status.Info, "Test Completed");
    }

    [OneTimeTearDown] // For cleanup after all tests in the fixture
    public void TearDown()
    {
        ExtentManager.Flush(); // Flush the report at the end
    }
}