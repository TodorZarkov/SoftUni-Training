    namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Import;
using System.Xml.Serialization;

public class Utils
{
    public IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<CarDealerProfile>()));
    }

    public T? XmlSerializer<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        using StringReader reader = new StringReader(inputXml);

        return (T?)serializer.Deserialize(reader);
    }
}
