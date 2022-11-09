
namespace _03.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(' ').ToList();
            List<string> urls = Console.ReadLine().Split(' ').ToList();
            Smartphone smartphone = new Smartphone();
            StationaryPhone phone = new StationaryPhone();

            numbers.ForEach(n =>
            {
                try
                {
                    if(n.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(n));
                    }
                    else
                    {
                        Console.WriteLine(phone.Call(n));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                //catch (Exception e)
                //{
                //    throw e;
                //}
            });


            urls.ForEach(u =>
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(u)); ;
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                //catch (Exception e)
                //{

                //    throw e;
                //}
            });
        }
    }
}
