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
            Selecteditem();
        }
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\labuser11\Source\Repos\Military-Program.-Artillery-Brigades\WindowsFormsApplication1\bin\Debug\armydata.mdf;Integrated Security=True";
        DataModel datamodel;
        WriteDataToExcel writedatatoexcel;
        WriteDataToDB writeDataToDB;
        SelectDataToDB selectdataToDB;
        CalculatedData calculateData;
        private async void buttonSaveExcel_Click(object sender, EventArgs e)
        {

            int chechTextbox = ChechTextBoxText();
            if (chechTextbox != -1)
            {

                datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));

                await Task.Run(() => writedatatoexcel = new WriteDataToExcel(datamodel));
            }
            else
                MessageBox.Show("Խնդրում ենք լրացնել բոլոր դաշտերը");

            buttonSaveFile.Enabled = true;
        }
        private async void buttonSaveDB_Click(object sender, EventArgs e)
        {
          
            int chechTextbox = ChechTextBoxText();
            if (chechTextbox != -1)
            {
                datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));
                await Task.Run(() => writeDataToDB = new WriteDataToDB(datamodel, connectionString));
            }
            else
                MessageBox.Show("Խնդրում ենք լրացնել բոլոր դաշտերը");

            buttonSaveExcel.Enabled = true;
            buttonSelectDB.Enabled = true;
        }

        private int ChechTextBoxText()
        {
            if (textBoxAltilerTitle.Text != string.Empty && textBoxArtilleryModel.Text != string.Empty && textBoxArtilleryName.Text != string.Empty && textboxFirstName.Text != string.Empty && textBoxFName.Text != string.Empty && textBoxLastName.Text != string.Empty && textBoxPassportID.Text != string.Empty)
                return 0;
            else
                return -1;
        }
        private void Selecteditem()
        {

            comboBoxBattalion.SelectedIndex = 0;
            comboBoxBowl.SelectedIndex = 0;
            comboBoxClassical.SelectedIndex = 0;
            comboBoxCompany.SelectedIndex = 0;
            comboBoxTitle.SelectedIndex = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 300;
            chart1.ChartAreas[0].AxisX.Maximum = 200;
        }
        private async void buttonSelectDB_Click(object sender, EventArgs e)
        {
            datamodel = new DataModel(textBoxPassportID.Text);
            try
            {
                await Task.Run(() => selectdataToDB = new SelectDataToDB(datamodel, connectionString));
                textBoxPassportID.Text = selectdataToDB.GetData(0);
                textboxFirstName.Text = selectdataToDB.GetData(1);
                textBoxLastName.Text = selectdataToDB.GetData(2);
                textBoxFName.Text = selectdataToDB.GetData(3);
                numericUpDownAge.Value = Convert.ToDecimal(selectdataToDB.GetData(4));
                comboBoxTitle.Text = selectdataToDB.GetData(5);
                comboBoxClassical.Text = selectdataToDB.GetData(6);
                comboBoxCompany.Text = selectdataToDB.GetData(7);
                comboBoxBattalion.Text = selectdataToDB.GetData(8);
                comboBoxBowl.Text = selectdataToDB.GetData(9);
                textBoxArtilleryName.Text = selectdataToDB.GetData(10);
                textBoxArtilleryModel.Text = selectdataToDB.GetData(11);
                textBoxAltilerTitle.Text = selectdataToDB.GetData(12);
                numericUpDownaltiler.Value = Convert.ToDecimal(selectdataToDB.GetData(13));
            }
            catch (Exception)
            {
                MessageBox.Show("Խնդրում ենք ներմուծեք ճիշտ ID");
            }
        }
        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            calculateData = new CalculatedData(double.Parse(textBoxazaltilleryX.Text), double.Parse(textBoxazAltilleryY.Text), double.Parse(textBoxInitialSpeed.Text), double.Parse(textBoxamAltilleryX.Text), double.Parse(textBoxamAltilleryY.Text), Convert.ToDouble(numericUpDownProjAngle.Value));
            chart1.Series[0].Points.Clear();
            for (double t = 0; t < calculateData.FlightDuration; t += 0.1)
            {
                chart1.Series["Series"].Points.AddXY(Math.Floor(calculateData.V1 * t), Math.Floor(calculateData.V2 * t - (10 * t * t) / 2));
            }
            chart1.Series["Series"].Points.AddXY((calculateData.AdversaryX), (calculateData.AdversaryY));
            textBoxFlightDuration.Text = calculateData.FlightDuration.ToString();
            textBoxMaxSize.Text =  Math.Floor(calculateData.H).ToString() ;
            WriteDataToExcel write = new WriteDataToExcel();
            datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));
            write.GetDefaultDirectory();
            write.WriteDataToExcelUpdate(datamodel, calculateData);

        }
    }
}
