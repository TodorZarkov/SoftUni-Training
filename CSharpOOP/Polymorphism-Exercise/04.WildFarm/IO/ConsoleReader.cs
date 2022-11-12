
namespace WildFarm.IO
{
    using System;

    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string Readline() =>
            Console.ReadLine();
    }
}
