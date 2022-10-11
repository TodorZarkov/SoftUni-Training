using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string line = Console.ReadLine();
            while (line != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] initData = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Pokemon pokemon = new Pokemon(initData[1], initData[2], int.Parse(initData[3]));
                if (!trainers.ContainsKey(initData[0]))
                {
                    Trainer trainer = new Trainer(initData[0], pokemon);
                    trainers.Add(trainer.Name,trainer);
                }
                else
                {
                    trainers[initData[0]].Pokemons.Add(pokemon);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == line))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.Pokemons.RemoveWhere(pokemon => pokemon.Health <= 0);

                    }
                }

                line = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
