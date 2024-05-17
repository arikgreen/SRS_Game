using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Iml.Documentation
{
  public partial struct TextAttributes: IEquatable<TextAttributes>
  {

    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="value"></param>
    public TextAttributes (int value)
    {
      Attributes = value;
      SetAttributes = value;
    }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="other"></param>
    public TextAttributes (TextAttributes other)
    {
      Attributes = other.Attributes;
      SetAttributes = other.SetAttributes;
    }

    #region atrybuty typograficzne i ich maski
    /// <summary>bity formatu</summary>
    private int Attributes;
    /// <summary>które bity są ustawione</summary>
    private int SetAttributes;

    /// <summary>maska atrybutu pochylenia</summary>
    private const int ItalicMask = 0x0001;

    /// <summary>maska atrybutu wytłuszczenia</summary>
    private const int BoldfaceMask = 0x0002;

    /// <summary>maska atrybutu podkreślenia</summary>
    private const int UnderlinedMask = 0x0010;

    /// <summary>maska atrybutu nadkreślenia</summary>
    private const int StrikethroughMask = 0x0020;

    /// <summary>maska atrybutu indeksowania górnego</summary>
    private const int SuperscriptMask = 0x0040;

    /// <summary>maska atrybutu indeksowania dolnego</summary>
    private const int SubscriptMask = 0x0080;
    #endregion


    private bool? getAttribute (int mask)
    {
      if ((SetAttributes & mask) == 0)
        return null;
      return (Attributes & mask) != 0;
    }

    private void setAttribute (int mask, bool? value)
    {
      if (value == null)
      {
        SetAttributes &= unchecked((int)(~mask));
        Attributes &= unchecked((int)(~mask));
      }
      else
      {
        if ((bool)value)
          Attributes |= mask;
        else 
          Attributes &= unchecked((int)(~mask));
        SetAttributes |= mask;
      }
    }

    #region atrybuty dostępowe do atrybutów z typem bool
    /// <summary>
    /// Właściwość dostępowa do atrybutu Italic
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsItalic
    {
      get { return getAsBool(ItalicMask); }
      set { setAsBool(ItalicMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Boldface
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsBoldface
    {
      get { return getAsBool(BoldfaceMask); }
      set { setAsBool(BoldfaceMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Underlined
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsUnderlined
    {
      get { return getAsBool(UnderlinedMask); }
      set { setAsBool(UnderlinedMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu StrikeThrough
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsStrikethrough
    {
      get { return getAsBool(StrikethroughMask); }
      set { setAsBool(StrikethroughMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Subscript
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSuperscript
    {
      get { return getAsBool(SuperscriptMask); }
      set { setAsBool(SuperscriptMask, value); }
    }

    /// <summary>
    /// Właściwość dostępowa do atrybutu Superscript
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSubscript
    {
      get { return getAsBool(SubscriptMask); }
      set { setAsBool(SubscriptMask, value); }
    }

    private bool getAsBool (int mask)
    {
      if ((SetAttributes & mask) == 0)
        return false;
      return (Attributes & mask) != 0;
    }

    private void setAsBool (int mask, bool value)
    {
      if ((bool)value)
        Attributes |= mask;
      else Attributes &= unchecked((int)(~mask));
      SetAttributes |= mask;
    }
    #endregion

    /// <summary>
    /// Konieczne dla operatorów "==" i "!="
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals (object other)
    {
      if (other is TextAttributes)
        return Equals((TextAttributes)other);
      return base.Equals(other);
    }

    /// <summary>
    /// Sprawdzenie, czy atrybuty są identyczne.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals (TextAttributes other)
    {
      bool ok = ((Attributes & SetAttributes) ^ (other.Attributes & other.SetAttributes)) == 0;
      return ok;
    }

    /// <summary>
    /// Zwraca nowy format z wyzerowanym bitem (lub bitami)
    /// </summary>
    /// <param name="mask">podaje, które bity wyzerować</param>
    /// <returns>nowy format z wyzerowanym bitem (lub bitami)</returns>
    public TextAttributes AndNot (int mask)
    {
      TextAttributes result = new TextAttributes(this);
      result.Attributes &= unchecked((int)(~mask));
      result.SetAttributes &= unchecked((int)(~mask));
      return result;
    }

    /// <summary>
    /// Operator równości - wymagany bo to struktura
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    public static bool operator == (TextAttributes A, TextAttributes B)
    {
      return A.Equals(B);
    }

    /// <summary>
    /// Operator nierówności - wymagany, gdy zdefiniowany jest operator równości
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    public static bool operator != (TextAttributes A, TextAttributes B)
    {
      return !A.Equals(B);
    }

    /// <summary>
    /// Oblicza kod dla funkcji skrótu
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode ()
    {
      return (this.Attributes & this.SetAttributes).GetHashCode();
    }

    /// <summary>
    /// Operator konwersji na int
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public static implicit operator int (TextAttributes A)
    {
      return A.Attributes & A.SetAttributes;
    }

    /// <summary>
    /// Operator konwersji z int
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator TextAttributes (int value)
    {
      return new TextAttributes(value);
    }

    /// <summary>
    /// Połączenie zbioru atrybutów
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public TextAttributes Merge (TextAttributes other)
    {
      TextAttributes newAttributes = new TextAttributes();
      newAttributes.Attributes = (byte)(this.Attributes & (unchecked((byte)(~other.SetAttributes))) | (byte)(other.Attributes & other.SetAttributes));
      return newAttributes;
    }

    /// <summary>
    /// Konwersja na łańcuch - dla potrzeb śledzenia
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      string s = null;
      if (IsItalic)
      {
        if (s != null)
          s += ",";
        s += "italic";
      }
      if (IsBoldface)
      {
        if (s != null)
          s += ",";
        s += "bold";
      }
      if (IsUnderlined)
      {
        if (s != null)
          s += ",";
        s += "underline";
      }
      if (IsStrikethrough)
      {
        if (s != null)
          s += ",";
        s += "overlined";
      }
      if (IsSuperscript)
      {
        if (s != null)
          s += ",";
        s += "superscript";
      }
      if (IsSubscript)
      {
        if (s != null)
          s += ",";
        s += "subscript";
      }
      return "{" + s + "}";
    }
  }
}
