namespace P01_StudentSystem.Data.Models;

using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    
    public string? Url { get; set; }


    
    public ResourceType ResourceType { get; set; }


    public int CourseId { get; set; }
    public Course Course { get; set; }


}
