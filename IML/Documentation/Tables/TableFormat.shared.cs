using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Iml.Documentation
{
  public partial class TableFormat
  {
    /// <summary>
    /// Czy format jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty()
    {
      return this.AlternateColumnStyle == null
          || this.AlternateRowStyle == null
          || this.Autofit == null
          || this.Borders == null
          || this.CellSpacing == null
          || this.ColBandSize == null
          || this.RowBandSize == null
          || this.DefaultCellMargin == null
          || this.TableAlignment == null
          //|| this.tablePartFormats == null
          || base.IsEmpty();
    }

    /// <summary>
    /// Pobranie stylu części tabeli
    /// </summary>
    public TablePartFormat GetTablePartFormat (TablePartKind part)
    {
      return (TablePartFormat)(from item in Components where (item is TablePartFormat) && (item as TablePartFormat).Part == part select item).FirstOrDefault();
    }

    /// <summary>
    /// Ustawienie stylu części tabeli
    /// </summary>
    public void SetTablePartFormat (TablePartFormat value)
    {
      TablePartFormat aPart = GetTablePartFormat(value.Part);
      if (aPart == null)
      {
        if (value != null)
          Components.Add(value);
      }
      else
      {
        if (aPart != value)
        {
          Components.Remove(value);
          if (value != null)
            Components.Add(value);
        }
      }
    }

    /// <summary>
    /// Styl pierwszego wiersza
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat FirstRowStyle
    {
      get { return GetTablePartFormat(TablePartKind.FirstRow); }
      set { if (value != null) value.Part = TablePartKind.FirstRow; SetTablePartFormat(value); }
    }

    /// <summary>
    /// Styl ostatniego wiersza
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat LastRowStyle
    {
      get { return GetTablePartFormat(TablePartKind.LastRow); }
      set { if (value != null) value.Part = TablePartKind.LastRow; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl pierwszej kolumny
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat FirstColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.FirstColumn); }
      set { if (value != null) value.Part = TablePartKind.FirstColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl ostatniej kolumny
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat LastColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.LastColumn); }
      set { if (value != null) value.Part = TablePartKind.FirstColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl wewnętrznego / nieparzystego wiersza (rozpoczynającego)
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat InternalRowStyle
    {
      get { return GetTablePartFormat(TablePartKind.InternalRow); }
      set { if (value != null) value.Part = TablePartKind.InternalRow; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl parzystego wiersza
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat AlternateRowStyle
    {
      get { return GetTablePartFormat(TablePartKind.AlternateRow); }
      set { if (value != null) value.Part = TablePartKind.AlternateRow; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl wewnętrznej / nieparzystej kolumny (rozpoczynającej)
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat InternalColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.InternalColumn); }
      set { if (value != null) value.Part = TablePartKind.InternalColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl parzystej kolumny
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat AlternateColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.AlternateColumn); }
      set { if (value != null) value.Part = TablePartKind.AlternateColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl komórki w pierwszym wierszu i pierwszej kolumnie
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat FirstRowFirstColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.FirstRowFirstColumn); }
      set { if (value != null) value.Part = TablePartKind.FirstRowFirstColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl komórki w pierwszym wierszu i ostatniej kolumnie
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat FirstRowLastColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.FirstRowLastColumn); }
      set { if (value != null) value.Part = TablePartKind.FirstRowLastColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl komórki w ostatnim wierszu i pierwszej kolumnie
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat LastRowFirstColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.LastRowFirstColumn); }
      set { if (value != null) value.Part = TablePartKind.LastRowFirstColumn; SetTablePartFormat(value); }
    }
    /// <summary>
    /// Styl komórki w ostatnim wierszu i ostatniej kolumnie
    /// </summary>
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TablePartFormat LastRowLastColumnStyle
    {
      get { return GetTablePartFormat(TablePartKind.LastRowLastColumn); }
      set { if (value != null) value.Part = TablePartKind.LastRowLastColumn; SetTablePartFormat(value); }
    }

  }
}
