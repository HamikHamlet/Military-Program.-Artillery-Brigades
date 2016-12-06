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
        DataModel ob;
        Excel.Worksheet xlWorkSheet;
        Excel.Application excelData;
        object misValue = System.Reflection.Missing.Value;

        public WriteDataToExcel()
        {

            string pathDirectory = GetDefaultDirectory();
            CreatdataExcel(pathDirectory, ob);
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
            datamodel = new DataModel();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(path).Append("\\").Append(datamodel.Artilleryname).Append("h").Append(datamodel.SoldeSurername).Append(".csv");

            List<string> list = datamodel.DatamodelValue();

            Excel.Workbook xlWorkBook = excelData.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            for (int i = 0; i < list.Count; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = list[i];
                for (int j = 0; j < list.Count;)
                {
                    xlWorkSheet.Cells[2, i + 1] = datamodel.Solderage;

                    break;

                }

            }

            xlWorkBook.SaveAs(stringBuilder.ToString(), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            excelData.Quit();
        }
    }
}
