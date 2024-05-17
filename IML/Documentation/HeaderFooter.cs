using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjna klasa nagłówka/stopki
  /// </summary>
  [KnownType(typeof(Header))]
  [KnownType(typeof(Footer))]
  [ContentProperty("Content")]
  public abstract partial class HeaderFooter: Item
  {
    /// <summary>
    /// Tekst dokumentu
    /// </summary>
    [DataMember]
    [Association("PartBody", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content
    {
      get
      {
        if (fContent == null)
          fContent = new ContentList();
        return fContent;
      }
    }
    /// <summary>
    /// Pole przechowujące ciało części
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Czy ciało ma być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBody ()
    {
      return fContent != null && !fContent.IsEmpty();
    }
  }
}
