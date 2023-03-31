namespace Footballers.DataProcessor.ImportDto;

using System.Xml.Serialization;


[XmlType("Footballer")]
public class FootballerDtoImport
{
    public string? Name { get; set; }

    public string? ContractStartDate { get; set; }

    public string? ContractEndDate { get; set; } 

    public string? BestSkillType { get; set; } 

    public string? PositionType { get; set; } 
}
