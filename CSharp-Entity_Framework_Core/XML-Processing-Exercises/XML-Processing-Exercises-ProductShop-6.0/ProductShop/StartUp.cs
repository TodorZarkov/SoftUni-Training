namespace ProductShop
{
    using System.Xml.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string usersDataset = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            //Console.WriteLine(ImportUsers(context, usersDataset));

            //string productsDataset = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            //Console.WriteLine(ImportProducts(context, productsDataset));

            //string categoriesDataset = File.ReadAllText(@"..\..\..\Datasets\categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesDataset));

            //string categoryProductsDataset = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductsDataset));

            //Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(GetSoldProducts(context));

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //Console.WriteLine(GetUsersWithProducts(context));

        }

        //p.01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(UserDtoImport[]), rootAttribute);
            using StringReader reader = new StringReader(inputXml);
            var deserializedUsers =
                (UserDtoImport[])serializer.Deserialize(reader);

            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var users = mapper.Map<User[]>(deserializedUsers);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //p.02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            Utils utils = new Utils();
            var deserializedProducts = utils.Deserialize<ProductDtoImport>(inputXml, "Products");

            IMapper mapper = utils.CreateMapper();
            var products = mapper.Map<Product[]>(deserializedProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //p.03. Import Categories 
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            Utils utils = new Utils();
            var deserializedCategories =
                utils.Deserialize<CategoryDtoImport>(inputXml, "Categories");

            IMapper mapper = utils.CreateMapper();
            var categories = mapper.Map<Category[]>(deserializedCategories);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //p. 04. Import Categories and Products 
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            Utils utils = new Utils();
            var deserializedCategoryProducts =
                utils.Deserialize<CategoryProductDtoImport>(inputXml, "CategoryProducts");

            var validCategoryIds = context.Categories.Select(c => c.Id).ToHashSet();
            var validProductIds = context.Products.Select(p => p.Id).ToHashSet();
            var validCategoryProducts =
                deserializedCategoryProducts.Where(cp => validCategoryIds.Contains(cp.CategoryId) &&
                                                         validProductIds.Contains(cp.ProductId)).ToArray();

            IMapper mapper = utils.CreateMapper();
            var categoryProducts = mapper.Map<CategoryProduct[]>(validCategoryProducts);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Length}";
        }

        //p.05. Export Products In Range 
        public static string GetProductsInRange(ProductShopContext context)
        {
            Utils utils = new Utils();

            IMapper mapper = utils.CreateMapper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductDtoExport>(mapper.ConfigurationProvider)
                .ToArray();


            return utils.Serializer<ProductDtoExport[]>(products, "Products");
        }

        //p.06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserDtoExport
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold.Select(ps => new ProductWithNamePriceDtoExport
                    {
                        Name = ps.Name,
                        Price = ps.Price//.ToString("G29")
                    }).ToArray()
                })
                .ToArray();



            return utils.Serializer<UserDtoExport[]>(users, "Users");
        }

        //p. 07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoriesDtoExport
                {
                    Name = c.Name,
                    NumberOfProducts = c.CategoryProducts.Count,
                    AvaragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.NumberOfProducts)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            Utils utils = new Utils();

            return utils.Serializer(categories, "Categories");
        }

        //p 08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersIn = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
                .Select(u => new UserNamesAgeDtoExport
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDtoExport
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(ps => new ProductWithNamePriceDtoExport
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count);
                //.Take(10)
                //.ToArray();

            var usersOut = new UserOutDtoExport
            {
                Count = usersIn.Count(),
                InUsers = usersIn.Take(10).ToArray()
            };

            Utils utils = new Utils();

            return utils.Serializer(usersOut, "Users");
        }
    }
}