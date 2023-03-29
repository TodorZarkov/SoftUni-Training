namespace CarDealer;

using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Text;
using System.Xml.Serialization;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        string suppliersXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
        Console.WriteLine(ImportSuppliers(context, suppliersXml));

    }

    //p 09. Import Suppliers 
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        XmlRootAttribute root = new XmlRootAttribute("Suppliers");

        XmlSerializer serializer = new XmlSerializer(typeof(SupplierDtoImport[]), root);
        using StringReader reader = new StringReader(inputXml);
        var serializedSuppliers = (SupplierDtoImport[])serializer.Deserialize(reader);

        var validSuppliers = serializedSuppliers.Where(s => s.Name != null &&
                                                            s.IsImporter != null);

        Utils utils = new Utils();
        IMapper mapper = utils.CreateMapper();

        var suppliers = mapper.Map<Supplier[]>(validSuppliers);
        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    //p.10. Import Parts 

}