using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Iml.Documentation
{
  /// <summary>
  /// Format dla części tabeli
  /// </summary>
  public partial class TablePartFormat: Format
  {
    /// <summary>
    /// Identyfikator formatu
    /// </summary>
    [DefaultValue(null)]
    public new String Id
    {
      get
      {
        if (fId == null && Collection != null)
          return Part.GetHashCode().ToString();
        return fId;
      }
      set
      {
        fId = value;
      }
    }

    /// <summary>
    /// Zwraca typ formatu
    /// </summary>
    public override FormatType Type
    {
      get { return FormatType.Table; }
    }

    /// <summary>
    /// Część tabeli, której dotyczy ten styl
    /// </summary>
    public TablePartKind Part { get; set; }

    /// <summary>
    /// Format tabeli
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public TableFormat TableFormat 
    {
      get { return (TableFormat)Components.FirstOrDefault(item=>item is TableFormat); }
      set 
      {
        Format item = TableFormat;
        if (item != null)
          Components.Remove(item);
        Components.Add(value); 
      }
    }

    /// <summary>
    /// Format wiersza tabeli
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public TableRowFormat RowFormat 
    {
      get { return (TableRowFormat)Components.FirstOrDefault(item => item is TableRowFormat); }
      set 
      {
        Format item = RowFormat;
        if (item != null)
          Components.Remove(item);
        Components.Add(value); 
      }
    }

    /// <summary>
    /// Format komórki tabeli
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public TableCellFormat CellFormat 
    {
      get { return (TableCellFormat)Components.FirstOrDefault(item => item is TableCellFormat); }
      set 
      {
        Format item = CellFormat;
        if (item != null)
          Components.Remove(item);
        Components.Add(value); 
      }
    }


    /// <summary>
    /// Format akapitu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [XmlIgnore]
    public ParagraphFormat ParagraphFormat 
    {
      get { return (ParagraphFormat)Components.FirstOrDefault(item => item is ParagraphFormat); }
      set 
      {
        Format item = ParagraphFormat;
        if (item != null)
          Components.Remove(item);
        Components.Add(value); 
      }
    }


    /// <summary>
    /// Format tekstu
    /// </summary>
    [DefaultValue(null)]
    public TextFormat TextFormat 
    {
      get { return (TextFormat)Components.FirstOrDefault(item => item is TextFormat); }
      set
      {
        Format item = TextFormat;
        if (item != null)
          Components.Remove(item);
        Components.Add(value);
      }
    }
  }

  /// <summary>
  /// Część tabeli dla której jest zdefiniowany styl <see cref="TablePartFormat"/>
  /// </summary>
  public enum TablePartKind
  {
    /// <summary>
    /// Styl wewnętrznego / nieparzystego wiersza (rozpoczynającego)
    /// </summary>
    InternalRow = 0x08,
    /// <summary>
    /// Styl pierwszego wiersza
    /// </summary>
    FirstRow = 0x09,
    /// <summary>
    /// Styl parzystego wiersza
    /// </summary>
    AlternateRow = 0x0A,
    /// <summary>
    /// Styl ostatniego wiersza
    /// </summary>
    LastRow = 0x0B,
    /// <summary>
    /// Styl wewnętrznej / nieparzystej kolumny (rozpoczynającej)
    /// </summary>
    InternalColumn = 0x80,
    /// <summary>
    /// Styl pierwszej kolumny
    /// </summary>
    FirstColumn = 0x90,
    /// <summary>
    /// Styl parzystej kolumny
    /// </summary>
    AlternateColumn = 0xA0,
    /// <summary>
    /// Styl ostatniej kolumny
    /// </summary>
    LastColumn = 0xB0,
    /// <summary>
    /// Styl komórki w pierwszym wierszu i pierwszej kolumnie
    /// </summary>
    FirstRowFirstColumn = 0x99,
    /// <summary>
    /// Styl komórki w pierwszym wierszu i ostatniej kolumnie
    /// </summary>
    FirstRowLastColumn = 0xB9,
    /// <summary>
    /// Styl komórki w ostatnim wierszu i pierwszej kolumnie
    /// </summary>
    LastRowFirstColumn = 0x9B,
    /// <summary>
    /// Styl komórki w ostatnim wierszu i ostatniej kolumnie
    /// </summary>
    LastRowLastColumn = 0xBB,
    /// <summary>
    /// Styl całej tabeli
    /// </summary>
    WholeTable = 0xFF,
  }
}
