using Microsoft.Build.Framework;

namespace SRS_Game.Models
{
    public class TeamParticipants
    {
        public int TeamId { get; set; }
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
        public Team Team { get; set; }
        public IEnumerable<Participant> Members { get; set; }
    }
}
