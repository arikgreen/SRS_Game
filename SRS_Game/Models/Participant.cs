using Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        //[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailRequired")]
        //[RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        [StringLength(15)]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [Required]
        [DisplayName("External participant")]
        public bool IsExternal { get; set; }

        // Parameterless constructor required by EF Core
        public Participant() { }

        public Participant(string fname, string lname, string email, string? name, string? phoneNumber, string? address, bool isExternal = false)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            IsExternal = isExternal;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string GetAddress()
        {
            return Address != null ? Regex.Replace(Address, "<br />", @"((\r)?\n|\u0010)") : "";
        }

        public string GetName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
