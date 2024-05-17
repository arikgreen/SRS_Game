using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.ComponentModel;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca indeksowaną listę elementów
  /// </summary>
  /// <typeparam name="indexType">typ indeksu (zgodnego z typem elementu)</typeparam>
  /// <typeparam name="itemType">typ elementu</typeparam>
  public partial class Scheme<indexType, itemType>: ObjectList<indexType> 
    where indexType: NamedItemIndex<itemType> where itemType: Item
  {
    /// <summary>
    /// Identyfikator lokalny tworzony na podstawie nazwy
    /// </summary>
    public string Id
    {
      get
      {
        if (fId != null)
          return fId;
        return (GetType().Name.GetHashCode() + Name.GetHashCode()).ToString("X8");
      }
      set
      {
        fId = value;
      }
    }
    /// <summary>
    /// Pole przechowujące identyfikator lokalny
    /// </summary>
    protected string fId;

    /// <summary>
    /// Nazwa schematu
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Wewnętrzny słownik
    /// </summary>
    private Dictionary<string, indexType> Index = new Dictionary<string, indexType>();

    /// <summary>
    /// Dodawanie elementu z nazwą
    /// </summary>
    /// <param name="name">indeks elementu</param>
    /// <param name="index">dodawany element</param>
    public void Add(string name, indexType index)
    {
      base.Add(index);
      index.Name = name;
      Index.Add(name, index);
    }

    /// <summary>
    /// Wyszukanie elementu po nazwie
    /// </summary>
    /// <param name="name">indeks elementu</param>
    /// <returns>znaleziony element albo null</returns>
    public indexType Find (string name)
    {
      if (Index.ContainsKey(name))
        return Index[name];
      return null;
    }

    /// <summary>
    /// Element właścicielski. Metoda "set" jest prywatna, aby właściwość nie była zapamiętywana
    /// </summary>
    public Element Owner { get; private set; }
    /// <summary>
    /// Metoda ustawienia właściciela. Może być szczególnie chroniona.
    /// </summary>
    /// <param name="item"></param>
    public void SetOwner(Element item)
    {
      Owner = item;
    }

  }
}
