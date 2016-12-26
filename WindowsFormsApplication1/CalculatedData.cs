using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class CalculatedData
    {
        public CalculatedData()
        {

        }

        public CalculatedData(double adversaryx, double adversaryy, double initialspeed, double altilleryx, double altilleryy, double projectilangle)
        {

            AdversaryX = adversaryx;
            AdversaryY = adversaryy;
            InitialSpeed = initialspeed;
            AltilleryX = altilleryx;
            AltilleryY = altilleryy;
            ProjectileAngle = projectilangle;
            FlightDuration = 2*InitialSpeed * (Math.Sin(ProjectileAngle * (Math.PI / 180.0)) / 10);
            V1 = InitialSpeed * Math.Cos(ProjectileAngle * (Math.PI / 180.0));
            V2 = InitialSpeed * Math.Sin(ProjectileAngle*(Math.PI / 180.0));
            H = Math.Pow(InitialSpeed, 2) * Math.Pow(Math.Sin(ProjectileAngle*(Math.PI / 180.0)), 2) / 20;
        }

        private double adversaryX;
        private double adversaryY;
        private double initialSpeed;
        private double altilleryX;
        private double altilleryY;
        private double projectileAngle;
        private double flightDuration;
        private int maxSize;
        private double v1;
        private double v2;
        private double h;

        public double H
        {
            get { return h; }


            set
            {
               h= value ;
            }

        }

        public double AdversaryX
        {
            get { return adversaryX; }
            set { adversaryX = value; }
        }
        public double AdversaryY
        {
            get { return adversaryY; }
            set { adversaryY = value; }
        }
        public double InitialSpeed
        {
            get { return initialSpeed; }
            set { initialSpeed = value; }
        }
        public double AltilleryX
        {
            get { return altilleryX; }
            set { altilleryX = value; }
        }
        public double AltilleryY
        {
            get { return altilleryY; }
            set { altilleryY = value; }
        }
        public double ProjectileAngle
        {
            get { return projectileAngle; }
            set { projectileAngle = value; }
        }
        public double FlightDuration
        {
            get { return flightDuration; }
            set
            {
                flightDuration = value;
            }
        }
        public int MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        public double V1
        {
            get { return v1; }
            set { v1 = value; }
        }
        public double V2
        {
            get { return v2; }
            set { v2 = value; }
        }
        private void ProjectileTrajectoryCalculation()
        {
            double alpha = ProjectileAngle;
            double v0 = InitialSpeed;

        }
        public string ListCalculateData(int index)
        {
            string[] list = new string[8];

            list[0] = AdversaryX.ToString();
            list[1] = AdversaryY.ToString();
            list[2] = InitialSpeed.ToString();
            list[3] = AltilleryX.ToString();
            list[4] = AltilleryY.ToString();
            list[5] = ProjectileAngle.ToString();
            list[6] = FlightDuration.ToString();
            list[7] = MaxSize.ToString();
            
            return list[index];
        }
    }
}
