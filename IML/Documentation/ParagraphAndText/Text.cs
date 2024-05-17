using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca fragment tekstowy
  /// </summary>
  [ContentProperty("Value")]
  public partial class Text: TextItem
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Text () { }

    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="value"></param>
    public Text (string value) 
    {
      Value = value;
    }

    /// <summary>
    /// tekst wczytany z dokumentu
    /// </summary>
    [XmlText]
    public String Value
    {
      get
      {
        return fText;
      }
      set
      {
        fText = value;
      }
    }
    /// <summary>
    /// Pole przechowujące tekst
    /// </summary>
    protected string fText;

    /// <summary>
    /// Czy tekst ma być serializowany
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeText ()
    {
      return fText != null && !String.IsNullOrWhiteSpace(fText);
    }

    /// <summary>
    /// Po prostu podaje wartość łańcucha
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return Value;
    }

    /// <summary>
    /// Sprawdza, czy tekst jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return String.IsNullOrEmpty(fText);
    }

    /// <summary>
    /// Właściwość reprezentująca liczbę odstępów w tekście, gdy tekst składa się z samych odstępów. 
    /// Potrzebna dla serializacji
    /// </summary>
    [DefaultValue(0)]
    public int Whitespaces
    {
      get
      {
        if (fText != null && String.IsNullOrWhiteSpace(fText))
          return fText.Length;
        return 0;
      }
      set
      {
        if (value != 0)
          fText = new string(' ', value);
      }
    }

  }
}
