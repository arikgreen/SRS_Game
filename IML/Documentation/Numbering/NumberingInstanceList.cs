using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Lista instancji numerowania
    /// </summary>
    public class NumberingInstanceList : ItemIndex<NumberingInstance>
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public NumberingInstanceList () { }

        /// <summary>
        /// Konstruktor z właścicielem
        /// </summary>
        /// <param name="owner"></param>
        public NumberingInstanceList (object owner) : base(owner) { }

        /// <summary>
        /// Dodawanie stylu do indeksu
        /// </summary>
        /// <param name="item"></param>
        public override void Add (NumberingInstance item)
        {
            Add(item.Id.ToString(), item);
        }
    }
}
