using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class DataModel
    {

        private string solderpassportID = string.Empty;
        private string soldername = string.Empty;
        private string soldesurername = string.Empty;
        private string solderfname = string.Empty;
        private int solderage;
        private string soldertitle = string.Empty;
        private string solderclassical = string.Empty;
        private string soldercompany = string.Empty;
        private string solderbattalion = string.Empty;
        private string solderbowl = string.Empty;
        private string artilleryname = string.Empty;
        private string artillerymodel = string.Empty;
        private string altilertitle = string.Empty;
        private int altilerage;

        public DataModel(string solderpassportID, string soldername, string soldesurername, string solderfname, int solderage, string soldertitle, string solderclassical, string soldercompany, string solderbattalion, string solderbowl, string artilleryname, string artillerymodel, string altilertitle, int altilerage)
        {
            solderPassportID = solderpassportID;
            SolderName = soldername;
            SoldeSurername = soldesurername;
            Solderfname = solderfname;
            Solderage = solderage;
            Soldertitle = soldertitle;
            Solderclassical = solderclassical;
            Soldercompany = soldercompany;
            Solderbattalion = solderbattalion;
            Solderbowl = solderbowl;
            Artilleryname = artilleryname;
            Artillerymodel = artillerymodel;
            Altilertitle = altilertitle;
            Altilerage = altilerage;
        }
        public DataModel(string solderpassportID)
        {
            solderPassportID = solderpassportID;
        }
        public DataModel()
        {

        }
        public string solderPassportID
        {
            get
            {
                return solderpassportID;
            }

            set
            {
                if (value != null)
                    solderpassportID = value;
                else
                    throw new ArgumentNullException();
            }
        }
        public string SolderName
        {
            get
            {
                return soldername;
            }

            set
            {
                if (value != null)
                    soldername = value;
                else
                    throw new ArgumentNullException();
            }
        }
        public string SoldeSurername
        {
            get
            {
                return soldesurername;
            }
            set
            {
                if (value != null)
                    soldesurername = value;
                else
                    throw new ArgumentNullException();
            }
        }
        public string Solderfname
        {
            get
            {
                return solderfname;
            }
            set
            {
                if (value != null) solderfname = value;
                else
                    throw new ArgumentNullException();
            }
        }
        public int Solderage
        {
            get { return solderage; }
            set { solderage = value; }
        }
        public string Soldertitle
        {
            get { return soldertitle; }
            set { soldertitle = value; }
        }
        public string Solderclassical
        {
            get { return solderclassical; }
            set { solderclassical = value; }
        }
        public string Soldercompany
        {
            get { return soldercompany; }
            set { soldercompany = value; }
        }
        public string Solderbattalion
        {
            get { return solderbattalion; }
            set { solderbattalion = value; }
        }
        public string Solderbowl
        {
            get { return solderbowl; }
            set { solderbowl = value; }
        }
        public string Artilleryname
        {
            get { return artilleryname; }
            set
            {
                if (value != null) artilleryname = value;
                else
                    throw new ArgumentNullException();
            }
        }
        public string Artillerymodel
        {
            get { return artillerymodel; }
            set
            {
                if (value != null) artillerymodel = value;

                else
                    throw new ArgumentNullException();
            }
        }
        public string Altilertitle
        {
            get { return altilertitle; }
            set
            {
                if (value != null) altilertitle = value;

                else
                    throw new ArgumentNullException();
            }
        }
        public int Altilerage
        {
            get { return altilerage; }
            set { altilerage = value; }
        }
        public List<string> DatamodelValue()
        {
            List<string> list = new List<string>();
            list.Add("Անձնագրի ID  ");
            list.Add("Անուն  ");
            list.Add("Ազգանուն  ");
            list.Add("Հայրանուն  ");
            list.Add("Տարիք  ");
            list.Add("Կոչում  ");
            list.Add("Դասակ  ");
            list.Add("Վաշտ  ");
            list.Add("Գումարտակ  ");
            list.Add("Գունդ  ");
            list.Add("Հրետանու Անուն  ");
            list.Add("Հրետանու Մոդել  ");
            list.Add("Հրետանու Տեսակ  ");
            list.Add("Հրետանու Արտադրման տարեթիվ  ");
            return list;
        }

        public List<string> DatamodelValueCalculate()
        {
            List<string> list = new List<string>();
            list.Add("Հակառակորդի կորդինատներ X ");
            list.Add("Հակառակորդի կորդինատներ Y ");
            list.Add("Նախնական արագություն (կմ/ժ) ");
            list.Add("Հրետանու կորդինատներ X  ");
            list.Add("Հրետանու կորդինատներ Y  ");
            list.Add("Արկի կրակման անկյուն  ");
            list.Add("Թռիչքի տևողությունը (ր.)  ");
            list.Add("Մաքսիմալ բարձրությունը (մ.)  ");
            return list;
        }
        public int DatamodelValueAge(int index)
        {
            if (index == 4)
                return Solderage;
            else
                return Altilerage;
        }
        public string DatamodelValueStringParametrs(int index)
        {
            string[] da = new string[13];
            da[0] = solderPassportID;
            da[1] = SolderName;
            da[2] = SoldeSurername;
            da[3] = Solderfname;
            da[4] = Solderage.ToString();
            da[5] = Soldertitle;
            da[6] = Solderclassical;
            da[7] = Soldercompany;
            da[8] = Solderbattalion;
            da[9] = Solderbowl;
            da[10] = Artilleryname;
            da[11] = Artillerymodel;
            da[12] = Altilertitle;

            return da[index];
        }

    }
}
