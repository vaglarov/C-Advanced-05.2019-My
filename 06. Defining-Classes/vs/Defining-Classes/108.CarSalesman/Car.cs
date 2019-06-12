using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int? weight;
        private string color;

        public Car(string model, Engine engine, int? weight=null, string color=null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public int? Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }
        public override string ToString()
        {
            return $"{Model}:{Environment.NewLine}" +
                    $"  {Engine.Model}:{Environment.NewLine}" +
                    $"    Power: {Engine.Power}{Environment.NewLine}" +
                    $"    Displacement: {IsNullOrValue(Engine.Displacement)}{Environment.NewLine}" +
                    $"    Efficiency: {IsNullOrValue(Engine.Efficiency)}{Environment.NewLine}" +
                    $"  Weight: {IsNullOrValue(Weight)}{Environment.NewLine}" +
                    $"  Color: {IsNullOrValue(Color)}";

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
