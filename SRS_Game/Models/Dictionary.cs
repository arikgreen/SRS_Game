using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class Dictionary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        [Required, StringLength(50)]
        public required string Word { get; set; }

        [Required, StringLength(200)]
        public string Definition { get; set; }

        [Required]
        [ForeignKey(nameof(Participant))]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;

        [Required]
        [DisplayName("Updated date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Dictionary() { }

        public Dictionary(int documentId, string word, string definition, int authorId, DateTime createdDate, DateTime updatedDate)
        {
            DocumentId = documentId;
            Word = word;
            Definition = definition;
            AuthorId = authorId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }

    public class DictionaryViewModel : Dictionary
    { 
        public required string Author { get; set; }
    }
}
