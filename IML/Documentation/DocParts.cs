using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Indeks części dokumentu. Części są indeksowane po nazwie.
  /// </summary>
  public partial class DocParts : ItemIndex<DocPart>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DocParts () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public DocParts(object owner): base(owner) {}

    /// <summary>
    /// Dodawanie elementu do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (DocPart item)
    {
      Add(item.Id, item);
    }
  }
}
