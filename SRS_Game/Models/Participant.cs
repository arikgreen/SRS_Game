using Elfie.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name of the participant or company representative
        /// </summary>
        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the participant or company representative
        /// </summary>
        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        [StringLength(100)]
        public string? Name { get; set; }
        
        [EmailAddress]
        [StringLength(50)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailRequired ")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        [StringLength(15)]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }
        
        [Required]
        [ForeignKey("Type")]
        [DisplayName("Type")]
        public int TypeId { get; set; }

        public bool IsExternal { get; set; }

        // Parameterless constructor required by EF Core
        public Participant() { }

        public Participant(string fname, string lname, string email, int type, string? name, string? phoneNumber, string? address, bool isExternal = false)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            TypeId = type;
            IsExternal = isExternal;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }

    public class ParticipantViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; }
    }
}
