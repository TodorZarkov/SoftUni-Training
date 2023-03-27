namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string usersDataset = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            //Console.WriteLine(ImportUsers(context, usersDataset));
            
            string productsDataset = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            Console.WriteLine(ImportProducts(context, productsDataset));

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

    }
}