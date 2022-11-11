
namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LieutenantGeneral:Private
    {
        private Dictionary<string, Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params string[] idS) : base(id, firstName, lastName, salary)
        {
        }
    }
}
