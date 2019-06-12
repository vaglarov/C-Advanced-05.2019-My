using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        //        •	string Model
        //•	double FuelAmount
        //•	double FuelConsumptionPerKilometer
        //•	double Travelled distance

        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private double travelledDistance;
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumptionFor1km;
            this.TravelledDistance = 0;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                 this.model = value;
            }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumptionFor1km
        {
            get { return this.fuelConsumptionFor1km; }
            set { this.fuelConsumptionFor1km = value; }
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public void Drive(int km)
        {
            double neededFuel = this.FuelConsumptionFor1km * km;
            if (neededFuel<=this.FuelAmount)
            {
                this.TravelledDistance += km;
                this.FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive") ;
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}"; 
        }
    }
}
