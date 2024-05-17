using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iml.Foundation
{
  /// <summary>
  /// Kwerenda dająca dostęp do innej, źródłowej listy elementów i wybierająca z niej pewne elementy
  /// </summary>
  public partial class ElementQuery<itemType, sourceType>: ICollection<itemType> where itemType: sourceType
  {
    private IList<sourceType> Source;
    private Predicate<sourceType> Match;
    /// <summary>
    /// Konstruktor dla kwerendy stanowiącej podzbiór innej listy.
    /// </summary>
    /// <param name="source">źródłowa kolekcja elementów</param>
    /// <param name="match">warunek filtrowania</param>
    public ElementQuery(IList<sourceType> source, Predicate<sourceType> match)
    { 
      Source = source;
      Match = match;
    }

    /// <summary>
    /// Dodanie elementu.
    /// </summary>
    /// <param name="item">element dodawany</param>
    public void Add(itemType item) 
    { 
      Source.Add(item); 
    }

    /// <summary>
    /// Czy lista jest pusta?
    /// </summary>
    public bool IsEmpty() 
    { 
      return (from item in Source
              where Match(item)
              select item).Count()==0;
    }

    /// <summary>
    /// Enumerator listy.
    /// </summary>
    public IEnumerator<itemType> GetEnumerator() 
    { 
      return (from item in Source
              where Match(item)
              select item).GetEnumerator() as IEnumerator<itemType>;
    }

    IEnumerator IEnumerable.GetEnumerator() 
    { 
      return (from item in Source
              where Match(item)
              select item).GetEnumerator();
    }
/*
    /// <summary>
    /// Dostęp do pojedynczego elementu
    /// </summary>
    /// <param name="index">indeks elementu</param>
    public itemType this[int index] 
    { 
      get { return items[index]; 
    } 
      set { items[index] = value; } 
    }
*/
    /// <summary>
    /// Czy lista jest tylko do czytania?
    /// </summary>
    public bool IsReadOnly { get { return false; } }

    /// <summary>
    /// Liczba elementów listy.
    /// </summary>
    public int Count 
    { 
      get
      {
        return (from item in Source
        where Match(item)
        select item).Count();
      }
    }

    /// <summary>
    /// Kopiowanie listy do tablicy.
    /// </summary>
    /// <param name="array">tablica docelowa</param>
    /// <param name="index">pozycja, od której kopiować</param>
    public void CopyTo(itemType[] array, int index) 
    {
      (from item in Source
       where Match(item)
       select item).ToArray().CopyTo(array, index); 
    }

    /// <summary>
    /// Czy zawiera element?
    /// </summary>
    /// <param name="aItem">poszukiwany element</param>
    public bool Contains(itemType aItem) 
    {
      return (from item in Source
              where Match(item)
              select item).Contains(aItem);
    }

    /// <summary>
    /// Usunięcie elementu
    /// </summary>
    /// <param name="item">usuwany element</param>
    /// <returns>czy operacja się udała?</returns>
    public bool Remove(itemType item) 
    { 
      return Source.Remove(item); 
    }

    /// <summary>
    /// Usunięcie wszystkich elementów z listy.
    /// </summary>
    public void Clear() 
    { 
      sourceType[] items =
       (from item in Source
        where Match(item)
        select item).ToArray();
      foreach (object item in items)
        Remove((itemType)item);
    }
/*
    /// <summary>
    /// Usunięcie elementu na podanej pozycji
    /// </summary>
    /// <param name="index">pozycja usuwanego elementu</param>
    public void RemoveAt(int index) { items.RemoveAt(index); }

    /// <summary>
    /// Wyszukanie elementu
    /// </summary>
    /// <param name="item">poszukiwany element</param>
    /// <returns>pozycja wyszukanego elementu, -1 gdy nie znaleziono</returns>
    public int IndexOf(itemType item) { return items.IndexOf(item); }

    /// <summary>
    /// Wirtualna metoda wstawiania elementów. Umożliwia rozszerzenie implementacji
    /// przez klasy potomne.
    /// </summary>
    /// <param name="index">pozycja elementu</param>
    /// <param name="item">wstawiany element</param>
    public virtual void Insert(int index, itemType item) 
    {
      items.Insert(index, item);
      item.SetOwner(this.Owner);
    }
 */ 
  }
}
