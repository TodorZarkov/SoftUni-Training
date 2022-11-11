
namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Soldier : ISoldier
    {
        string id;
        string firstName;
        string lastName;

        public Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
