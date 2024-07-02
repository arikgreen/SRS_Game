using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation
{
    /// <summary>
    /// Lista wierszy tabeli specyfikacji
    /// </summary>
    public partial class SpecificationTableRows : ItemList<TableRow>
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public SpecificationTableRows() { }

        /// <summary>
        /// Konstruktor z właścicielem
        /// </summary>
        /// <param name="owner"></param>
        public SpecificationTableRows(Object owner) : base(owner) { }
    }
}
