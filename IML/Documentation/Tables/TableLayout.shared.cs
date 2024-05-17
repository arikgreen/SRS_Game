using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class TableLayout : IEquatable<TableLayout>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TableLayout()
    {

    }

    ///// <summary>
    ///// Konstruktor inicjujący
    ///// </summary>
    ///// <param name="value"></param>
    //public TableLayout (int value)
    //{
    //  Attributes = value;
    //  SetAttributes = value;
    //}

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="other"></param>
    public TableLayout (TableLayout other)
    {
      Attributes = other.Attributes;
      SetAttributes = other.SetAttributes;
    }

    #region atrybuty typograficzne
    /// <summary>bity formatu</summary>
    public TableLook Attributes;
    /// <summary>które bity są ustawione</summary>
    public TableLook SetAttributes;

    #endregion


    /// <summary>
    /// Zbadanie ustawienia atrybutu
    /// </summary>
    /// <param name="mask">maska atrybutu</param>
    /// <param name="inverse">czy zanegować wartość</param>
    /// <returns></returns>
    public bool? GetAttribute (TableLook mask, bool inverse = false)
    {
      if (((int)SetAttributes & (int)mask) == 0)
        return null;
      bool result = ((int)Attributes & (int)mask) != 0;
      if (inverse)
        result = !result;
      return result;
    }

    /// <summary>
    /// Ustawienie/skasowanie atrybutu
    /// </summary>
    /// <param name="mask">maska atrybutu</param>
    /// <param name="value">wartość do ustawienia</param>
    /// <param name="inverse">czy zanegować wartość</param>
    public void SetAttribute (TableLook mask, bool? value, bool inverse = false)
    {
      if (value == null)
      {
        SetAttributes &= unchecked((TableLook)(~(int)mask));
        Attributes &= unchecked((TableLook)(~(int)mask));
      }
      else
      {
        bool val = (bool)value;
        if (inverse)
          val = !val;
        if (val)
          Attributes |= mask;
        else
          Attributes &= unchecked((TableLook)(~(int)mask));
        SetAttributes |= mask;
      }
    }

    /// <summary>
    /// Konieczne dla operatorów "==" i "!="
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals (object other)
    {
      if (other is TableLayout)
      {
        TableLayout otherLayout = (TableLayout)other;
        return ((Attributes & SetAttributes) ^ (otherLayout.Attributes & otherLayout.SetAttributes)) == 0;
      }
      return base.Equals(other);
    }

    /// <summary>
    /// Sprawdzenie, czy atrybuty są identyczne.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals (TableLayout other)
    {
      if (other == null)
        return false;
      bool ok = ((Attributes & SetAttributes) ^ (other.Attributes & other.SetAttributes)) == 0;
      return ok;
    }

    ///// <summary>
    ///// Operator równości - wymagany bo to struktura
    ///// </summary>
    ///// <param name="A"></param>
    ///// <param name="B"></param>
    ///// <returns></returns>
    //public static bool operator == (TableLayout A, TableLayout B)
    //{
    //  return A.Equals(B);
    //}

    ///// <summary>
    ///// Operator nierówności - wymagany, gdy zdefiniowany jest operator równości
    ///// </summary>
    ///// <param name="A"></param>
    ///// <param name="B"></param>
    ///// <returns></returns>
    //public static bool operator != (TableLayout A, TableLayout B)
    //{
    //  return !A.Equals(B);
    //}

    /// <summary>
    /// Oblicza kod dla funkcji skrótu
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode ()
    {
      return (this.Attributes & this.SetAttributes).GetHashCode();
    }


    /// <summary>
    /// Operator konwersji z int
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator TableLayout (int value)
    {
      return new TableLayout(value);
    }

  }

}
