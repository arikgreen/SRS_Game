using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation.Drawings
{
    /// <summary>
    /// Pozycja rysunku
    /// </summary>
    public partial class Position
    {
        /// <summary>
        /// Wyrównanie pozycji
        /// </summary>
        public string Alignment { get; set; }

        /// <summary>
        /// Przesunięcie
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Element, względem którego wyznaczana jest pozycja
        /// </summary>
        public string RelativeFrom {get; set;}
    }
}
