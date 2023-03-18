﻿namespace CarDealer.Models;
                
public class Customer
{
    public Customer()
    {
        Sales = new HashSet<Sale>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public bool IsYoungDriver { get; set; }

    public ICollection<Sale> Sales { get; set; }
}
