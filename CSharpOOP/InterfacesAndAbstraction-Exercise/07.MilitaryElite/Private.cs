
namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get => salary; set => salary = value; }
    }
}
