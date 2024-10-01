using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    public enum StakeholderType
    {
        Corporation,
        Private
    }

    /// <summary>
    /// Participant of project (STKH)
    /// </summary>
    public class Stakeholder
    {
        [Key]
        public required string Reference { get; set; }

        public required string Name { get; set; }

        /// <summary>
        /// for corporation
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? AddressOrContact { get; set; }

        public required StakeholderType Type { get; set; }

        /// <summary>
        /// tytuł, imię i nazwisko, kontakt
        /// albo referencja do osobnego rekordu, np.:
        /// STKH_002 Przedstawiciel zleceniodawcy
        /// </summary>
        public string Representative { get; set; } = string.Empty;

        /// <summary>
        /// STKH_001 Zleceniodawca
        /// </summary>
        public string Represent { get; set; } = string.Empty;

        public required Priority Priority { get; set; }
    }

    /// <summary>
    /// Personless source (RSRC)
    /// </summary>
    public class Personless
    {
        [Key]
        public required string Reference { get; set; }
        
        public required string Name { get; set; }
        
        public string? Description { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string? Publisher { get; set; }
        
        [DisplayName("Publishing place")]
        public string? PublishingPlace {  get; set; }
        
        [DisplayName("Publishing date")]
        public DateTime PublishingDate { get; set; }
        
        public string Version { get; set; } = string.Empty;
        
        public string? Url { get; set; }
        
        public required Priority Priority { get; set; }
    }
}
