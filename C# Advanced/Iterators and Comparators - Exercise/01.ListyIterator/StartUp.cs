using System;
using System.Linq.Expressions;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> list;

            string[] create = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (create.Length == 1)
            {
                list = new ListyIterator<string>();
            }
            else
            {
                string[] parameters = new string[create.Length - 1];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = create[i + 1];
                }
                list = new ListyIterator<string>(parameters);
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException exeption)
                        {

                            Console.WriteLine(exeption.Message);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
