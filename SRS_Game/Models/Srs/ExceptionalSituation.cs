using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// Acceptance criteria (ACPT)
    /// </summary>
    public class AcceptanceCriteria : BaseModel
    {
        public string? RefersTo { get; set; }
    }

    /// <summary>
    ///  Exception (EXCP)
    /// </summary>
    public class ExceptionScenario : BaseModel
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public string?[] Relations { get; set; } = [];

        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public required string SupportedFor { get; set; }
    }

    /// <summary>
    ///  Critical situation (CRIS)
    /// </summary>
    public class CriticalSituation : ExceptionScenario { }

    /// <summary>
    /// Emergancy situation (EMRG)
    /// </summary>
    public class EmergancySituation : ExceptionScenario { }
}