using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using SRS_Game.Data;
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

        public string AddressOrContact { get; set; } = string.Empty;

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

        public static SelectList GetStakeholderTypes()
        {
            var stakeholderTypes = (from StakeholderType t in Enum.GetValues(typeof(StakeholderType))
                                   select new SelectListItem 
                                   { 
                                       Value = ((int)t).ToString(), 
                                       Text = t.ToString() 
                                   }).ToList();

            stakeholderTypes.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(stakeholderTypes, "Value", "Text");
        }
    }


}
