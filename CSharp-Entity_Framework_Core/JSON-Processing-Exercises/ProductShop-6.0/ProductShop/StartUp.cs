namespace ProductShop;

using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dto.Import;
using ProductShop.Models;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();



        //string userString = File.ReadAllText(@"..\..\..\..\Datasets\users.json");
        //Console.WriteLine(ImportUsers(context, userString));

        string productString = File.ReadAllText(@"..\..\..\..\Datasets\products.json");
        Console.WriteLine(ImportProducts(context, productString));
    }


    //p.01. Import Users 
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        List<UserDtoImport> usersDto = JsonConvert.DeserializeObject<List<UserDtoImport>>(inputJson);

        MapperConfiguration config =
            new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());

        Mapper mapper = new Mapper(config);

        foreach (var userDto in usersDto)
        {
            context.Users.Add(mapper.Map<User>(userDto));
        }

        int numberOfEntities = context.SaveChanges();

        return $"Successfully imported {numberOfEntities}";
    }

    //p.02. Import Products 
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        ProductDtoImport[] productsDto = 
            JsonConvert.DeserializeObject<ProductDtoImport[]>(inputJson);

        IMapper mapper = new Mapper(new MapperConfiguration(c =>
            c.AddProfile<ProductShopProfile>()));

        Product[] products = mapper.Map<Product[]>(productsDto);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    //p.03. Import Categories

}