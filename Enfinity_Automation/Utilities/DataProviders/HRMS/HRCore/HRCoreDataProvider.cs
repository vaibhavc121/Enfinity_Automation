using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
