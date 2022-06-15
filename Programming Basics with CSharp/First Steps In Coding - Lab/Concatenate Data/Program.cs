using System;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Напишете програма, която прочита от конзолата име, фамилия, възраст и град и печата следното съобщение:
            //&quot; You are &lt; firstName & gt; &lt; lastName & gt;, a & lt; age & gt; -years old person from & lt; town & gt;.&quot;

            string name = Console.ReadLine();
            string surnameName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine($"You are {name} {surnameName}, a {age}-years old person from {town}.");

        }
    }
}
