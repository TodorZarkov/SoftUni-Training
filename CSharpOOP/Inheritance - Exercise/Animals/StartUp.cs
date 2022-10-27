using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string line1 = Console.ReadLine();
            while (line1 != "Beast!")
            {
                try
                {

                    string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string name = animalData[0];
                    int age;
                    string gender = animalData[2];

                    try
                    {
                        age = int.Parse(animalData[1]);
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    switch (line1)
                    {

                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                line1 = Console.ReadLine();
            }

            animals.ForEach(a => Console.WriteLine(a.Print()));
        }
    }
}
