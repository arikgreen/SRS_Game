using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista części XML definiowanych przez użytkownika
  /// </summary>
  public partial class CustomXmlParts: ItemList<CustomXmlPart>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public CustomXmlParts(): base(){}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    public CustomXmlParts (object owner) : base(owner) { }

  }
}
