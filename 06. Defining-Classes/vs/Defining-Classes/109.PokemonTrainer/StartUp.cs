namespace _109.PokemonTrainer
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Trainer> dictTrainer = new Dictionary<string, Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                Queue<string> qLine = new Queue<string>(input.Split(" ",StringSplitOptions.RemoveEmptyEntries));
                string trainerName = next(qLine);
                if (!dictTrainer.ContainsKey(trainerName))
                {
                    Trainer trainer = TrainerFactory(trainerName, qLine);
                    dictTrainer.Add(trainer.Name, trainer);
                }
                else
                {
                    Trainer currentTrainer = dictTrainer[trainerName];
                    AddPokemonInTrainerList(currentTrainer, qLine);
                }
            }
            string tournamentCommand;
            while ((tournamentCommand = Console.ReadLine()) != "End")
            {
                foreach (var trainer in dictTrainer.Values)
                {
                    trainer.Tournament(tournamentCommand.ToLower());
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Print(dictTrainer);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Print(Dictionary<string, Trainer> dictTrainer)
        {
            foreach (var trainer in dictTrainer.Values.OrderByDescending(x=>x.Badge))
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static void AddPokemonInTrainerList(Trainer currentTrainer, Queue<string> qLine)
        {
            Pokemon currentPokemon = PokemonFactory(qLine);
            currentTrainer.AddPokemon(currentPokemon);
        }

        private static Trainer TrainerFactory(string trainerName, Queue<string> qLine)
        {
            Pokemon currentPokemon = PokemonFactory(qLine);
            Trainer newTrainer = new Trainer(trainerName);
            newTrainer.AddPokemon(currentPokemon);
            return newTrainer;
        }

        private static Pokemon PokemonFactory(Queue<string> qLine)
        {
            string namePokemon = next(qLine);
            string elementPokemon = next(qLine).ToLower();
            int healtPokemon = int.Parse(next(qLine));

            Pokemon currentPokemon = new Pokemon(namePokemon, elementPokemon, healtPokemon);
            return currentPokemon;
        }

        static Func<Queue<string>, string> next = q => q.Dequeue();
    }
}
