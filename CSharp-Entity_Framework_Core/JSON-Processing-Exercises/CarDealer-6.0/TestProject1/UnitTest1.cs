//ReSharper disable InconsistentNaming, CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using CarDealer;
using CarDealer.Data;
using CarDealer.Models;

[TestFixture]
public class Test_017_000_001
{
    private IServiceProvider serviceProvider;

    private static readonly Assembly CurrentAssembly = typeof(StartUp).Assembly;

    [SetUp]
    public void Setup()
    {
        /*Mapper.Reset();
          Mapper.Initialize(cfg => cfg.AddProfile(GetType("ProductShopProfile")));*/
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<CarDealerProfile>();
        });

        this.serviceProvider = ConfigureServices<CarDealerContext>("CarDealer");
    }

    [Test]
    public void ExportCarsWithTheirListOfPartsZeroTests()
    {
        var context = this.serviceProvider.GetService<CarDealerContext>();

        SeedDatabase(context);

        var expectedOutputValue = "[{\"car\":{\"Make\":\"Opel\",\"Model\":\"Omega\",\"TraveledDistance\":176664996},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Astra\",\"TraveledDistance\":516628215},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Astra\",\"TraveledDistance\":156191509},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Corsa\",\"TraveledDistance\":347259126},\"parts\":[{\"Name\":\"Pillar\",\"Price\":\"100.99\"},{\"Name\":\"Valance\",\"Price\":\"1002.99\"},{\"Name\":\"Front clip\",\"Price\":\"100.00\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Kadet\",\"TraveledDistance\":31737446},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Vectra\",\"TraveledDistance\":238042093},\"parts\":[{\"Name\":\"Fender\",\"Price\":\"10.34\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Insignia\",\"TraveledDistance\":225253817},\"parts\":[{\"Name\":\"Front clip\",\"Price\":\"100.00\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Astra\",\"TraveledDistance\":31468479},\"parts\":[{\"Name\":\"Roof rack\",\"Price\":\"100.99\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Corsa\",\"TraveledDistance\":282499542},\"parts\":[{\"Name\":\"Quarter panel\",\"Price\":\"100.99\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Omega\",\"TraveledDistance\":111313670},\"parts\":[{\"Name\":\"Front Right Outer door handle\",\"Price\":\"999.99\"},{\"Name\":\"Grille\",\"Price\":\"144.99\"},{\"Name\":\"Front clip\",\"Price\":\"100.00\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Insignia\",\"TraveledDistance\":168539389},\"parts\":[{\"Name\":\"Fascia\",\"Price\":\"100.34\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Vectra\",\"TraveledDistance\":433351992},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Astra\",\"TraveledDistance\":349837452},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Omega\",\"TraveledDistance\":109910837},\"parts\":[{\"Name\":\"Quarter panel\",\"Price\":\"100.99\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Corsa\",\"TraveledDistance\":241891505},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Insignia\",\"TraveledDistance\":339785118},\"parts\":[]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Omega\",\"TraveledDistance\":254808828},\"parts\":[{\"Name\":\"Decklid\",\"Price\":\"1060.34\"},{\"Name\":\"Rims\",\"Price\":\"4020.99\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Corsa\",\"TraveledDistance\":267253567},\"parts\":[{\"Name\":\"Grille\",\"Price\":\"144.99\"},{\"Name\":\"Trunk/boot/hatch\",\"Price\":\"2200.99\"}]},{\"car\":{\"Make\":\"Opel\",\"Model\":\"Omega\",\"TraveledDistance\":277250812},\"parts\":[{\"Name\":\"Unexposed bumper\",\"Price\":\"1003.34\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"F20\",\"TraveledDistance\":401291910},\"parts\":[]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"F25\",\"TraveledDistance\":476132712},\"parts\":[]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"M5 F10\",\"TraveledDistance\":140799461},\"parts\":[{\"Name\":\"Cowl screen\",\"Price\":\"1500.34\"},{\"Name\":\"Front clip\",\"Price\":\"100.00\"},{\"Name\":\"Roof rack\",\"Price\":\"100.99\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"F04\",\"TraveledDistance\":418839575},\"parts\":[{\"Name\":\"Fascia\",\"Price\":\"100.34\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"E88\",\"TraveledDistance\":27453411},\"parts\":[{\"Name\":\"Spoiler\",\"Price\":\"3000.99\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"M Roadster E85\",\"TraveledDistance\":475685374},\"parts\":[{\"Name\":\"Valance\",\"Price\":\"1002.99\"},{\"Name\":\"Front Right Outer door handle\",\"Price\":\"999.99\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"1M Coupe\",\"TraveledDistance\":39826890},\"parts\":[{\"Name\":\"Cowl screen\",\"Price\":\"1500.34\"}]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"X6 M\",\"TraveledDistance\":322292247},\"parts\":[]},{\"car\":{\"Make\":\"BMW\",\"Model\":\"E67\",\"TraveledDistance\":476830509},\"parts\":[{\"Name\":\"Grille\",\"Price\":\"144.99\"},{\"Name\":\"Fender\",\"Price\":\"10.34\"}]}]";

        var expectedOutput = JToken.Parse(expectedOutputValue);
        var actualOutputValue = StartUp.GetCarsWithTheirListOfParts(context);
        var actualOutput = JToken.Parse(actualOutputValue);

        var expected = expectedOutput.ToString(Formatting.None);
        var actual = actualOutput.ToString(Formatting.None);

        Assert.That(actual, Is.EqualTo(expected).NoClip,
            $"{nameof(StartUp.GetCarsWithTheirListOfParts)} output is incorrect!");
    }

    private static void SeedDatabase(CarDealerContext context)
    {
        var suppliersJson =
         @"[{""name"":""3M Company"",""isImporter"":true},{""name"":""Agway Inc."",""isImporter"":false},{""name"":""Anthem, Inc."",""isImporter"":true},{""name"":""Airgas, Inc."",""isImporter"":false},{""name"":""Atmel Corporation"",""isImporter"":true},{""name"":""Big Lots, Inc."",""isImporter"":true},{""name"":""Caterpillar Inc."",""isImporter"":false},{""name"":""Casey's General Stores Inc."",""isImporter"":true},{""name"":""Cintas Corp."",""isImporter"":false},{""name"":""Chubb Corp"",""isImporter"":true},{""name"":""Cintas Corp."",""isImporter"":false},{""name"":""CNF Inc."",""isImporter"":true},{""name"":""CMGI Inc."",""isImporter"":true},{""name"":""The Clorox Co."",""isImporter"":false},{""name"":""Danaher Corporation"",""isImporter"":true},{""name"":""E.I. Du Pont de Nemours and Company"",""isImporter"":false},{""name"":""E*Trade Group, Inc."",""isImporter"":true},{""name"":""Emcor Group Inc."",""isImporter"":true},{""name"":""GenCorp Inc."",""isImporter"":false},{""name"":""IDT Corporation"",""isImporter"":true},{""name"":""Level 3 Communications Inc."",""isImporter"":false},{""name"":""Merck & Co., Inc."",""isImporter"":true},{""name"":""Nicor Inc"",""isImporter"":false},{""name"":""Olin Corp."",""isImporter"":true},{""name"":""Paychex Inc"",""isImporter"":true},{""name"":""Saks Inc"",""isImporter"":false},{""name"":""Sunoco Inc."",""isImporter"":true},{""name"":""Textron Inc"",""isImporter"":true},{""name"":""VF Corporation"",""isImporter"":false},{""name"":""Wyeth"",""isImporter"":true},{""name"":""Zale"",""isImporter"":false}]";

        var partsJson =
           "[{\"name\":\"Bonnet/hood\",\"price\":1001.34,\"quantity\":10,\"supplierId\":17},{\"name\":\"Unexposed bumper\",\"price\":1003.34,\"quantity\":10,\"supplierId\":12},{\"name\":\"Exposed bumper\",\"price\":1400.34,\"quantity\":10,\"supplierId\":13},{\"name\":\"Cowl screen\",\"price\":1500.34,\"quantity\":10,\"supplierId\":22},{\"name\":\"Decklid\",\"price\":1060.34,\"quantity\":11,\"supplierId\":19},{\"name\":\"Fascia\",\"price\":100.34,\"quantity\":10,\"supplierId\":18},{\"name\":\"Fender\",\"price\":10.34,\"quantity\":10,\"supplierId\":16},{\"name\":\"Front clip\",\"price\":100,\"quantity\":10,\"supplierId\":11},{\"name\":\"Front fascia\",\"price\":11.99,\"quantity\":10,\"supplierId\":11},{\"name\":\"Grille\",\"price\":144.99,\"quantity\":10,\"supplierId\":12},{\"name\":\"Pillar\",\"price\":100.99,\"quantity\":10,\"supplierId\":32},{\"name\":\"Quarter panel\",\"price\":100.99,\"quantity\":200,\"supplierId\":12},{\"name\":\"Radiator \",\"price\":100.99,\"quantity\":10,\"supplierId\":56},{\"name\":\"Rocker\",\"price\":100.99,\"quantity\":10,\"supplierId\":41},{\"name\":\"Roof rack\",\"price\":100.99,\"quantity\":10,\"supplierId\":1},{\"name\":\"Spoiler\",\"price\":3000.99,\"quantity\":10,\"supplierId\":12},{\"name\":\"Rims\",\"price\":4020.99,\"quantity\":10,\"supplierId\":31},{\"name\":\"Trim package\",\"price\":1900.99,\"quantity\":10,\"supplierId\":65},{\"name\":\"Trunk/boot/hatch\",\"price\":2200.99,\"quantity\":300,\"supplierId\":32},{\"name\":\"Valance\",\"price\":1002.99,\"quantity\":10,\"supplierId\":22},{\"name\":\"Welded assembly\",\"price\":1020.99,\"quantity\":10,\"supplierId\":13},{\"name\":\"Front Right Outer door handle\",\"price\":999.99,\"quantity\":345,\"supplierId\":12}]";

        var carsJson =
            "[{\"make\":\"Opel\",\"model\":\"Omega\",\"traveledDistance\":176664996,\"partsId\":[38,102,23,116,46,68,88,104,71,32,114]},{\"make\":\"Opel\",\"model\":\"Astra\",\"traveledDistance\":516628215,\"partsId\":[39,62,72]},{\"make\":\"Opel\",\"model\":\"Astra\",\"traveledDistance\":156191509,\"partsId\":[48,44,112]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"traveledDistance\":347259126,\"partsId\":[36,114,88,115,72,11,50,75,20,54,8]},{\"make\":\"Opel\",\"model\":\"Kadet\",\"traveledDistance\":31737446,\"partsId\":[65,95,90]},{\"make\":\"Opel\",\"model\":\"Vectra\",\"traveledDistance\":238042093,\"partsId\":[40,29,102,73,68,7]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"traveledDistance\":225253817,\"partsId\":[108,8,102,57,23,79,103,70,67,71,46]},{\"make\":\"Opel\",\"model\":\"Astra\",\"traveledDistance\":31468479,\"partsId\":[102,54,15]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"traveledDistance\":282499542,\"partsId\":[46,58,12]},{\"make\":\"Opel\",\"model\":\"Omega\",\"traveledDistance\":111313670,\"partsId\":[22,52,59,59,10,112,99,48,8,62,27]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"traveledDistance\":168539389,\"partsId\":[42,96,45,84,66,6]},{\"make\":\"Opel\",\"model\":\"Vectra\",\"traveledDistance\":433351992,\"partsId\":[90,113,98]},{\"make\":\"Opel\",\"model\":\"Astra\",\"traveledDistance\":349837452,\"partsId\":[117,61,78,111,65,93,34,93,108,96,48]},{\"make\":\"Opel\",\"model\":\"Omega\",\"traveledDistance\":109910837,\"partsId\":[12,68,103]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"traveledDistance\":241891505,\"partsId\":[49,107,94]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"traveledDistance\":339785118,\"partsId\":[34,67,99,88,94,100,103,44,113,57,111]},{\"make\":\"Opel\",\"model\":\"Omega\",\"traveledDistance\":254808828,\"partsId\":[47,5,17]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"traveledDistance\":267253567,\"partsId\":[10,19,46]},{\"make\":\"Opel\",\"model\":\"Omega\",\"traveledDistance\":277250812,\"partsId\":[97,46,59,34,79,2,47,91,25,115,99]},{\"make\":\"BMW\",\"model\":\"F20\",\"traveledDistance\":401291910,\"partsId\":[100,60,78]},{\"make\":\"BMW\",\"model\":\"F25\",\"traveledDistance\":476132712,\"partsId\":[82,63,57,58,108,100]},{\"make\":\"BMW\",\"model\":\"M5 F10\",\"traveledDistance\":140799461,\"partsId\":[96,109,46,61,35,37,4,8,15,72,48]},{\"make\":\"BMW\",\"model\":\"F04\",\"traveledDistance\":418839575,\"partsId\":[6,79,107]},{\"make\":\"BMW\",\"model\":\"E88\",\"traveledDistance\":27453411,\"partsId\":[91,88,16]},{\"make\":\"BMW\",\"model\":\"M Roadster E85\",\"traveledDistance\":475685374,\"partsId\":[28,40,33,20,82,37,71,89,30,22,65]},{\"make\":\"BMW\",\"model\":\"1M Coupe\",\"traveledDistance\":39826890,\"partsId\":[115,69,33,44,104,4]},{\"make\":\"BMW\",\"model\":\"X6 M\",\"traveledDistance\":322292247,\"partsId\":[36,74,85]},{\"make\":\"BMW\",\"model\":\"E67\",\"traveledDistance\":476830509,\"partsId\":[84,84,10,83,7,45,39,35,61,106,38]}]";

        var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(suppliersJson);
        var parts = JsonConvert.DeserializeObject<List<Part>>(partsJson);
        var carParts = JsonConvert.DeserializeObject<List<CarDtoTest>>(carsJson);

        var cars = new List<Car>();
        var partCars = new List<PartCar>();

        foreach (var carPart in carParts)
        {

            var car = new Car
            {
                Make = carPart.Make,
                Model = carPart.Model,
                TraveledDistance = carPart.TraveledDistance
            };

            cars.Add(car);

            foreach (var partId in carPart.PartsId.Distinct())
            {
                partCars.Add(new PartCar
                {
                    Car = car,
                    PartId = partId
                });
            }
        }

        context.Suppliers.AddRange(suppliers);
        context.Parts.AddRange(parts);
        context.Cars.AddRange(cars);
        context.PartsCars.AddRange(partCars);
        context.SaveChanges();
    }

    private static Type GetType(string modelName)
    {
        var modelType = CurrentAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == modelName);

        Assert.IsNotNull(modelType, $"{modelName} model not found!");

        return modelType;
    }

    private static IServiceProvider ConfigureServices<TContext>(string databaseName)
        where TContext : DbContext
    {
        var services = ConfigureDbContext<TContext>(databaseName);

        var context = services.GetService<TContext>();

        try
        {
            context.Model.GetEntityTypes();
        }
        catch (InvalidOperationException ex) when (ex.Source == "Microsoft.EntityFrameworkCore.Proxies")
        {
            services = ConfigureDbContext<TContext>(databaseName, useLazyLoading: true);
        }

        return services;
    }

    private static IServiceProvider ConfigureDbContext<TContext>(string databaseName, bool useLazyLoading = false)
        where TContext : DbContext
    {
        var services = new ServiceCollection()
          .AddDbContext<TContext>(t => t
          .UseInMemoryDatabase(Guid.NewGuid().ToString())
          );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }

    public class CarDtoTest
    {
        public CarDtoTest()
        {
            this.PartsId = new List<int>();
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TraveledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}