using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    public class Requirement : BaseModel
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public string[] Relations { get; set; } = [];
    }

    /// <summary>
    /// Functionality requirements (FNRQ)
    /// </summary>
    public class FuncionalityRequirement : Requirement
    {
        [ForeignKey("SystemUser")]
        [DisplayName("Refers to")]
        public required string RefersTo { get; set; }

        [ForeignKey(nameof(BusinesPurpose.Reference))]
        [DisplayName("Busines Purpose")]
        public required string SupportFor { get; set; }
    }

    /// <summary>
    /// Data requirements (DTRQ)
    /// </summary>
    public class DataRequirement : Requirement { }

    /// <summary>
    /// Credibility requirement (RLRQ)
    /// </summary>
    public class CredibilityRequirement : Requirement { }

    /// <summary>
    ///  Performance requirement (PFRQ)
    /// </summary>
    public class PerformanceRequirement : Requirement { }

    /// <summary>
    ///  Flexibility requirement (FLRQ)
    /// </summary>
    public class FlexibilityRequirement : Requirement { }

    /// <summary>
    ///  Usability requirement (STRQ)
    /// </summary>
    public class UsabilityRequirement : Requirement { }

    /// <summary>
    /// Hardware requirement (XHRQ)
    /// </summary>
    public class HardwareRequirement : BaseModel
    {
        [ForeignKey(nameof(HardwareComponent.Reference))]
        public required string RefersTo { get; set; }
    }

    /// <summary>
    /// Hardware requirement (XSRQ)
    /// </summary>
    public class SoftwareRequirement : BaseModel
    {
        [ForeignKey(nameof(SubSystem.Reference))]
        public required string RefersTo { get; set; }
    }

    /// <summary>
    /// Other requirement (XXRQ)
    /// </summary>
    public class OtherRequirement : BaseModel
    {
        public string RefersTo { get; set; } = string.Empty;
    }
}
