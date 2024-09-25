using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// User (USER)
    /// </summary>
    public class SystemUser : BaseModel
    {
        public string[] Needs { get; set; } = [];
        
        public string[] Task { get; set; } = [];
    }
}
