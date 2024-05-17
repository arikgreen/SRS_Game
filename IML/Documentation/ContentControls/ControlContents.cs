using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Zawartość kontrolki treści
  /// </summary>
  public partial class ContentList : ItemList<DocumentContent>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ContentList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ContentList (Item owner) : base(owner) { }

    //public DocumentContent ContentOwner { get { return base.Owner as DocumentContent; } }

  }
}
