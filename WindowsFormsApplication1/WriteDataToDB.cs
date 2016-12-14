using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class WriteDataToDB
    {
        List<string> encodingValue;
        DataModel da;
        StringBuilder stringBuilder;
        internal string connectionString { get; set; }

        public WriteDataToDB()
        {

        }

        public WriteDataToDB(DataModel datamodel,string conection)
        {
            connectionString = conection;
            CodingData(datamodel);
            InsertData(datamodel);
        }
        public void InsertData(DataModel datamodel)
        {
           
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    datamodel.solderPassportID = encodingValue[0];
                    datamodel.SolderName = encodingValue[1];
                    datamodel.SoldeSurername = encodingValue[2];
                    datamodel.Solderfname = encodingValue[3];
                    datamodel.Soldertitle = encodingValue[4];
                    datamodel.Solderclassical = encodingValue[5];
                    datamodel.Soldercompany = encodingValue[6];
                    datamodel.Solderbattalion = encodingValue[7];
                    datamodel.Solderbowl = encodingValue[8];
                    datamodel.Artilleryname = encodingValue[9];
                    datamodel.Artillerymodel = encodingValue[10];
                    datamodel.Altilertitle = encodingValue[11];
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "INSERT INTO SolderTable(PassportID,Soldername,Soldersurname,Soldermiddlename,Solderage) VALUES ('" + datamodel.solderPassportID + "',N'" + datamodel.SolderName + "',N'" + datamodel.SoldeSurername + "',N'" + datamodel.Solderfname + "','" + datamodel.Solderage + "')";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO solderTitle(passportID,solderTitle,solderClassical,solderCompany,solderBattalion,solderBowl) VALUES ('" + datamodel.solderPassportID + "',N'" + datamodel.Soldertitle + "','" + datamodel.Solderclassical + "','" + datamodel.Soldercompany + "','" + datamodel.Solderbattalion + "','" + datamodel.Solderbowl + "')";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "INSERT INTO altilleryTable(passportID,Altilleryname,Altillerymodel,Altillerytitle,Altilleryage) VALUES ('" + datamodel.solderPassportID + "',N'" + datamodel.Artilleryname + "',N'" + datamodel.Artillerymodel + "',N'" + datamodel.Altilertitle + "','" + datamodel.Altilerage + "')";
                    sqlCommand.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Բազան հաջողությամբ լրացվեց");


        }

         private void  CodingData(DataModel datamodelcoding)
        {
            encodingValue = new List<string>();
            for (int i = 0; i < 13; i++)
            {
          stringBuilder = new StringBuilder();
                if (i != 4)
                {

                    string encodedLine = datamodelcoding.DatamodelValueStringParametrs(i);
                    for (int j = 0; j < encodedLine.Length; j++)
                    {
                        
                        char c = encodedLine[j];
                        int codechar = c + 10;
                        stringBuilder.Append((char)codechar);

                    }
                     
                     encodingValue.Add(stringBuilder.ToString());
                    
                }
            }
           
           
        }


       
    }
}
