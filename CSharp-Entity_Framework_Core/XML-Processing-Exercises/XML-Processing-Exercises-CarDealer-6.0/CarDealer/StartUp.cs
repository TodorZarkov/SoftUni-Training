namespace CarDealer;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext context = new CarDealerContext();

        //string suppliersXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, suppliersXml));

        //string partsXml = File.ReadAllText(@"..\..\..\Datasets\parts.xml");
        //Console.WriteLine(ImportParts(context, partsXml));

        //string carsXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
        //Console.WriteLine(ImportCars(context, carsXml));

        //string customersXml = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
        //Console.WriteLine(ImportCustomers(context, customersXml));

        //string salesXml = File.ReadAllText(@"..\..\..\Datasets\sales.xml");
        //Console.WriteLine(ImportSales(context, salesXml));

        //Console.WriteLine(GetCarsWithDistance(context));

        //Console.WriteLine(GetCarsFromMakeBmw(context));

        //Console.WriteLine(GetLocalSuppliers(context));

        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        Console.WriteLine(GetTotalSalesByCustomer(context));

    }

    //p. 09. Import Suppliers 
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();

        var serializedSuppliers =
            utils.XmlDeserialize<SupplierDtoImport[]>(inputXml, "Suppliers");

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

        var deserializedParts = utils.XmlDeserialize<PartDtoImport[]>(inputXml, "Parts");

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

        var deserializedCars = utils.XmlDeserialize<CarDtoImport[]>(inputXml, "Cars");

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

        var deserializedCustomers = utils.XmlDeserialize<CustomerDtoImport[]>(inputXml, "Customers");

        var validCustomers = deserializedCustomers.Where(c => !string.IsNullOrEmpty(c.Name));

        var customers = mapper.Map<Customer[]>(validCustomers);

        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }

    //p. 13. Import Sales 
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var deserializedSales = utils.XmlDeserialize<SaleDtoImport[]>(inputXml, "Sales");

        var validCarIds = context.Cars.Select(c => c.Id).ToHashSet();
        var validCustormeIds = context.Customers.Select(c => c.Id).ToHashSet();
        var validSales =
            deserializedSales.Where(s => s
                .CarId.HasValue
                && validCarIds.Contains(s.CarId.Value)).ToHashSet();
                //&& validCustormeIds.Contains(s.CustomerId)).ToHashSet();

        var sales = mapper.Map<Sale[]>(validSales);
        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}";
    }

    //p. 14. Export Cars With Distance 
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var cars = context.Cars
            .Where(c => c.TraveledDistance > 2 - 000 - 000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<CarWithDistanceDtoExport>(mapper.ConfigurationProvider)
            .ToArray();

        return utils.XmlSerialize<CarWithDistanceDtoExport[]>(cars, "cars");
    }

    //p. 15. Export Cars From Make BMW 
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var cars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ProjectTo<CarByMakeDtoExport>(mapper.ConfigurationProvider)
            .ToArray();

        return utils.XmlSerialize<CarByMakeDtoExport[]>(cars, "cars");
    }

    //p. 16. Export Local Suppliers 
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var suppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .ProjectTo<SupplierWthLocalePartsDtoExport>(mapper.ConfigurationProvider)
            .ToArray();

        return utils.XmlSerialize<SupplierWthLocalePartsDtoExport[]>(suppliers, "suppliers");
    }

    //p. 17. Export Cars With Their List Of Parts 
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var cars = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ProjectTo<CarWithPartsDtoExport>(mapper.ConfigurationProvider)
            .ToArray();

        return utils.XmlSerialize<CarWithPartsDtoExport[]>(cars, "cars");
    }

    //p. 18. Export Total Sales By Customer 
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var customers = context.Customers
            .Join(context.Sales, c => c.Id, s => s.CustomerId, (c, s) => new { c, s })
            .Join(context.Cars, cs => cs.s.CarId, ca => ca.Id, (cs, ca) => new { cs, ca })
            .Join(context.PartsCars, csca => csca.ca.Id, pc => pc.CarId, (csca, pc) => new { csca, pc })
            .Join(context.Parts, cscapc => cscapc.pc.PartId, p => p.Id, (cscapc, p) => new { cscapc, p })
            .GroupBy(grpIn => new
            {
                CarId = grpIn.cscapc.csca.ca.Id,
                FullName = grpIn.cscapc.csca.cs.c.Name,

                IsYoungDriver = grpIn.cscapc.csca.cs.c.IsYoungDriver,
            })
            .Select(inn => new
            {
                FullName = inn.Key.FullName,
                Price = inn.Sum(g => g.p.Price),

                IsYoungDriver = inn.Key.IsYoungDriver,
            })
            .GroupBy(grpOut => new
            {
                FullName = grpOut.FullName,
                IsYoungDriver = grpOut.IsYoungDriver,

            })
            .Select(outt => new
            {
                FullName = outt.Key.FullName,
                CarsBought = outt.Count(),
                TotalPrice = (outt.Sum(x => x.Price)//)),
                * (1 - (outt.Key.IsYoungDriver?0.05m:0m))),// - (outt.Key.Discount/100m)),
            })
            .OrderByDescending(c => c.TotalPrice)
            .ToArray()
            .Select(f => new CustomerWithSalesDtoExport
            {
                FullName = f.FullName,
                TotalPrice = 
                    Math.Round(f.TotalPrice, 2, MidpointRounding.ToZero)
                    .ToString("f2"),
                CarsBought = f.CarsBought
            })
            .ToArray();
            //.ToQueryString();


        //return customers;
        return utils.XmlSerialize<CustomerWithSalesDtoExport[]>(customers, "customers");
    }

    //p. 19. Export Sales With Applied Discount 

}