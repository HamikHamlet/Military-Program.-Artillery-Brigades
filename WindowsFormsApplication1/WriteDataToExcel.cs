using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class WriteDataToExcel
    {
        Excel.Workbook workbook;
        Excel.Worksheet excelSheet;
        Excel.Application excelData;
        Excel.Range testCell;
        StringBuilder stringBuilder;
        CalculatedData calculatedata;
        object misValue = System.Reflection.Missing.Value;
        DataModel data;
        string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";

        public WriteDataToExcel()
        {

        }
        public WriteDataToExcel(DataModel datamodel)
        {
            string pathDirectory = GetDefaultDirectory();
            CreatdataExcel(pathDirectory, datamodel);
            MessageBox.Show("Տվյալները հաջողությամբ գրանցվեցին Excel ֆայլում");
        }
       public  string GetDefaultDirectory()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            return directoryName;
        }
        public void CreatdataExcel(string path, DataModel datamodel)
        {
            excelData = new Excel.Application();
            stringBuilder = new StringBuilder();
            stringBuilder.Append(path).Append("\\").Append(datamodel.solderPassportID).Append(datamodel.SolderName).Append(datamodel.SoldeSurername).Append(datamodel.Solderfname).Append(".csv");
            List<string> listofDataName = datamodel.DatamodelValue();

            Excel.Workbook excelWorkBook = excelData.Workbooks.Add(misValue);
            excelSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            excelWorkBook.SaveAs(stringBuilder.ToString(), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            int excelCallsCount = TestExcelCalls(stringBuilder.ToString());
            for (int i = 0; i < listofDataName.Count; i++)
            {
                ExcelGeneralDataDesign(excelCallsCount, i + 1);
                excelSheet.Cells[excelCallsCount, i + 1] = listofDataName[i];

                for (int j = 0; j < listofDataName.Count - 1; )
                {
                    if (i == 4 || i == 13)
                    {
                        ExcelSolderDataDesign(excelCallsCount + 1, i + 1);
                        excelSheet.Cells[excelCallsCount + 1, i + 1] = datamodel.DatamodelValueAge(i);
                    }
                    else
                    {
                        ExcelSolderDataDesign(excelCallsCount + 1, i + 1);
                        excelSheet.Cells[excelCallsCount + 1, i + 1] = datamodel.DatamodelValueStringParametrs(i);
                    }
                    break;

                }

            }
            excelWorkBook.SaveAs(stringBuilder.ToString(), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

            excelWorkBook.Close(true, misValue, misValue);
            excelData.Quit();
        }

        public int TestExcelCalls(string path)
        {
            int count = 0;

            excelData = new Excel.Application();
            workbook = excelData.Workbooks.Open(path);
            Excel.Worksheet excelSheet = workbook.ActiveSheet;
            for (int i = 1; i < 10000; i++)
            {
                if (excelSheet.Cells[i, 1].Value == null)
                {
                    count = i;
                    break;
                }
            }
            workbook.Close();
            
            excelData.Quit();
            return count;

        }
        private void ExcelGeneralDataDesign(int index1, int index2)
        {


            excelSheet.Cells[index1, index2].Font.Color = ColorTranslator.ToOle(Color.White);
            excelSheet.Cells[index1, index2].Font.Size = 13;
            excelSheet.Cells[index1, index2].Interior.Color = ColorTranslator.ToOle(Color.DarkGreen);
            excelSheet.Cells[index1, index2].Borders.Color = ColorTranslator.ToOle(Color.Black);

        }
        private void ExcelSolderDataDesign(int index1, int index2)
        {


            excelSheet.Cells[index1, index2].Font.Color = ColorTranslator.ToOle(Color.Black);
            excelSheet.Cells[index1, index2].Font.Size = 11;
            excelSheet.Cells[index1, index2].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
            excelSheet.Cells[index1, index2].Borders.Color = ColorTranslator.ToOle(Color.Black);

        }


        public void WriteCalcutateDataToExcel(DataModel dataModel)
        {
            stringBuilder = new StringBuilder();
            StringBuilder path = stringBuilder.Append(directoryName).Append("\\").Append(dataModel.solderPassportID).Append(dataModel.SolderName).Append(dataModel.SoldeSurername).Append(dataModel.Solderfname).Append(".csv");
           
            excelData = new Excel.Application();
            int excelCallsCount = TestExcelCalls(path.ToString());
            List<string> listofData = dataModel.DatamodelValueCalculate();
            if (Directory.Exists(directoryName))
            {
                workbook = excelData.Workbooks.Open(path.ToString());
                Excel.Workbook excelWorkBook = excelData.Workbooks.Add(misValue);
                excelSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
               
                int count = TestExcelCalls(path.ToString());
                for (int i = 0; i < listofData.Count; i++)
                {
                    excelSheet.Cells[count, i] = listofData[i];
                    excelSheet.Cells[count + 1, i] = calculatedata.ListCalculateData(i);
                }

            }
            else
            {
                CreatdataExcel(GetDefaultDirectory(), dataModel);
            }
        }
    }
}
