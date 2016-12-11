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
        private string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Source\Repos\Console\Military-Program.-Artillery-Brigades3\WindowsFormsApplication1\bin\Debug\armydata.mdf;Integrated Security=True";

        public WriteDataToDB()
        {

        }

        public WriteDataToDB(DataModel datamodel)
        {
            InsertData(datamodel);
        }
        public void InsertData(DataModel datamodel)
        {
            
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
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
    }
}
