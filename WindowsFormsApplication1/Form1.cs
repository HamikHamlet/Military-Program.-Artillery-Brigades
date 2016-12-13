using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            Selected();
           
        }
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\LabUser33\Documents\armydata.mdf;Integrated Security=True;Connect Timeout=30";
        DataModel datamodel;
        WriteDataToExcel writedatatoexcel;
        WriteDataToDB writeDataToDB;
        SelectDataToDB selectdataToDB;
        private async void buttonSaveExcel_Click(object sender, EventArgs e)
        {
           
            int chechTextbox=ChechTextBoxText();
            if (chechTextbox != -1)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";
                 datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));

                await Task.Run(() => writedatatoexcel = new WriteDataToExcel(datamodel));

            }
            else
                MessageBox.Show("Խնդրում ենք լրացնել բոլոր դաշտերը");
        }

        private async void buttonSaveDB_Click(object sender, EventArgs e)
        {
           
            int chechTextbox=ChechTextBoxText();
            if (chechTextbox != -1)
            {
                datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));
                await Task.Run(() => writeDataToDB = new WriteDataToDB(datamodel,connectionString));
            }
            else
                MessageBox.Show("Խնդրում ենք լրացնել բոլոր դաշտերը");
        }
        
        private int ChechTextBoxText()
        {
            if (textBoxAltilerTitle.Text != string.Empty && textBoxArtilleryModel.Text != string.Empty && textBoxArtilleryName.Text != string.Empty && textboxFirstName.Text != string.Empty && textBoxFName.Text != string.Empty && textBoxLastName.Text != string.Empty && textBoxPassportID.Text != string.Empty)
                return 0;
            else
                return -1;
        }
        private void Selected()
        {
            comboBoxBattalion.SelectedIndex = 0;
            comboBoxBowl.SelectedIndex = 0;
            comboBoxClassical.SelectedIndex = 0;
            comboBoxCompany.SelectedIndex = 0;
            comboBoxTitle.SelectedIndex = 0;
        }

        private async void buttonSelectDB_Click(object sender, EventArgs e)
        {
            datamodel=new DataModel(textBoxPassportID.Text);
            await Task.Run(() => selectdataToDB = new SelectDataToDB(datamodel, connectionString));
        }

    }
}
