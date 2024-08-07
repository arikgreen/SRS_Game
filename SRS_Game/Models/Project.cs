﻿using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int ProjectManagerId { get; set; }

        public Project() { }

        public Project(string name, string number, DateTime createDate, DateTime updateDate, int projectManagerId)
        {
            Name = name;
            Number = number;
            CreatedDate = createDate;
            UpdateDate = updateDate;
            ProjectManagerId = projectManagerId;
        }
    }
}
