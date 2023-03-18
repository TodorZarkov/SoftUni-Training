namespace ProductShop;

using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dto.Import;
using ProductShop.Models;
using System.Text.Json;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();



        //string userString = File.ReadAllText(@"..\..\..\..\Datasets\users.json");
        //Console.WriteLine(ImportUsers(context, userString));

        //string productString = File.ReadAllText(@"..\..\..\..\Datasets\products.json");
        //Console.WriteLine(ImportProducts(context, productString));

        //string categoryString = File.ReadAllText(@"..\..\..\..\Datasets\categories.json");
        //Console.WriteLine(ImportCategories(context, categoryString));

        string categoryProductString = File.ReadAllText(@"..\..\..\..\Datasets\categories-products.json");
        Console.WriteLine(ImportCategoryProducts(context,categoryProductString));
    }

    //Mapper
    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<ProductShopProfile>()));
    }


    //p.01. Import Users 
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        List<UserDtoImport> usersDto = JsonConvert.DeserializeObject<List<UserDtoImport>>(inputJson);

        IMapper mapper = CreateMapper();

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

        IMapper mapper = CreateMapper();

        Product[] products = mapper.Map<Product[]>(productsDto);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    //p.03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        CategoryDtoImport[] categoryDtos =
            JsonConvert.DeserializeObject<CategoryDtoImport[]>(inputJson);

        ICollection<CategoryDtoImport> validCategories =
            categoryDtos.Where(c => c.Name != null)
            .ToHashSet<CategoryDtoImport>();

        IMapper mapper = CreateMapper();
        Category[] categories = mapper.Map<Category[]>(validCategories);

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {validCategories.Count}";
    }

    //p.04. Import Categories and Products 
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        CategoryProductDtoImport[] categoryProductDtos =
            JsonConvert.DeserializeObject<CategoryProductDtoImport[]>(inputJson);

        IMapper mapper = CreateMapper();

        CategoryProduct[] categoryProducts =
            mapper.Map<CategoryProduct[]>(categoryProductDtos);

        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }

    //p.05. Export Products In Range 

}