namespace CarDealer;

using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //string suppliersXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, suppliersXml));
        
        //string partsXml = File.ReadAllText(@"..\..\..\Datasets\parts.xml");
        //Console.WriteLine(ImportParts(context, partsXml));
        
        //string carsXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
        //Console.WriteLine(ImportCars(context, carsXml));
        
        string customersXml = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
        Console.WriteLine(ImportCustomers(context, customersXml));

    }

    //p. 09. Import Suppliers 
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();

        var serializedSuppliers =
            utils.XmlDeserializer<SupplierDtoImport[]>(inputXml, "Suppliers");

        var validSuppliers = serializedSuppliers.Where(s => s.Name != null &&
                                                            s.IsImporter != null);

        IMapper mapper = utils.CreateMapper();

        var suppliers = mapper.Map<Supplier[]>(validSuppliers);
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    //p.10. Import Parts 
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var deserializedParts = utils.XmlDeserializer<PartDtoImport[]>(inputXml, "Parts");

        var validSupplierIds = context.Suppliers
            .Select(s => s.Id)
            .ToHashSet();

        var validParts = deserializedParts
            .Where(p => validSupplierIds.Contains(p.SupplierId))
            .ToArray();

        var parts = mapper.Map<Part[]>(validParts);

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}";
    }

    //p. 11. Import Cars 
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var deserializedCars = utils.XmlDeserializer<CarDtoImport[]>(inputXml, "Cars");

        var validPartIds = context.Parts
            .Select(p => p.Id)
            .ToHashSet();

        var validCars = deserializedCars
            .Where(c => c.PartIds.All(ids => validPartIds.Contains(ids.Id)) &&
                        !string.IsNullOrEmpty(c.Make) &&
                        !string.IsNullOrEmpty(c.Model))
            .ToArray();



        var cars = mapper.Map<Car[]>(validCars);

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Length}";
    }

    //p. 12. Import Customers 
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var deserializedCustomers = utils.XmlDeserializer<CustomerDtoImport[]>(inputXml, "Customers");

        var validCustomers = deserializedCustomers.Where(c => !string.IsNullOrEmpty(c.Name));

        var customers = mapper.Map<Customer[]>(validCustomers);

        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }

    //p. 13. Import Sales 

}