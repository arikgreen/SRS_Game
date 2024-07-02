using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Część zawierająca dowolne elementy
  /// </summary>
  public partial class CustomXmlPart: Item
  {
    /// <summary>
    /// Identyfikator części
    /// </summary>
    [DefaultValue(null)]
    public override string Id { get; set; }

    /// <summary>
    /// Zawartość XML
    /// </summary>
    [DefaultValue(null)]
    public string Content { get; set; }
  }
}
