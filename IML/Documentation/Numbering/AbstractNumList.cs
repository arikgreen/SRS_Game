using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Lista numerowań abstrakcyjnych
    /// </summary>
    public class AbstractNumList : ItemIndex<AbstractNum>
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public AbstractNumList () { }

        /// <summary>
        /// Konstruktor z właścicielem
        /// </summary>
        /// <param name="owner"></param>
        public AbstractNumList (object owner) : base(owner) { }

        /// <summary>
        /// Dodawanie stylu do indeksu
        /// </summary>
        /// <param name="item"></param>
        public override void Add (AbstractNum item)
        {
            Add(item.Id.ToString(), item);
        }
    }
}
