using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// Hardware component (HCMP)
    /// </summary>
    public class Component : BaseModel
    {
        [ForeignKey(nameof(FuncionalityRequirement.Reference))]
        public string[] Relations { get; set; } = [];
    }
}