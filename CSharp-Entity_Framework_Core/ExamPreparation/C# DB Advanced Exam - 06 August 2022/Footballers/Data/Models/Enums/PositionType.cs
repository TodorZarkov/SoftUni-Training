namespace Footballers.Data.Models.Enums;

using System.Xml.Serialization;

public enum PositionType
{
    [XmlEnum("0")]
    Goalkeeper  = 0,

    [XmlEnum("1")]
    Defender    = 1,

    [XmlEnum("2")]
    Midfielder  = 2,

    [XmlEnum("3")]
    Forward     = 3
}
