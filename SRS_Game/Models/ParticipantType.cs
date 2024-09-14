using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class ParticipantType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }

        public ParticipantType() { }

        public ParticipantType(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
