using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight = default(int), string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }
        public int Weight
        {
            get => weight;
            set => weight = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public override string ToString()
        {
            string engineDisplacement = (this.Engine.Displacement == 0) ? "n/a" : this.Engine.Displacement.ToString();
            string carWeight = (this.Weight == 0) ? "n/a" : this.Weight.ToString();

            return $"{Model}:{Environment.NewLine}" +
                    $"  {Engine.Model}:{Environment.NewLine}" +
                    $"    Power: {Engine.Power}{Environment.NewLine}" +
                    $"    Displacement: {engineDisplacement}{Environment.NewLine}" +
                    $"    Efficiency: {Engine.Efficiency}{Environment.NewLine}" +
                    $"  Weight: {carWeight}{Environment.NewLine}" +
                    $"  Color: {Color}";

        }
    }
}
