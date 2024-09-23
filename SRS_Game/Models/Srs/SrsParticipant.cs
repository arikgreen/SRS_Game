using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    public enum Priority
    {
        optional,
        low,
        medium,
        high,
        critical
    }

    /// <summary>
    /// Participant of project (STKH)
    /// </summary>
    public class Participant
    {
        [Key]
        public required string Reference { get; set; }
        
        public required string Name { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public string Type { get; set; } = string.Empty;
        
        [DisplayName("Full name")]
        public string FullName { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string Representing {  get; set; } = string.Empty;
        
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
        
        public string Description { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public string Publisher { get; set; } = string.Empty;
        
        [DisplayName("Publishing place")]
        public string PublishingPlace {  get; set; } = string.Empty;
        
        [DisplayName("Publishing date")]
        public DateTime PublishingDate { get; set; }
        
        public string Version { get; set; } = string.Empty;
        
        public string Url { get; set; } = string.Empty;
        
        public required Priority Priority { get; set; }
    }

    public class BaseModel
    {
        [Key]
        public required string Reference { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        [ForeignKey(nameof(Participant.Reference))]
        public required string Source {  get; set; }
        
        public required Priority Priority { get; set; }
    }

    /// <summary>
    /// Busines purpose (BSGL)
    /// </summary>
    public class BusinesPurpose : BaseModel {}

    /// <summary>
    /// Functionality purpose (FNGL)
    /// </summary>
    public class FunctionalityPurpose : BaseModel
    {
        [ForeignKey(nameof(Participant.Reference))]
        public required string BusinesPurpose { get; set; }
    }

    /// <summary>
    /// User (USER)
    /// </summary>
    public class SystemUser : BaseModel
    {
        public string[] Needs { get; set; } = [];
        
        public string[] Task { get; set; } = [];
    }

    /// <summary>
    /// Outside system (XSYS)
    /// </summary>
    public class OutsideSystem : SystemUser
    {
        public string[] Interfaces { get; set; } = [];
    }

    /// <summary>
    /// Hardware component (HCMP)
    /// </summary>
    public class Component : BaseModel
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public string[] Relations { get; set; } = [];
    }

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

    /// <summary>
    ///  Software component (SCMP)
    /// </summary>
    public class SoftwareComponent : Component
    {
        [ForeignKey(nameof(Component.Reference))]
        public required string Location { get; set; }
    }

    public class Requirement : Component {}

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
    public class DataRequirement : Requirement {}

    /// <summary>
    /// Credibility requirement (RLRQ)
    /// </summary>
    public class CredibilityRequirement : Requirement {}

    /// <summary>
    ///  Performance requirement (PFRQ)
    /// </summary>
    public class PerformanceRequirement : Requirement { }

    /// <summary>
    ///  Flexibility requirement (FLRQ)
    /// </summary>
    public class FlexibilityRequirement : Requirement {}

    /// <summary>
    ///  Usability requirement (STRQ)
    /// </summary>
    public class UsabilityRequirement : Requirement { }

    /// <summary>
    ///  Exception (EXCP)
    /// </summary>
    public class Exception : Requirement
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public required string SupportedFor { get; set; }
    }

    /// <summary>
    ///  Critical situation (CRIS)
    /// </summary>
    public class CriticalSituation : Exception {}

    /// <summary>
    /// Emergancy situation (EMRG)
    /// </summary>
    public class EmergancySituation : Exception {}

    /// <summary>
    /// Hardware requirement (XHRQ)
    /// </summary>
    public class HardwareRequirement : BaseModel
    {
        [ForeignKey(nameof(Component.Reference))]
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

    /// <summary>
    /// Acceptance criteria (ACPT)
    /// </summary>
    public class AcceptanceCriteria : OtherRequirement {}
}
