using System;
using System.Linq;
using Iml.Foundation;

namespace Iml.Documentation
{

  /// <summary>
  /// Lista stylów klasy <see cref="TablePartFormat"/>
  /// </summary>
  public partial class TablePartFormatList: ItemList<TablePartFormat>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TablePartFormatList() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów.
    /// </summary>
    /// <param name="aOwner"></param>
    public TablePartFormatList(Item aOwner) : base(aOwner) { }

    /// <summary>
    /// Pobranie stylu części tabeli
    /// </summary>
    public TablePartFormat GetTablePartFormat (TablePartKind part)
    {
      return (from TablePartFormat item in this where item.Part == part select item).FirstOrDefault ();
    }

    /// <summary>
    /// Ustawienie stylu części tabeli
    /// </summary>
    public void SetTablePartFormat (TablePartKind part, TablePartFormat value)
    {
      if (value.Part == 0)
        value.Part = part;
      TablePartFormat aPart = (from TablePartFormat item in this where item.Part == part select item).FirstOrDefault ();
      if (aPart == null)
      {
        if (value!=null)
          this.Add (value);
      }
      else
      {
        if (aPart != value)
        {
          this.Remove (value);
          if (value!=null)
            this.Add (value);
        }
      }
    }
  }
}
