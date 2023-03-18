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

        string userString = File.ReadAllText(@"..\..\..\..\Datasets\users.json");

        Console.WriteLine(ImportUsers(context, userString));
    }

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
}