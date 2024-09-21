using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public Team() { }

        public Team(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }

    public class TeamParticipantsViewModel : Team
    {
        [DisplayName("Team members")]
        public IEnumerable<Participant> Members { get; set; } = [];
    }
}
