using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        //•	Model  string
        //•	Power  int
        //•	Displacement  int
        //•	Efficiency string
        private string model;
        private int power;
        private int? displacement;
        private string efficiency;

        public Engine(string model, int power, int? displacement=null, string efficiency= null)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public int? Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        public override string ToString()
        {
            return $"{Model}:{Environment.NewLine}" +
                $"  Power: {Power}{Environment.NewLine}" +
                $"  Displacement: {IsNullOrValue(Displacement)}{Environment.NewLine}" +
                $"  Efficiency: {IsNullOrValue(Efficiency)}";

        }

        private object IsNullOrValue(object obj)
        {
            if (obj == null)
            {
                return "n/a";
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
