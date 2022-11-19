
namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Exceptions;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string[] arguments = tokens.Skip(1).ToArray();

            var assembly = Assembly.GetEntryAssembly();


            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == (command + "Command"));
            if (type == null)
            {
                throw new NoSuchCommandException();
            }

            var execute = type.GetMethods().FirstOrDefault
                (m => m.Name == "Execute");
            if (execute == null)
            {
                throw new MethodNotImplementedException();
            }


            var objCommand = (ICommand)Activator.CreateInstance(type);

            return objCommand.Execute(arguments);
        }
    }
}
