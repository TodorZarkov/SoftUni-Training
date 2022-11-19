using System;
using ValidationAttributes.Utilitis;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "gosho",
                 15
             );

            bool isvalidentity = Validator.IsValid(person);

            Console.WriteLine(isvalidentity);
        }
    }
}
