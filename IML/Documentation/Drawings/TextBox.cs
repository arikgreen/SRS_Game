using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using IML = Iml.Documentation;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Pudełko na tekst (na rysunku)
  /// </summary>
  [ContentProperty("Content")]
  public partial class TextBox: DrawingItem
  {
    /// <summary>
    /// Zawartość pudełka
    /// </summary>
    [DataMember]
    [Association("Content", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public IML.ContentList Content 
    { 
      get
      {
        if (fContent == null)
          fContent = new IML.ContentList(this);
        return fContent;
      } 
      //set
      //{
      //  fContent = value; if (value != null) value.SetOwner(this);
      //}
    }
    /// <summary>
    /// Pole przechowujące zawartość
    /// </summary>
    protected IML.ContentList fContent;

    /// <summary>
    /// Czy zawartość ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent()
    {
      return fContent != null && !fContent.IsEmpty();
    }

    /// <summary>
    /// Czcionka
    /// </summary>
    [DefaultValue(null)]
    public Font Font { get; set; }

    /// <summary>
    /// Kolor czcionki
    /// </summary>
    [DefaultValue(null)]
    public Color FontColor { get; set; }

  }
}
