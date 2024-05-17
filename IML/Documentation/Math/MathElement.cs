using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IML = Iml.Documentation;

namespace Iml.Documentation
{
  /// <summary>
  /// Typy wynikowych elementów matematycznych
  /// </summary>
  public enum MathElementType { 
    /// <summary>
    /// Nieokreślony blok matematyczny
    /// </summary>
    Block,
    /// <summary>
    /// Blok rozpoznany na poziomie akapitu
    /// </summary>
    Para,
    /// <summary>
    /// Blok tekstowy
    /// </summary>
    Text, 
    /// <summary>
    /// Blok ograniczony (np. nawiasami)
    /// </summary>
    Delimiter,
    /// <summary>
    /// Blok ułamkowy (dzielenie)
    /// </summary>
    Fraction, 
    /// <summary>
    /// Blok indeksowania dolnego
    /// </summary>
    Subscript, 
    /// <summary>
    /// Blok indeksowania górnego
    /// </summary>
    Superscript,
    /// <summary>
    /// Blok indeksowania górnego i dolnego jednocześnie
    /// </summary>
    SubSuperscript,
    /// <summary>
    /// Blok z operatorem powiększonym i indeksami - górnym i dolnym
    /// </summary>
    NaryOperator,
    /// <summary>
    /// Blok funkcji matematycznej
    /// </summary>
    MathFunction,
    /// <summary>
    /// Blok akcentowany (np. pod kreską)
    /// </summary>
    Accent,
    /// <summary>
    /// Blok macierzy
    /// </summary>
    Matrix,
    /// <summary>
    /// Wiersz macierzy
    /// </summary>
    MatrixRow,
  }

  /// <summary>
  /// Obiekt reprezentujący matematyczną strukturę
  /// </summary>
  public partial class MathElement : IML.TextRun
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public MathElement()
    {
      Type = MathElementType.Block;
    }

    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="type"></param>
    public MathElement(MathElementType type)
    {
      Type = type;
    }

    /// <summary>
    /// Typ bloku
    /// </summary>
    public MathElementType Type { get; set; }

    /// <summary>
    /// Wartość całkowita określająca, o ile ma się zmienić rozmiar czcionki
    /// </summary>
    public int SizeChange { get; set; }

    /// <summary>
    /// Wartość opcji zależna od typu elementu
    /// </summary>
    public object TypedProperties { get; set; }

    /// <summary>
    /// Lista elementów
    /// </summary>
    private List<MathElement> Items; 

    /// <summary>
    /// Czy ma elementy składowe
    /// </summary>
    public bool HasItems
    {
      get
      {
        return Items != null;
      }
    }

    /// <summary>
    /// Dodanie elementu matematycznego
    /// </summary>
    /// <param name="item"></param>
    public void Add(MathElement item)
    {
      if (Items == null)
        Items = new List<MathElement>();
      Items.Add(item);
    }

    /// <summary>
    /// Dodanie elementu matematycznego
    /// </summary>
    public int Count
    {
      get
      {
        if (Items == null)
          return 0;
        else
          return Items.Count;
      }
    }

    /// <summary>
    /// Enumerator po elementach
    /// </summary>
    /// <returns></returns>
    public IEnumerator<MathElement> GetEnumerator()
    {
      if (Items == null)
        Items = new List<MathElement>(); 
      return Items.GetEnumerator();
    }

    /// <summary>
    /// Dostęp do pojedynczego argumentu wyrażenia
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public MathElement this[int n]
    {
      get { return Items[n]; }
    }

  }
}
