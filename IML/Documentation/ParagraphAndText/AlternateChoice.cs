using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element wyboru zawartości
  /// </summary>
  [ContentProperty("Content")]
  public partial class AlternateChoice: Item
  {
    /// <summary>
    /// Wybierana zawartość
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
      //set
      //{
      //  fContent = value;
      //  if (value != null)
      //    value.SetOwner(this);
      //}
    }
    /// <summary>
    /// Pole przechowujące zawartość
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = "AlteRnateChoice".GetHashCode();
        if (Content != null)
          hash += Content.GetHash();
        if (Collection != null)
          hash = Collection.MakeHashUnique(hash);
        fHashCode = hash;
      }
      return (int)fHashCode;
    }
    /// <summary>
    /// Pole przechowujące kod skrótu
    /// </summary>
    protected int? fHashCode = null;


  }
}
