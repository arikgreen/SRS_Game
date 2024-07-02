using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Iml.Foundation;
using System.Windows.Markup;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Iml.Documentation
{

  /// <summary>
  /// Styl dla tabeli
  /// </summary>
  //[ContentProperty("Items")]
  public partial class TableStyle : ParagraphStyle
  {
    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    public override StyleType Type
    {
      get { return StyleType.Table; }
    }

    /// <summary>
    /// Format całej tablicy
    /// </summary>
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TableFormat TableFormat
    {
      get { return GetComponent<TableFormat>(); }
      set { SetComponent<TableFormat>(value); }
    }

  }
}
