using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class Attachement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Document")]
        public int DocumentId { get; set; }
        
        [Required]
        public string FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? FileContent { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        [Required]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public Attachement() { }

        public Attachement(int documentId, string fileName, DateTime createDate, DateTime updateDate, byte[]? fileContent, string? contentType)
        {
            DocumentId = documentId;
            FileName = fileName;
            CreateDate = createDate;
            UpdateDate = updateDate;
            ContentType = contentType;
            FileContent = fileContent;
        }
    }
}
