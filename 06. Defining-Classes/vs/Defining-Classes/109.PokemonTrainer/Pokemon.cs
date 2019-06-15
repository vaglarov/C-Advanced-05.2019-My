namespace _109.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pokemon
    {
        private string name;
        private string element;
        private int healt;

        public Pokemon(string name,string element,int healt)
        {
            this.Name = name;
            this.Element = element;
            this.Healt = healt;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Element
        {
            get => element;
            set => element = value;
        }
        public int Healt
        {
            get => healt;
            set => healt = value;
        }

        public void Demage()
        {
            this.Healt -= 10;
            if (this.Healt < 0)
            {
                this.Healt = 0;
            }
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Element} {this.Healt}";
        }
    }
}
