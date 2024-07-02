using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation.Drawings
{
    /// <summary>
    /// Prosta pozycja rysunku
    /// </summary>
    public partial class SimplePosition
    {
        /// <summary>
        /// Współrzędna X
        /// </summary>
        [DefaultValue(null)]
        public int X { get; set; }

        /// <summary>
        /// Współrzędna Y
        /// </summary>
        [DefaultValue(null)]
        public int Y { get; set; }
    }
}
