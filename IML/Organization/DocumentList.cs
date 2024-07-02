using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Organization
{
  /// <summary>
  /// Lista dokumentów
  /// </summary>
  public partial class DocumentList: ItemList<DocumentInfo>
  {
    /// <summary>
    /// Konstruktor właściwy
    /// </summary>
    /// <param name="owner"></param>
    public DocumentList(Object owner) : base(owner) { }
  }
}
