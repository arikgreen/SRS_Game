using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    public enum Priority
    {
        optional,
        low,
        medium,
        high,
        critical
    }

    public class BaseModel
    {
        [Key]
        public required string Reference { get; set; }
        
        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }
        
        [ForeignKey(nameof(Stakeholder.Reference))]
        public required string Source {  get; set; }
        
        public required Priority Priority { get; set; }
    }
}
