using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class TeamParticipants
    {
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }

        public TeamParticipants() { }

        public TeamParticipants(int teamId, int participantId)
        {
            TeamId = teamId;
            ParticipantId = participantId;
        }
    }

    public class TeamParticipantsViewModel
    {
        [Required]
        public required Team Team { get; set; }
        public IEnumerable<Participant> Members { get; set; } = [];
    }
}
