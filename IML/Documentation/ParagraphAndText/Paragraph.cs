using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml.Linq;
using WinDocs = System.Windows.Documents;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca akapit tekstu. 
  /// </summary>
  [ContentProperty("Content")]
  public partial class Paragraph: Block
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Paragraph() 
    {
      Content = new ContentList(this); 
    }

    /// <summary>
    /// Format akapitu
    /// </summary>
    [DefaultValue(null)]
    public ParagraphFormat ParagraphFormat { get; set; }

    /// <summary>
    /// Atrybuty typograficzne znacznika końca akapitu
    /// </summary>
    [DefaultValue(null)]
    public TextFormat EndCharTextFormat { get; set; }

    /// <summary>
    /// Tabulatory akapitu
    /// </summary>
    [DefaultValue(null)]
    public TabStops TabStops { get; set; }

    /// <summary>
    /// Czy akapit jest pusty?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Identyfikator paragrafu
    /// </summary>
    public string ParaId { get; set; }

    /// <summary>
    /// Identyfikator tekstu
    /// </summary>
    public string TextId { get; set; }

    ///// <summary>
    ///// Styl redefiniowany jako akapitowy
    ///// </summary>
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public new ParagraphStyle Style
    //{
    //  get { return base.Style as ParagraphStyle; }
    //  set { base.Style = value; }
    //}

  }
}
