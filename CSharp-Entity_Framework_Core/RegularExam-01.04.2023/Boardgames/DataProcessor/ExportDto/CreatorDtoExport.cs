namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class CreatorDtoExport
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    public string CreatorName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public BoardgameDtoExport[] Boardgames { get; set; } = null!;
}
