﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }

        public UserType() { }

        public UserType(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
