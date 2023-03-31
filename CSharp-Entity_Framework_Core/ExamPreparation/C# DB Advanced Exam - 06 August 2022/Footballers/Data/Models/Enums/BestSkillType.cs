namespace Footballers.Data.Models.Enums;

using System.Xml.Serialization;

public enum BestSkillType
{
    [XmlEnum("0")]
    Defence = 0,

    [XmlEnum("1")]
    Dribble = 1,

    [XmlEnum("2")]
    Pass    = 2,

    [XmlEnum("3")]
    Shoot   = 3,

    [XmlEnum("4")]
    Speed   = 4
}

