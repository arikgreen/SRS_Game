using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa przypisu dolnego lub końcowego
  /// </summary>
  [ContentProperty("Content")]
  public abstract partial class Docnote: DocumentContent
  {

    /// <summary>
    /// Typ elementu
    /// </summary>
    public DocnoteType Type { get; set; }

    /// <summary>
    /// Składowe elementy akapitu
    /// </summary>
    [DataMember]
    [Association("Content", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ContentList Content 
    { 
      get
      {
        if (fContent == null)
          fContent = new Body();
        return fContent;
      }
      private set
      {
        fContent = value; if (value != null) value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujące zawartość przypisu
    /// </summary>
    protected ContentList fContent;

    /// <summary>
    /// Liczba składowych
    /// </summary>
    public int Count
    {
      get { return Content.Count; }
    }

    /// <summary>
    /// Na razie element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
