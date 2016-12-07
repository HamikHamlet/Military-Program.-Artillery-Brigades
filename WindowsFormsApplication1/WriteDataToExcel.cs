using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    class WriteDataToExcel
    {

        Excel.Worksheet excelSheet;
        Excel.Application excelData;
        object misValue = System.Reflection.Missing.Value;

        public WriteDataToExcel()
        {

        }
        public WriteDataToExcel(DataModel datamodel)
        {
            string pathDirectory = GetDefaultDirectory();
            CreatdataExcel(pathDirectory, datamodel);
        }
        private string GetDefaultDirectory()
        {
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            return directoryName;
        }
        public void CreatdataExcel(string path, DataModel datamodel)
        {
            excelData = new Excel.Application();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(path).Append("\\").Append(datamodel.SolderName).Append("-").Append(datamodel.SoldeSurername).Append(".csv");
            List<string> listofDataName = datamodel.DatamodelValue();

            Excel.Workbook excelWorkBook = excelData.Workbooks.Add(misValue);
            excelSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < listofDataName.Count; i++)
            {
                excelSheet.Cells[1, i + 1] = listofDataName[i];
                for (int j = 0; j < listofDataName.Count - 1; )
                {
                    if (i == 4 || i == 13)
                        excelSheet.Cells[2, i + 1] = datamodel.DatamodelValueAge(i);
                    else
                        excelSheet.Cells[2, i + 1] = datamodel.DatamodelValueStringParametrs(i);
                    break;
                }

            }
            excelWorkBook.SaveAs(stringBuilder.ToString(), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            excelWorkBook.Close(true, misValue, misValue);
            excelData.Quit();
        }
    }
}
