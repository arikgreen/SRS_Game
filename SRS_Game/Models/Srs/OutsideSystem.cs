using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRS_Game.Models.Srs
{
    /// <summary>
    /// Outside system (XSYS)
    /// </summary>
    public class OutsideSystem : SystemUser
    {
        public string[] Interfaces { get; set; } = [];
    }
}