using Elfie.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name of the User or company representative
        /// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "Firstname", ResourceType = typeof(Resource))]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the User or company representative
        /// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string SecondName { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        [StringLength(100)]
        public string? Name { get; set; }
        
        [EmailAddress]
        [StringLength(50)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailRequired")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone number", ResourceType = typeof(Resource))]
        public string? PhoneNumber { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }

        [Required]
        public bool IsExternal { get; set; }

        public User() { }

        public User(string fname, string sname, string email, int type, string password, 
            string? name, string? phoneNumber, string? address, bool isExternal = false)
        {
            FirstName = fname;
            SecondName = sname;
            Email = email;
            TypeId = type;
            Password = password;
            IsExternal = isExternal;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
