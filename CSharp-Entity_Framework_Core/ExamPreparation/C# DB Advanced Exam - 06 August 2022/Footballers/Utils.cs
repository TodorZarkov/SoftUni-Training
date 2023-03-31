namespace Footballers;

using AutoMapper;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class Utils
{
    public IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<FootballersProfile>()));
    }

    public T? XmlDeserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T), root);
        using StringReader reader = new StringReader(inputXml);
        
        return (T?)serializer.Deserialize(reader);
    }

    public string XmlSerialize<T>(T dto, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        StringBuilder sb = new StringBuilder();
        using StringWriter wirter = new StringWriter(sb);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(wirter, dto, namespaces);

        return sb.ToString().TrimEnd();
    }
}
