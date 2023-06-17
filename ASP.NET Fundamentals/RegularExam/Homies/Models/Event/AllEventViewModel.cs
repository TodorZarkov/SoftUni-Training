namespace Homies.Models.Event
{
    using Homies.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class AllEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public string Start { get; set; } = null!;


        public string Type { get; set; } = null!;


        public string Organiser { get; set; } = null!;

    }
}
