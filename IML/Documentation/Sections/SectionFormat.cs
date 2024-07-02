using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Właściwości sekcji dokumentu
  /// </summary>
  public partial class SectionFormat: Format
  {
    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Section; }
    }

    /// <summary>
    /// Identyfikator rewizji usunięcia
    /// </summary>
    [DefaultValue(null)]
    public string DeleteRevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji zawartości
    /// </summary>
    [DefaultValue(null)]
    public string SectionRevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji zawartości
    /// </summary>
    [DefaultValue(null)]
    public string MarkRevisionId { get; set; }

    /// <summary>
    /// Typ podziału sekcji
    /// </summary>
    [DefaultValue(null)]
    public SectionBreakType? BreakType { get; set; }

    /// <summary>
    /// Referencja do nagłówka
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public HeaderReference HeaderReference 
    { 
      get
      {
        return (HeaderReference)Components.LastOrDefault(item => item is HeaderReference);
      }
      set
      {
        Components.Add(value);
      }
    }

    /// <summary>
    /// Referencja do stopki
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public FooterReference FooterReference
    {
      get
      {
        return (FooterReference)Components.LastOrDefault(item => item is FooterReference);
      }
      set
      {
        Components.Add(value);
      }
    }


    /// <summary>
    /// Format strony
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PageFormat PageFormat
    {
      get
      {
        return (PageFormat)Components.LastOrDefault(item => item is PageFormat);
      }
      set
      {
        Components.Add(value);
      }
    }

    /// <summary>
    /// Czy pierwsza strona ma inny nagłówek/stopkę
    /// </summary>
    public bool? DifferentFirstPage { get; set; }

    /// <summary>
    /// Odległość międzyznakowa
    /// </summary>
    public HorizontalSpacing CharacterSpace { get; set; }
    /// <summary>
    /// Odległość międzyliniowa
    /// </summary>
    public PointValue LinePitch { get; set; }
    /// <summary>
    /// Typ siatki dokumentu
    /// </summary>
    public DocGridType GridType { get; set; }
    /// <summary>
    /// Format przypisów końcowych
    /// </summary>
    public DocnoteFormat FootnoteFormat { get; set; }
    /// <summary>
    /// Format przypisów dolnych
    /// </summary>
    public DocnoteFormat EndnoteFormat { get; set; }

    /// <summary>
    /// Element nigdy nie będzie pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
