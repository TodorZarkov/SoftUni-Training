namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Core.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dto.Export;
using ProductShop.Dto.Import;
using ProductShop.Models;
using System.Diagnostics.Metrics;
using System.Linq;
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

        //string categoryProductString = File.ReadAllText(@"..\..\..\..\Datasets\categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(context,categoryProductString));

        //string productsJsonString = GetProductsInRange(context);
        //File.WriteAllText(@"..\..\..\..\Results\products-in-range.json", productsJsonString);

        //string soldProductsJsonString = GetSoldProducts(context);
        //File.WriteAllText(
        //    @"..\..\..\..\Results\users-sold-products.json", 
        //    soldProductsJsonString);

        //string categoriesJsonString = GetCategoriesByProductsCount(context);
        //File.WriteAllText(
        //    @"..\..\..\..\Results\categories-by-products.json",
        //    categoriesJsonString);
        
        string usersJsonString = GetUsersWithProducts(context);
        File.WriteAllText(
            @"..\..\..\..\Results\users-and-products.json",
            usersJsonString);

    }

    //Mapper
    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<ProductShopProfile>()));
    }

    //JsonSettings
    public static JsonSerializerSettings CreateSettingsIdentedCamel()
    {
        return new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
    }
    public static JsonSerializerSettings CreateSettingsCamelIncludeNullIndented()
    {
        return new JsonSerializerSettings
        {
            
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            }
        };
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
    public static string GetProductsInRange(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();


        ProductDtoExport[] productsDto =
            context.Products
            .Where(p => p.Price >= 500m &&
                        p.Price <= 1000m)
            .OrderBy(p => p.Price)
            .ProjectTo<ProductDtoExport>(mapper.ConfigurationProvider)
            .ToArray();


        var settings = CreateSettingsIdentedCamel();

        return JsonConvert.SerializeObject(productsDto, settings);
    }

    //p.06. Export Sold Products 
    public static string GetSoldProducts(ProductShopContext context)
    {
        var persons = context.Users
            .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                .Where(sp => sp.BuyerId.HasValue)
                .Select(sp => new
                {
                    sp.Name,
                    Price = sp.Price,
                    BuyerFirstName = sp.Buyer.FirstName,
                    BuyerLastName = sp.Buyer.LastName
                }).ToArray()
            }).ToArray();


        var jsonSettings = CreateSettingsCamelIncludeNullIndented();

        return JsonConvert.SerializeObject(persons, jsonSettings);
    }

    //p.07. Export Categories By Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .OrderByDescending(c => c.CategoryProducts.Count)
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoryProducts.Count,
                AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
            })
            .ToArray();

        var jsonSettings = CreateSettingsCamelIncludeNullIndented();

        return JsonConvert.SerializeObject(categories, jsonSettings);
    }

    //p.08. Export Users and Products 
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = new
        {
            UsersCount = context.Users
                .Count(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue)),
            Users = context.Users
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(ps => new
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        }).ToArray()
                    }
                }).ToArray()
        };

        var jsonSettings = CreateSettingsIdentedCamel();

        return JsonConvert.SerializeObject(users, jsonSettings);
    }

    //p.09. Import Suppliers

}