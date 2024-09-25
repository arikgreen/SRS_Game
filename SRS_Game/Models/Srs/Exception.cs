using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
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
    public class CriticalSituation : Exception { }

    /// <summary>
    /// Emergancy situation (EMRG)
    /// </summary>
    public class EmergancySituation : Exception { }
}