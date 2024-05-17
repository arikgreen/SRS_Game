using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Documentation;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca format akapitu
  /// </summary>
  public partial class ParagraphFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Paragraph; }
    }

    /// <summary>
    /// Trzymanie akapitu razem z następnym akapitem
    /// </summary>
    [DefaultValue(null)]
    public bool? KeepWithNext { get; set; }

    /// <summary>
    /// Trzymanie wszystkich linii akapitu razem
    /// </summary>
    [DefaultValue(null)]
    public bool? KeepLinesTogether { get; set; }

    /// <summary>
    /// Wymuszenie podziału strony przed akapitem
    /// </summary>
    [DefaultValue(null)]
    public bool? PageBreakBefore { get; set; }

    /// <summary>
    /// Trzymanie pierwszego i ostatniego wiersza razem z całym akapitem
    /// </summary>
    [DefaultValue(null)]
    public bool? WidowControl { get; set; }

    /// <summary>
    /// Pomijanie odstępów między podobnymi akapitami
    /// </summary>
    [DefaultValue(null)]
    public bool? ContextualSpacing { get; set; }

    /// <summary>
    /// Wyrównanie tekstu w akapicie
    /// </summary>
    [DefaultValue(null)]
    public HorizontalAlignment? Alignment { get; set; }

    /// <summary>
    /// Odstęp przed akapitem
    /// </summary>
    [DefaultValue (null)]
    public VerticalSpacing SpacingBefore { get; set; }

    /// <summary>
    /// Odstęp po akapicie
    /// </summary>
    [DefaultValue (null)]
    public VerticalSpacing SpacingAfter { get; set; }

    /// <summary>
    /// Odstęp międzyliniowy
    /// </summary>
    [DefaultValue (null)]
    public LineSpacing Interline { get; set; }

    /// <summary>
    /// Odstęp z lewej
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing LeftIndent { get; set; }
    /// <summary>
    /// Odstęp z prawej
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing RightIndent { get; set; }
    /// <summary>
    /// Wcięcie pierwszej linii
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing FirstLineIndent { get; set; }
    /// <summary>
    /// Wysunięcie pierwszej linii
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing HangingIndent { get; set; }
    
    /// <summary>
    /// Odstęp początkowy
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing StartIndent { get; set; }
    /// <summary>
    /// Odstęp końcowy
    /// </summary>
    [DefaultValue(null)]
    public HorizontalSpacing EndIndent { get; set; }
    
    /// <summary>
    /// Poziom nagłówkowy akapitu
    /// </summary>
    [DefaultValue(null)]
    public int? OutlineLevel { get; set; }

    /// <summary>
    /// Czy zaniechane numerowanie linii
    /// </summary>
    [DefaultValue(null)]
    public bool? SuppressLineNumbers { get; set; }
    
    /// <summary>
    /// Czy zawijanie tekstu z podziałem między wyrazami
    /// </summary>
    [DefaultValue(null)]
    public bool? WordWrap { get; set; }

    /// <summary>
    /// Czy zaniechane automatyczne dzielenie wyrazów
    /// </summary>
    [DefaultValue(null)]
    public bool? SuppressAutoHyphens { get; set; }

    /// <summary>
    /// Numerowanie akapitu. Element traktowany jako komponent;
    /// </summary>
    [DefaultValue(null)]
    public ParagraphNumbering Numbering 
    { 
      get { return fNumbering; }
      set { fNumbering = value; }
    }
    /// <summary>
    /// Pole przechowujące numerowanie akapitu
    /// </summary>
    protected ParagraphNumbering fNumbering;

    /// <summary>
    /// Tabulatory akapitu. Element traktowany jako komponent
    /// </summary>
    //[DefaultValue(null)]
    [XmlArray]
    [XmlArrayItem(typeof(TabStop))]
    public TabStops TabStops 
    {
      get
      {
        if (tabStops == null)
          tabStops = new TabStops(this);
        return tabStops;
      }
      set { tabStops = value; if (value != null) value.SetOwner(this); }
    }
    private TabStops tabStops;

    /// <summary>
    /// Czy tabulacja ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeTabStops ()
    {
      return tabStops != null && !tabStops.IsEmpty();
    }

    /// <summary>
    /// Obramowanie akapitu
    /// </summary>
    //[DefaultValue(null)]
    [XmlArray]
    [XmlArrayItem(typeof(BorderLine))]
    public virtual Borders Borders
    {
      get
      {
        if (borders == null)
          borders = new Borders(this);
        return borders;
      }
      set { borders = value; if (value != null) value.SetOwner(this); }
    }
    private Borders borders;

    /// <summary>
    /// Czy obramowanie ma być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBorders ()
    {
      return borders != null && !borders.IsEmpty();
    }

    /// <summary>
    /// Identyfikator dla HTML'a
    /// </summary>
    [DefaultValue(null)]
    public string DivId { get; set; }

    /// <summary>
    /// Cieniowanie tekstu
    /// </summary>
    [DefaultValue(null)]
    public Shading Shading { get; set; }
  }

}
