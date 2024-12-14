using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity_Automation.Utilities.DataProviders.HRMS.HRCore
{
    public class Excel_HRCoreDataProvider
    {
        //using EPPlus package

        private const string ExcelFilePath = @"\TestData\HRMS\HRCore\HRCoreData.xlsx"; //excel path
        

        public static IEnumerable<TestCaseData> Designation()
        {
            // Read data from the Excel file
            var testData = ReadExcelData(ExcelFilePath, "Designations");

            foreach (var dataRow in testData)
            {
                // dataRow[0] is "Code" and dataRow[1] is "Designation"
                yield return new TestCaseData(dataRow[0], dataRow[1]);
            }
        }

        private static List<string[]> ReadExcelData(string filePath, string sheetName)
        {
            var result = new List<string[]>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetName];
                if (worksheet == null)
                {
                    throw new Exception($"Worksheet '{sheetName}' not found in file '{filePath}'");
                }

                int rows = worksheet.Dimension.Rows;
                int cols = worksheet.Dimension.Columns;

                // Read rows from 2nd row (1st row has headers)
                for (int row = 2; row <= rows; row++)
                {
                    var rowData = new string[cols];
                    for (int col = 1; col <= cols; col++)
                    {
                        rowData[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    result.Add(rowData);
                }
            }

            return result;
        }
    }
}
