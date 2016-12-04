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
        FileStream file;
        DataModel ob;
        DateTime datatime;

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
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            file = new FileStream(path + "\\" + "file" , FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);


            oXL = new Excel.Application();
            oXL.Visible = true;
            oWB = (Excel.Workbook)(oXL.Workbooks.Add(""));
            oSheet = (Excel.Worksheet)oWB.ActiveSheet;
            oSheet.Cells[1, 1] = "First Name";
            oSheet.Cells[1, 2] = "Last Name";
            oSheet.Cells[1, 3] = "Full Name";
            oSheet.Cells[1, 4] = "Salary";
            oWB.SaveAs(file);
        }
    }
}
