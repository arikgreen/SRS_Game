using Microsoft.AspNetCore.Mvc.Rendering;
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
        /// First name of the user
        /// </summary>
        [StringLength(50)]
        [DisplayName("First name")]
        [Required(ErrorMessage = "The field is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the user
        /// </summary>
        [StringLength(50)]
        [DisplayName("Last name")]
        [Required(ErrorMessage = "The field is required")]
        public string LastName { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        //[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LoginRequired")]
        [StringLength(20)]
        [Required(ErrorMessage = "The field is required")]
        public string Login { get; set; }
        
        [StringLength(50)]
        [Required(ErrorMessage = "The field is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [StringLength(15)]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        [DisplayName("Role")]
        public ICollection<UserRole> Roles { get; set; } = [];

        [DisplayName("Create date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DisplayName("Update date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public User() { }  // Parameterless constructor required by EF Core

        //public User(string login, string password, string email, int roleId, string fname, string lname, string? phoneNumber, DateTime createdDate, DateTime updatedDate)
        //{
        //    Login = login;
        //    FirstName = fname;
        //    LastName = lname;
        //    Email = email;
        //    Password = password;
        //    PhoneNumber = phoneNumber;
        //    UserRoleFK = roleId;
        //    CreatedDate = createdDate;
        //    UpdatedDate = updatedDate;
        //}
    }

    public class UserIndexViewModel : User
    {
        [DisplayName("Role")]
        public string Roles { get; set; }
    }

    public class UserCreateViewModel : User
    {
        // Multi-select list for roles
        [DisplayName("Role")]
        [Required(ErrorMessage = "At least one role must be selected")]
        public List<int> SelectedRoleIds { get; set; }

        // List of roles to display in the form
        public List<SelectListItem> AvailableRoles { get; set; } = [];

        [PasswordPropertyText]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserEditViewModel : User
    {
        // Multi-select list for roles
        [DisplayName("Role")]
        [Required(ErrorMessage = "The field is required")]
        public List<int> SelectedRoleIds { get; set; }

        // List of roles to display in the form
        public List<SelectListItem> AvailableRoles { get; set; } = [];

        public new string? Login { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string? ConfirmPassword { get; set; }
    }
}
