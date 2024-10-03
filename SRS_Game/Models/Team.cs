using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(50)]
        public string Number { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Updated date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Team() { }

        public Team(string name, string number, DateTime createdDate, DateTime updatedDate)
        {
            Name = name;
            Number = number;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }

    public class TeamParticipantsViewModel : Team
    {
        [DisplayName("Team members")]
        public IEnumerable<Participant> Members { get; set; } = [];
    }
}
