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

        public Car()
        {
            this.Model = model;
            this.Make = make;
            this.Year = year;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
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

        public override string ToString()
        {
            return $"Make: {Make}{Environment.NewLine}" +
                $"Model: {Model}{Environment.NewLine}" +
                $"Year: {Year}";
        }
    }
}
