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
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Source\Repos\Console\Military-Program.-Artillery-Brigades4\WindowsFormsApplication1\bin\Debug\armydata.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            Selected();
        }

        private async void buttonSaveExcel_Click(object sender, EventArgs e)
        {
            WriteDataToExcel writedatatoexcel;
            int chechTextbox=ChechTextBoxText();
            if (chechTextbox != -1)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";
                DataModel datamodel = new DataModel(textBoxPassportID.Text, textboxFirstName.Text, textBoxLastName.Text, textBoxFName.Text, Convert.ToInt16(numericUpDownAge.Value), comboBoxTitle.Text, comboBoxClassical.Text, comboBoxCompany.Text, comboBoxBattalion.Text, comboBoxBowl.Text, textBoxArtilleryName.Text, textBoxArtilleryModel.Text, textBoxAltilerTitle.Text, Convert.ToInt16(numericUpDownaltiler.Value));

                await Task.Run(() => writedatatoexcel = new WriteDataToExcel(datamodel));

            }
            else
                MessageBox.Show("Խնդրում ենք լրացնել բոլոր դաշտերը");
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        public void InsertData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = @"INSERT INTO SolderTable(PassportID,Soldername,Soldersurname,Soldermiddlename,Solderage) VALUES ('" + textBoxPassportID.Text + "','" + textboxFirstName.Text + "','" + textBoxLastName.Text + "','" + textBoxFName.Text + "','" + numericUpDownAge.Value + "')";
                    sqlCommand.CommandText = "INSERT INTO solderTitle(passportID,solderTitle,solderClassical,solderCompany,solderBattalion,solderBowl) VALUES ('" + textBoxPassportID.Text + "','" + comboBoxTitle.SelectedText + "','" + comboBoxClassical.SelectedText + "','" + comboBoxCompany.SelectedText + "','" + comboBoxBattalion.SelectedText + "','" + comboBoxBowl.SelectedText + "')";
                    sqlCommand.CommandText = "INSERT INTO altilleryTable(passportID,Altilleryname,Altillerymodel,Altillerytitle,Altilleryage) VALUES ('" + textBoxPassportID.Text + "','" + textBoxArtilleryName.Text + "','" + textBoxArtilleryModel.Text + "','" + textBoxAltilerTitle.Text + "','" + numericUpDownaltiler.Value + "')";
                    sqlCommand.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Բազան հաջողությամբ լրացվեց");
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

    }
}
