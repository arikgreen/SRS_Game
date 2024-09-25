using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// Personless source (RSRC)
    /// </summary>
    public class Personless
    {
        [Key]
        public required string Reference { get; set; }
        
        public required string Name { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public string Publisher { get; set; } = string.Empty;
        
        [DisplayName("Publishing place")]
        public string PublishingPlace {  get; set; } = string.Empty;
        
        [DisplayName("Publishing date")]
        public DateTime PublishingDate { get; set; }
        
        public string Version { get; set; } = string.Empty;
        
        public string Url { get; set; } = string.Empty;
        
        public required Priority Priority { get; set; }
    }
}
