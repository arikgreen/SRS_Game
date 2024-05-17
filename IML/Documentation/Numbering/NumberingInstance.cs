using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Instancja numerowania
    /// </summary>
    public class NumberingInstance : Item
    {
        /// <summary>
        /// Identyfikator liczbowy
        /// </summary>
        [DefaultValue(null)]
        public new int Id { get; set; }

        /// <summary>
        /// Identyfikator abstrakcyjnego numerowania
        /// </summary>
        [DefaultValue(null)]
        public int? AbstractNumId { get; set; }

    }
}
