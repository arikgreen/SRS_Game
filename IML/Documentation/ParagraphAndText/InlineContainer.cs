using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows;
using System.ComponentModel;
using WinDocs = System.Windows.Documents;

namespace Iml.Documentation
{
  /// <summary>
  /// Element zawierający obiekt w tekście
  /// </summary>
  [ContentProperty("Content")]
  public partial class InlineContainer : Inline
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public InlineContainer() { }
    /// <summary>
    /// Konstruktor tworzący element na podstawie podanego obiektu
    /// </summary>
    public InlineContainer(object content) { Content = content; }
    /// <summary>
    /// Tekst przechowywany przez ten element
    /// </summary>
    public object Content { get; set; }
    /// <summary>
    /// Czy obiekt ma być zapamiętywany?
    /// Pusty obiekt nie jest zapamiętywany
    /// </summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeContent(XamlDesignerSerializationManager manager)
    {
      return Content != null;
    }
  }
}
