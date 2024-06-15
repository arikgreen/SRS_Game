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
        public int DocId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public string Version { get; set; }
        
        [Required]
        public string Chapter { get; set; }
        
        [Required]
        public int Page {  get; set; }

        [Required]
        [ForeignKey("User")]
        [DisplayName("Author")]
        public int AuthorId { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        public DocumentHistory() { }

        public DocumentHistory(int docId, string description, string version, string chapter, int page, int authorId, DateTime created)
        {
            DocId = docId;
            Description = description;
            Version = version;
            Chapter = chapter;
            Page = page;
            AuthorId = authorId;
            Created = created;
        }
    }
}
