namespace RawData
{
using System;
using System.Collections.Generic;
using System.Text;
    public class Cargo
    {
        private int weight;
        private string flamable;
        public Cargo(int weight, string flamable)
        {
            CargoWeight = weight;
            Flamable = flamable;
        }
        public int CargoWeight { get => weight; set => weight = value; }
        public string Flamable { get => flamable; set => flamable = value; }
    }
}
