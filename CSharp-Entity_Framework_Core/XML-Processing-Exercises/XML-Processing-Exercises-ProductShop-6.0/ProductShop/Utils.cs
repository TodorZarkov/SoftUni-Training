namespace ProductShop;

using AutoMapper;
using ProductShop.DTOs.Import;
using System.Text;
using System.Xml.Serialization;

public class Utils
{
    public IMapper CreateMapper()
    {
        return new Mapper(
            new MapperConfiguration(c => c.AddProfile<ProductShopProfile>()));
    }

    public T[] Deserialize<T>(string inputXml, string rootAttribute)
    {
        var rootAttr = new XmlRootAttribute(rootAttribute);
        var serializer = new XmlSerializer(typeof(T[]), rootAttr);

        using StringReader reader = new StringReader(inputXml);

        return (T[])serializer.Deserialize(reader);
    }

    public string Serializer<T>(T dto, string rootAttribute)
    {
        var rootAttr = new XmlRootAttribute(rootAttribute);
        var serializer = new XmlSerializer(typeof(T), rootAttr);

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        StringBuilder sb = new StringBuilder();

        using StringWriter writer = new StringWriter(sb);
        serializer.Serialize(writer, dto, namespaces);

        return sb.ToString().TrimEnd();
    }

}
