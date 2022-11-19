
namespace CommandPattern.Core
{
    using System;

    using Contracts;
    using Exceptions;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string[] arguments = new string[tokens.Length - 1];
            tokens.CopyTo(arguments, 1);
            
            Type type = Type.GetType(command + "Command");
            if (type == null)
            {
                throw new NoSuchCommandException();
            }

            var objCommand = (ICommand)Activator.CreateInstance(type);

            return objCommand.Execute(arguments);
        }
    }
}
