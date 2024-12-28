using Enfinity_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Enfinity_Automation.Utilities.DataProviders.HRMS.HRCore
{
    public class HRCoreDataProvider
    {
        public static IEnumerable<TestCaseData> Designation()
        {
            yield return new TestCaseData("1010", "TestDesg10");
            //yield return new TestCaseData("TestDesg6");
        }

        public static IEnumerable<DesignationModel> DesignationJson()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "designation.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var designationModel = JsonSerializer.Deserialize<DesignationModel>(jsonString);

            yield return designationModel;
        }

        private void ReadJsonFile()
        {
            //AppDomain.CurrentDomain.BaseDirectory
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "designation.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel=JsonSerializer.Deserialize<DesignationModel>(jsonString);
        }
    }
}
