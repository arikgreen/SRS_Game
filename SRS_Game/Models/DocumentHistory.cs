using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class DocumentHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        [Required]
        public string Version { get; set; }
        
        [Required]
        public string Chapter { get; set; }
        
        [Required]
        public int Page {  get; set; }

        [Required]
        [ForeignKey("Principal")]
        [DisplayName("Author")]
        public int AuthorId { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        public DocumentHistory() { }

        public DocumentHistory(int docId, string description, string version, string chapter, int page, int authorId, DateTime created)
        {
            DocumentId = docId;
            Description = description;
            Version = version;
            Chapter = chapter;
            Page = page;
            AuthorId = authorId;
            Created = created;
        }
    }
}
