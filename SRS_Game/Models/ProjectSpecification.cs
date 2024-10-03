using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class ProjectSpecification
    {
        [Key]
        [Required]
        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        [Key]
        [Required]
        public int Version { get; set; }
        
        [Required]
        public string XamlContent { get; set; } = string.Empty;
        
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ProjectSpecification() { }
    }
}
