using Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SRS_Game.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SRS_Game.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name of the participant or company representative
        /// </summary>
        [Required(ErrorMessage = "The field is required")]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the participant or company representative
        /// </summary>
        [Required(ErrorMessage = "The field is required")]
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
        //[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailRequired")]
        //[RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        [StringLength(15)]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("External stakholder")]
        public bool IsExternal { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Created date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Updated date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Parameterless constructor required by EF Core
        public Participant() { }

        public Participant(string fname, string lname, string email, string? name, string? phoneNumber, string? address, bool isExternal, DateTime createdDate, DateTime updatedDate)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            IsExternal = isExternal;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }

        public string GetAddress()
        {
            return MyRegex.NewLineToBr(Address) ?? "";
        }

        public string GetParticipantName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
