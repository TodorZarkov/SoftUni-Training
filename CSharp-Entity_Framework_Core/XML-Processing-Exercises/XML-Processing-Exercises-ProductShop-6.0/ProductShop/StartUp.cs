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

            string usersDataset = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            Console.WriteLine(ImportUsers(context, usersDataset));

        }

        //p.01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(UserDtoImport[]), rootAttribute);

            using StringReader reader = new StringReader(inputXml);

            var deserializedUsers =
                (UserDtoImport[])serializer.Deserialize(reader);

            IMapper mapper = Utils.CreateMapper();

            var users = mapper.Map<User[]>(deserializedUsers);


            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}