namespace RawData
{
using System;
using System.Collections.Generic;
using System.Text;
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tires tires;
        public Car(string model,Engine engine,Cargo cargo,Tires tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public Cargo Cargo { get => cargo; set => cargo = value; }
        public Tires Tires { get => tires; set => tires = value; }
    }
}
