using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Obrazek VML
  /// </summary>
  [ContentProperty("Content")]
  public partial class Picture: DocumentContent
  {
    /// <summary>
    /// Zawartość obrazka
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content
    {
      get
      {
        if (fContent == null)
          fContent = new ContentList(this);
        return fContent;
      }
      //set { fContent = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące zawartość obrazka
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Na razie nie jest pusty.
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Obliczenie skrótu na podstawie numeru dodatkowego
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "PiCtuRe".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
