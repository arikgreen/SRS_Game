using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    ///  Subsystem (SSYS)
    /// </summary>
    public class SubSystem : Component
    {
        [ForeignKey(nameof(Component.Reference))]
        public required string Location { get; set; }

        [ForeignKey(nameof(SoftwareComponent.Reference))]
        public required string Components { get; set; }
    }
}