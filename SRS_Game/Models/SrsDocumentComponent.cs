using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class SrsDocumentComponent
    {
        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        [Required, StringLength(10)]
        public required string RefId { get; set; }
        
        [Required, StringLength(50)]
        public required string FieldName { get; set; }
        
        [StringLength(500)]
        public string? FieldValue { get; set; }
        
        [Required]
        [ForeignKey(nameof(Participant))]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;

        [Required]
        [DisplayName("Updated date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public SrsDocumentComponent() { }

        public SrsDocumentComponent(int documentId, string refId, string fieldName, string? fieldValue, int authorId, DateTime createdDate, DateTime updatedDate)
        {
            DocumentId = documentId;
            RefId = refId;
            FieldName = fieldName;
            FieldValue = fieldValue;
            AuthorId = authorId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }
}
