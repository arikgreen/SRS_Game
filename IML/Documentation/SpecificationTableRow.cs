using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Klasa reprezentująca wiersz tabeli specyfikacji
    /// </summary>
    public partial class SpecificationTableRow : TableRow
    {
        /// <summary>
        /// Nazwa wiersza tabeli specyfikacji
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Określa widoczność wiersza tabeli specyfikacji
        /// </summary>
        public bool Visible { get; set; }
    }
}
