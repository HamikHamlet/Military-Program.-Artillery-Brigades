using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSaveExcel_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";
            DataModel datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));
            WriteDataToExcel writedatatoexcel = new WriteDataToExcel(datamodel);
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {

        }
    }
}
