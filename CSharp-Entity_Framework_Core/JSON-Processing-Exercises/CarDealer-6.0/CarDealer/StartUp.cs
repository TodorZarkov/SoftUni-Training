namespace CarDealer;

using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        string suppliersJsonString = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
        Console.WriteLine(ImportSuppliers(context, suppliersJsonString));
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

}