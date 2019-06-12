namespace RawData
{
using System;
using System.Collections.Generic;
using System.Text;
    public class Tires
    {  
        private double pressure;
        private int age;
        private double pressure1;
        private int age1;
        private double pressure2;
        private int age2;
        private double pressure3;
        private int age3;
        public Tires(double pressure, int age, double pressure1, int age1,double pressure2, int age2, double pressure3, int age3)
        {
            Pressure = pressure;
            Age = age;
            Pressure1 = pressure;
            Age1 = age;
            Pressure2 = pressure;
            Age2 = age;
            Pressure3 = pressure;
            Age3 = age;
        }
        public double Pressure { get => pressure; set => pressure = value; }
        public int Age { get => age; set => age = value; }
        public double Pressure1 { get => pressure1; set => pressure1 = value; }
        public int Age1 { get => age1; set => age1 = value; }
        public double Pressure2 { get => pressure2; set => pressure2 = value; }
        public int Age2 { get => age2; set => age2 = value; }
        public double Pressure3 { get => pressure3; set => pressure3 = value; }
        public int Age3 { get => age3; set => age3 = value; }

        public bool TooLowPressure()
        {
            bool result = false;
            if (Pressure<1||Pressure1<1||Pressure2<1||Pressure3<1)
            {
                result = true;
            }
            return result;
        }
    }
}
