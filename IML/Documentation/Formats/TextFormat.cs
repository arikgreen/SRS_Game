using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Iml.Documentation
{

  /// <summary>
  /// Klasa reprezentująca format tekstowy.
  /// </summary>
  //[ContentProperty("Substitutes")]
  public partial class TextFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Text; }
    }
    /// <summary>
    /// Atrybuty typograficzne
    /// </summary>
    public TextAttributes Attributes;

    /// <summary>
    /// Krój czcionki
    /// </summary>
    [DefaultValue(null)]
    public string Typeface { get; set; }

    /// <summary>
    /// Krój czcionki
    /// </summary>
    [DefaultValue(null)]
    public string FontScheme { get; set; }


    /// <summary>
    /// Rozmiar czcionki (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue FontSize { get; set; }

    /// <summary>
    /// Przesunięcie tekstu w pionie (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue VerticalShift { get; set; }

    /// <summary>
    /// Język tekstu
    /// </summary>
    [DefaultValue(null)]
    public string Language { get; set; }

    /// <summary>
    /// Opcje sprawdzania tekstu
    /// </summary>
    [DefaultValue(null)]
    public TextProofing? Proofing { get; set; }

    /// <summary>
    /// Wielkość czcionki, powyżej której ma być podsuwanie znaków
    /// </summary>
    [DefaultValue(null)]
    public PointValue KernFromSize { get; set; }

    /// <summary>
    /// Odstępy międzyznakowe
    /// </summary>
    [DefaultValue(null)]
    public PointValue Spacing { get; set; }

    /// <summary>
    /// Zastosowanie kapitalików
    /// </summary>
    [DefaultValue(null)]
    public CapsMode? Capitalicize { get; set; }

    /// <summary>
    /// Styl podkreślenia
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

    public string UnderlineStyle { get; set; }

    /// <summary>
    /// Podkreślenie do serializacji
    /// </summary>
    [DefaultValue(null)]
    public string Underline
    {
      get
      {
        if (Underlined==true)
        {
          if (UnderlineStyle != null)
          {
            if (UnderlineStyle != "Single")
              return UnderlineStyle;
          }
          return "True";
        }
        if (Underlined==false)
          return "False";
        return null;
      }
      set
      {
        if (value.ToLowerInvariant() == "true")
        {
          Underlined = true;
          UnderlineStyle="Single";
        }
        else if (value.ToLowerInvariant() == "false")
        {
          Underlined = false;
          UnderlineStyle = null;
        }
       
        else if (value != null)
        {
          Underlined = true;
          UnderlineStyle = value;
        }
        else
        {
          Underlined = null;
          UnderlineStyle = null;
        }
      }
    }

    /// <summary>
    /// Kolor czcionki
    /// </summary>
    [DefaultValue(null)]
    public Color FontColor { get; set; }

    /// <summary>
    /// Czy tekst jest ukryty
    /// </summary>
    [DefaultValue(null)]
    public bool? Hidden { get; set; }

    /// <summary>
    /// Czy tekst jest ukryty w sieci 
    /// </summary>
    [DefaultValue(null)]
    public bool? WebHidden { get; set; }

    /// <summary>
    /// Cieniowanie tekstu
    /// </summary>
    [DefaultValue(null)]
    public Shading Shading { get; set; }

    /// <summary>
    /// Formaty zastępcze dla różnych skryptów
    /// </summary>
//    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//    [XmlIgnore]
    [XmlArray]
    [XmlArrayItem(Type = typeof(TextFormatSub))]
    public TextFormatSubstitutes Substitutes
    {
      get
      {
        if (fSubstitutes == null)
          fSubstitutes = new TextFormatSubstitutes(this);
        return fSubstitutes;
      }
      set
      {
        fSubstitutes = value; if (value != null) value.SetOwner(this);
      }
    }
    private TextFormatSubstitutes fSubstitutes;

    ///// <summary>
    ///// Postać tekstowa formatów zastępczych
    ///// </summary>
    //[DefaultValue(null)]
    //public string Subs 
    //{ 
    //  get
    //  {
    //    if (fSubstitutes != null && !fSubstitutes.IsEmpty())
    //      return fSubstitutes.ToString();
    //    return null;
    //  }
    //  set
    //  {
    //    TextFormatSubstitutes val;
    //    if (TextFormatSubstitutes.)
    //  }
    //}

    /// <summary>
    /// Czy zastępcze formaty mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeSubstitutes()
    {
      return fSubstitutes != null && !fSubstitutes.IsEmpty();
    }
  }
}
