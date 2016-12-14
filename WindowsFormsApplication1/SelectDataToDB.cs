using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class SelectDataToDB
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        static List<String> dataList;
        StringBuilder stringBuilder;
        WriteDataToDB data;

        internal string connectionString { get; set; }
        internal DataModel datamodel { get; set; }

        public SelectDataToDB()
        {

        }
        public SelectDataToDB(DataModel data, string conection)
        {
            connectionString = conection;
            datamodel = data;
            SelectToDB();

        }

        private void SelectToDB()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            com = new SqlCommand(@"SELECT solderTable.PassportID,solderTable.Soldername,solderTable.Soldersurname,solderTable.Soldermiddlename,solderTable.Solderage,solderTitle.solderTitle,solderTitle.solderClassical,solderTitle.solderCompany,solderTitle.solderBattalion,solderTitle.solderBowl
	 FROM solderTable
		Inner JOIN solderTitle
	 ON solderTable.PassportID=solderTitle.passportID
	 WHERE 
	 solderTable.PassportID='" + EnCoding(datamodel.solderPassportID) + "'", con);
            reader = com.ExecuteReader();
            dataList = new List<String>();

            while (reader.Read())
            {

                dataList.Add(reader["PassportID"].ToString());
                dataList.Add(reader["Soldername"].ToString());
                dataList.Add(reader["Soldersurname"].ToString());
                dataList.Add(reader["Soldermiddlename"].ToString());
                dataList.Add(reader["Solderage"].ToString());
                dataList.Add(reader["solderTitle"].ToString());
                dataList.Add(reader["solderClassical"].ToString());
                dataList.Add(reader["solderCompany"].ToString());
                dataList.Add(reader["solderBattalion"].ToString());
                dataList.Add(reader["solderBowl"].ToString());
            }


            //for (int i = 0; i < dataList.Count; i++)
            //{
            //    if (i == 4)
            //        MessageBox.Show(dataList[i]);
            //    else
            //        MessageBox.Show(DeCoding(dataList[i]));

            //}


        }

        public string GetData(int index)
        {
            if (index == 4)
                return dataList[index];
            else
                return DeCoding(dataList[index]);
        }


        private string DeCoding(string str)
        {
            stringBuilder = new StringBuilder();

            string encodedLine = str;
            for (int j = 0; j < encodedLine.Length; j++)
            {

                char c = encodedLine[j];
                int codechar = c - 10;
                stringBuilder.Append((char)codechar);

            }

            return stringBuilder.ToString();

            //  
        }

        private string EnCoding(string str)
        {
            stringBuilder = new StringBuilder();

            string encodedLine = str;
            for (int j = 0; j < encodedLine.Length; j++)
            {

                char c = encodedLine[j];
                int codechar = c + 10;
                stringBuilder.Append((char)codechar);

            }

            return stringBuilder.ToString();

        }





    }
}

