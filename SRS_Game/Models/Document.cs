using SRS_Game.Data;
using SRS_Game.Models.Srs;
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
        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        /// <summary>
        /// Przeznaczenie
        /// </summary>
        public string? Destination { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Author")]
        [ForeignKey(nameof(Participant))]
        public int AuthorId { get; set; }

        /// <summary>
        /// Nr zespołu
        /// </summary>
        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        [DisplayName("Team Leader")]
        [Required(ErrorMessage = "The field is required")]
        [ForeignKey(nameof(Participant))]
        public int TeamLeaderId { get; set; }

        [DisplayName("Project")]
        [ForeignKey(nameof(Project))]
        public int? ProjectId { get; set; }

        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Updated date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Wersja dokumentu
        /// </summary>
        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Version")]
        public int Version { get; set; }

        /// <summary>
        /// Percent 0% - 100%
        /// </summary>
        public int? Rate {  get; set; }

        public Document() { }

        public Document(string name, string? destinatiption, int authorId, int? team, int teamLeaderId, int? projectId, 
            DateTime createDate, DateTime updateDate, int versionId, int? rate = 0)
        {
            Name = name;
            Destination = destinatiption;
            AuthorId = authorId;
            TeamId = team;
            TeamLeaderId = teamLeaderId;
            ProjectId = projectId;
            CreatedDate = createDate;
            UpdatedDate = updateDate;
            Version = versionId;
            Rate = rate;
        }
    }

    public class DocumentViewModel : Document
    {
        public string Project { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public string XamlContent { get; set; } = string.Empty;
        public IEnumerable<Attachement> Attachements { get; set; } = Enumerable.Empty<Attachement>();
        public IEnumerable<DocumentHistoryViewModel> History { get; set; } = Enumerable.Empty<DocumentHistoryViewModel>();
    }

    public class DocumentEditViewModel : DocumentViewModel
    {
        public SRS? SRS { get; set; }
    }

    public class DocumentStakeholderRel
    {
        [ForeignKey(nameof(Document))]
        public required int DocumentId { get; set; }

        [ForeignKey(nameof(Participant))]
        public required int StakeholderId { get; set; }
    }
}
