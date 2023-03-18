namespace ProductShop.Dto.Import;

using System.Text.Json.Serialization;

//using Newtonsoft.Json;


public class CategoryDtoImport
{

    //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
}
