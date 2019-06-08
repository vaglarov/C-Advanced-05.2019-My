namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        public Car()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string ToStringSimple()
        {
            return $"Make: {this.Make}" +
                $"{Environment.NewLine}Model: {this.Model}" +
                $"{Environment.NewLine}Year: {this.Year}";
        }

        public void Drive(int distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption/100) >= 0;
            if (canContinue)
                this.FuelQuantity -= distance * this.FuelConsumption / 100;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough fuel to perform this trip!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();

        }

        public override string ToString()
        {
            return $"Make: {Make}{Environment.NewLine}" +
             $"Model: {Model}{Environment.NewLine}" +
             $"Year: {Year}";
        }

    }
}
