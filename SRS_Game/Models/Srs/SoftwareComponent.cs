using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    ///  Software component (SCMP)
    /// </summary>
    public class SoftwareComponent : Component
    {
        [ForeignKey(nameof(Component.Reference))]
        public required string Location { get; set; }
    }
}