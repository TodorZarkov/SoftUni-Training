﻿namespace Heroes.Models.Heroes
{
    using Contracts;
    using System;
    using System.Xml.Linq;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;

        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set => weapon = value ?? throw new ArgumentException("Weapon cannot be null.");
        }

        public bool IsAlive => Health > 0 ? true : false;

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int reducedArmour = Armour - points;
            if(reducedArmour <= 0)
            {
                Armour = 0;

                int reducedHealth = Health + reducedArmour;
                if(reducedHealth <= 0)
                {
                    Health = 0;
                }
                else
                {
                    Health = reducedHealth;
                }
            }
            else
            {
                Armour = reducedArmour;
            }
        }
    }
}
