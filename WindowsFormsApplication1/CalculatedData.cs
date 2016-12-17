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
            FlightDuration = Math.Abs( 2 * InitialSpeed * (Math.Sin(ProjectileAngle) / 10)); 
            V1=InitialSpeed * Math.Cos(ProjectileAngle);
            V2 = InitialSpeed * Math.Sin(ProjectileAngle);
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
    }
}
