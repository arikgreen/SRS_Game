using System.ComponentModel.DataAnnotations;

namespace SRS_Game.Models
{
    public class AttachementViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public int DocumentId { get; set; }

        public IFormFile? File { get; set; }
    }
}
