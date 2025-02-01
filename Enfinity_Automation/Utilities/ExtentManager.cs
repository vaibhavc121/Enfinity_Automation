using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;

public class ExtentManager
{
    private static ExtentReports _extent;
    private static ExtentSparkReporter _spark; // For HTML reports

    public static ExtentReports Instance
    {
        get
        {
            if (_extent == null)
            {
                _extent = new ExtentReports();
                _spark = new ExtentSparkReporter("ExtentReport.html"); // Customize path
                _spark.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
                _spark.Config.DocumentTitle = "Your Project Name - Test Report";
                _spark.Config.ReportName = "Test Execution Report";
                _extent.AttachReporter(_spark);

                // Optional: Add system information
                _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                _extent.AddSystemInfo("Java Version", Environment.Version.ToString()); // C# version, not Java
                _extent.AddSystemInfo("Environment", "Testing");
            }
            return _extent;
        }
    }

    public static void Flush()
    {
        if (_extent != null)
        {
            _extent.Flush();
        }
    }
}