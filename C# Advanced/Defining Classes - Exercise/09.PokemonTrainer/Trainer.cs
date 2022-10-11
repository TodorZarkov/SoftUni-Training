using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name,Pokemon pokemon)
        {
            Name = name;
            Badges = 0;
            Pokemons = new HashSet<Pokemon>();
            Pokemons.Add(pokemon);
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public HashSet<Pokemon> Pokemons { get; set; }
    }
}
