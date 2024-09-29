using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    public class Component : BaseModel
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public string[] Relations { get; set; } = [];
    }

    /// <summary>
    /// Hardware component (HCMP)
    /// </summary>
    public class HardwareComponent : Component { }

    /// <summary>
    /// Software component (SCMP)
    /// </summary>
    public class SoftwareComponent : Component
    {
        [ForeignKey(nameof(HardwareComponent.Reference))]
        public required string Location { get; set; }
    }

    /// <summary>
    /// Subsystem (SSYS)
    /// </summary>
    public class SubSystem : HardwareComponent
    {
        [ForeignKey(nameof(HardwareComponent.Reference))]
        public required string Location { get; set; }

        [ForeignKey(nameof(SoftwareComponent.Reference))]
        public required string Components { get; set; }
    }
}