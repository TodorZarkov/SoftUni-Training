﻿namespace CarDealer;

using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //string suppliersJsonString = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, suppliersJsonString));
        
        //string partsJsonString = File.ReadAllText(@"..\..\..\Datasets\parts.json");
        //Console.WriteLine(ImportParts(context, partsJsonString));
        
        //string carsJsonString = File.ReadAllText(@"..\..\..\Datasets\cars.json");
        //Console.WriteLine(ImportCars(context, carsJsonString));
        
        string customersJsonString = File.ReadAllText(@"..\..\..\Datasets\customers.json");
        Console.WriteLine(ImportCustomers(context, customersJsonString));

    }

    //mapper
    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<CarDealerProfile>()));
    }

    //json settings
    public static JsonSerializerOptions CreateSettingsCamelIndentedIgnorNull()
    {
        return new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

    }

    

    //p.09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var jsonSettings = CreateSettingsCamelIndentedIgnorNull();

        var supplierDtos = JsonSerializer.Deserialize<SupplierDtoImport[]>(inputJson, jsonSettings);

        IMapper mapper = CreateMapper();
        var suppliers = mapper.Map<Supplier[]>(supplierDtos);
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}.";
    }

    //p.10. Import Parts 
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var jsonSettings = CreateSettingsCamelIndentedIgnorNull();
        var partDtos = JsonSerializer.Deserialize<PartDtoImport[]>(inputJson, jsonSettings);


        var validSupplierIds = context.Suppliers.Select(s => s.Id).ToHashSet();
        var validParts = partDtos.Where(p => validSupplierIds.Contains(p.SupplierId)).ToArray();

        IMapper mapper = CreateMapper();
        var parts = mapper.Map<Part[]>(validParts);

        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}.";
    }

    //p.11. Import Cars 
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var jsonSettings = CreateSettingsCamelIndentedIgnorNull();
        var carDtos = JsonSerializer.Deserialize<List<CarDtoImport>>(inputJson, jsonSettings);

        int carsAdded = 0;
        foreach (var cd in carDtos)
        {
            var car = new Car
            {
                Make = cd.Make,
                Model = cd.Model,
                TraveledDistance = cd.TraveledDistance,
            };

            var parts = context.Parts.Where(p => cd.PartsId.Contains(p.Id)).ToList();
            foreach (var part in parts)
            {
                var partCar = new PartCar
                {
                    Part = part,
                    Car = car
                };
                context.PartsCars.Add(partCar);
            }

            carsAdded++;
        }

        context.SaveChanges();

        return $"Successfully imported {carsAdded}.";
    }

    //p.12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var jsonSettings = CreateSettingsCamelIndentedIgnorNull();
        var customerDtos = JsonSerializer.Deserialize<CustomerDtoImport[]>(inputJson, jsonSettings);

        IMapper mapper = CreateMapper();
        var customers = mapper.Map<Customer[]>(customerDtos);
        context.Customers.AddRange(customers);

        context.SaveChanges();

        return $"Successfully imported {customers.Length}.";
    }

    //p. 13. Import Sales 

}