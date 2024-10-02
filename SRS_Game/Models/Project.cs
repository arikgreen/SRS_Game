using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Updated date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [DisplayName("Project manager")]
        public int ProjectManagerId { get; set; }

        public Project() { }

        public Project(string name, string number, DateTime createDate, DateTime updateDate, int projectManagerId)
        {
            Name = name;
            Number = number;
            CreatedDate = createDate;
            UpdateDate = updateDate;
            ProjectManagerId = projectManagerId;
        }
    }

    public class ProjectsViewModel : Project
    {
        [DisplayName("Project manager")]
        public string ProjectManager { get; set; }

    }

    public class ProjectViewModel
    {
        public int Id { get; set; }
        public required Project Project { get; set; }
        public Participant Manager { get; set; }
    }
}
