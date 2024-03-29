﻿using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();
        List<Box> boxes = new List<Box>();
        while (line != "end")
        {
            string[] data = line.Split(' ').ToArray();
            //"{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
            //The Price of one box has to be calculated: itemQuantity * itemPrice.

            Box box = new Box { SerialNumber = int.Parse(data[0]), ItemQuantity = int.Parse(data[2]) };
            box.Item.Name = data[1];
            box.Item.Price = double.Parse(data[3]);
            boxes.Add(box);

            line = Console.ReadLine();
        }
        boxes.Sort(compareBoxes);
        foreach (Box box in boxes)
        {
            Console.WriteLine($"{box.SerialNumber}");
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.Price():f2}");
        }
        

    }

    private static int compareBoxes (Box a, Box b)
    {
        if (a.Price() > b.Price())
            return -1;
        else if (a.Price() < b.Price())
            return 1;
        else
            return 0;
    }
}

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }

}

class Box
{
    public Box()//constructor//
    {
        Item = new Item();
    }
    public Item Item { get; set; }
    public int SerialNumber { get; set; }
    public int ItemQuantity { get; set; }
    public double Price()
    {
        return this.Item.Price * this.ItemQuantity;
    }

}