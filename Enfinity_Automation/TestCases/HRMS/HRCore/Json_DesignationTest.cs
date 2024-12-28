using Enfinity_Automation.BaseTest;
using Enfinity_Automation.Models;
using Enfinity_Automation.PageObjects.HRMS.HRCore;
using Enfinity_Automation.Utilities.DataProviders.HRMS.HRCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Enfinity_Automation.TestCases.HRMS.HRCore
{
    public class Json_DesignationTest : BaseClass
    {
        private DesignationPage _dp;

        [SetUp]
        public void Init()
        {
            // Initialize the DesignationPage object with the driver
            _dp = new DesignationPage(Driver);
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.DesignationJson))]
        public void VerifyDesignationJson(DesignationModel designationModel)
        {
            //string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "designation.json");
            //var jsonString = File.ReadAllText(jsonFilePath);

            //var designationModel = JsonSerializer.Deserialize<DesignationModel>(jsonString);

            // Navigate to Designation setup
            _dp.NavigateToDesignation();

            //_dp.CreateDesignation();

            _dp.ClkNewBtn();
            Logger.Info("clicked on new btn");
            //_dp.EnterCode(code);
            _dp.EnterCode(designationModel.Id);
            Logger.Info("provided code");
            //_dp.EnterDesignation(desg);
            _dp.EnterDesignation(designationModel.Name);
            Logger.Info("provided designation");
            _dp.ClkSaveBtn();
            Logger.Info("clicked on save button");



            //Assert.True(_dp.isDesgCreated());

            //test
        }
    }
}
