using SRS_Game.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Nazwa dokumentu
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Przeznaczenie
        /// </summary>
        public string? Description { get; set; }

        [Required]
        [ForeignKey("User")]
        [DisplayName("Author")]
        public int AuthorId { get; set; }
        
        /// <summary>
        /// Nr zespołu
        /// </summary>
        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        [ForeignKey("User")]
        public int? TeamLeaderId { get; set; }

        [ForeignKey("Project")]
        [DisplayName("Project")]
        public int? ProjectId { get; set; }

        [Required]
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; }
        
        [Required]
        [DisplayName("Update date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Wersja dokumentu
        /// </summary>
        [Required]
        [DisplayName("Version")]
        public int VersionId { get; set; }

        [DisplayName("File name")]
        public string? FileName { get; set; }
        
        public Document() { }

        public Document(string name, string? description, int authorId, int? team, int? teamLeaderId, 
            int? projectId, DateTime createDate, DateTime updateDate, int versionId, string? fileName)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
            TeamId = team;
            TeamLeaderId = teamLeaderId;
            ProjectId = projectId;
            CreateDate = createDate;
            UpdateDate = updateDate;
            VersionId = versionId;
            FileName = fileName;
        }
    }
}
