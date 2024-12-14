using Enfinity_Automation.BaseTest;
using Enfinity_Automation.PageObjects.HRMS.HRCore;
using Enfinity_Automation.Utilities.DataProviders.HRMS.HRCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void VerifyDesignation()
        {

            // Navigate to Designation setup
            _dp.NavigateToDesignation();

            //_dp.CreateDesignation();

            _dp.ClkNewBtn();
            Logger.Info("clicked on new btn");
            //_dp.EnterCode(code);
            _dp.EnterCode(faker.Random.AlphaNumeric(5));
            Logger.Info("provided code");
            //_dp.EnterDesignation(desg);
            _dp.EnterDesignation(faker.Name.JobTitle());
            Logger.Info("provided designation");
            _dp.ClkSaveBtn();
            Logger.Info("clicked on save button");



            Assert.True(_dp.isDesgCreated());

            //test
        }
    }
}
