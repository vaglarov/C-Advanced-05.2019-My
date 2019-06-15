using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _109.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badge;
        private Dictionary<string, Pokemon> pokemonCatalog;

        public Trainer(string name, int badge = 0)
        {
            pokemonCatalog = new Dictionary<string, Pokemon>();
            this.Name = name;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Badge
        {
            get => badge;
            set => badge = value;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            if (!pokemonCatalog.ContainsKey(pokemon.Name))
            {
            pokemonCatalog.Add(pokemon.Name, pokemon);
            }
        }

        public void Tournament(string elementPokemon)
        {
            var haveCurrentPokemonElement = pokemonCatalog.Values.FirstOrDefault(element => element.Element == elementPokemon);
            if (haveCurrentPokemonElement != null)
            {
                this.badge += 1;
            }
            else
            {
                DemageAllPokemon(pokemonCatalog);
            }
        }

        private void DemageAllPokemon(Dictionary<string, Pokemon> pokemonCatalog)
        {
            foreach (var pokemon in pokemonCatalog.Values)
            {
                pokemon.Demage();
            }
            DeleteFormPokemonCatalog();
        }

        private void DeleteFormPokemonCatalog()
        {
            var listItemToRemoce = pokemonCatalog.Values.Where(pokemon => pokemon.Healt == 0).ToList();
            foreach (var pokemon in listItemToRemoce)
            {
                pokemonCatalog.Remove(pokemon.Name);
            }
        }

        public override string ToString()
        {
            int countPolkemonList = pokemonCatalog.Count();

            return $"{this.Name} {this.Badge} {countPolkemonList}"; 
        }
    }
}
