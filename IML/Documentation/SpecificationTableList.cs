using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Lista przechowująca tabele specyfikacji
    /// </summary>
    public class SpecificationTableList : ItemIndex<SpecificationTable>
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public SpecificationTableList() { }

        /// <summary>
        /// Konstruktor z właścicielem
        /// </summary>
        /// <param name="owner"></param>
        public SpecificationTableList(object owner) : base(owner) { }

        /// <summary>
        /// Dodawanie tabeli specyfikacji do indeksu
        /// </summary>
        /// <param name="item"></param>
        public override void Add(SpecificationTable item)
        {
            Add(item.Id, item);
        }
    }
}
