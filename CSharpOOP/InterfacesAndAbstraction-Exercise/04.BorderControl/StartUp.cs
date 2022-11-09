
namespace _04.BorderControl
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizens = new List<IIdentifiable>();
            string[] line = Console.ReadLine().Split(' ');

            while (line[0] != "End")
            {
                if(line.Length == 3)
                {
                    Citizen person = new Citizen(line[0], int.Parse(line[1]), line[2]);
                    citizens.Add(person);
                }
                else if (line.Length == 2)
                {
                    Robot robot = new Robot(line[0], line[1]);
                    citizens.Add(robot);
                }
                line = Console.ReadLine().Split(' ');
            }


            string fakeEnd = Console.ReadLine();
            citizens.Where(c=>c.Id.EndsWith(fakeEnd)).ToList().ForEach(c=>Console.WriteLine(c.Id));

        }
    }
}
