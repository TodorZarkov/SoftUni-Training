﻿


namespace _05.BirthdayCelebrations
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Citizen : IPerson, IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;



        private Citizen()
        {
            Food = 0;
        }
        public Citizen(string name, int age, string id, string birthdate) : this()
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name must not be empty");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive.");
                }
                age = value;
            }
        }

        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The id cannot be empty.");
                }
                id = value;
            }
        }

        public string Birthdate
        {
            get { return birthdate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birthdate cannot be empty.");
                }
                birthdate = value;
            }
        }




        public int Food
        {
            get => food;
            private set
            {
                food = value;
            }
        }


        public void BuyFood()
        {
            Food += 10;
        }



       
    }
}
