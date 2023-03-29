namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.Xml.Linq;
    using System.Xml.Serialization;

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

    }
}