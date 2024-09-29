using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// Busines purpose (BSGL)
    /// </summary>
    public class BusinesPurpose : BaseModel { }

    /// <summary>
    /// Functionality purpose (FNGL)
    /// </summary>
    public class FunctionalityPurpose : BaseModel
    {
        [ForeignKey(nameof(Stakeholder.Reference))]
        public required string BusinesPurpose { get; set; }
    }
}
