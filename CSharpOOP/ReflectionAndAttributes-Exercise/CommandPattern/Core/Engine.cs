using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command = Console.ReadLine();
            string result = commandInterpreter.Read(command);
            while (result != null)
            {
                Console.WriteLine(result);
                command = Console.ReadLine();
                result = commandInterpreter.Read(command);
            }


        }
    }
}
