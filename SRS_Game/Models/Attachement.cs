using System.ComponentModel;
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
        [DisplayName("Document")]
        public int DocumentId { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("File name")]
        public string FileName { get; set; }
        
        [DisplayName("Content type")]
        public string ContentType { get; set; }

        [DisplayName("File content")]
        public byte[] FileContent { get; set; }

        [Required]
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        [Required]
        [DisplayName("Update date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public Attachement() { }

        public Attachement(int documentId, string fileName, DateTime createDate, DateTime updateDate, byte[] fileContent, string contentType)
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
