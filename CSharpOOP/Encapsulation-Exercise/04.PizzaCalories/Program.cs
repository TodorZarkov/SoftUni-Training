using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");
            Dough dough;
            Topping topping;
            try
            {
                Pizza pizza = new Pizza(data[1]);
                while (data[0] != "END")
                {
                    string engridient = data[0];

                    if (engridient == "Dough")
                    {
                        string flourType = data[1];
                        string bakingTechnique = data[2];
                        int grams = int.Parse(data[3]);
                        dough = new Dough(flourType, bakingTechnique, grams);
                        pizza.Dough = dough;
                    }
                    else if (engridient == "Topping")
                    {
                        string toppingType = data[1];
                        int grams = int.Parse(data[2]);
                        topping = new Topping(toppingType, grams);
                        pizza.AddTopping(topping);
                    }
                    
                    data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
