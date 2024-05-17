using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Indeksowana lista elementów
  /// </summary>
  /// <typeparam name="itemType"></typeparam>
  public abstract partial class ItemIndex<itemType>: ItemList <itemType> where itemType: Item
  {
    private Dictionary<string, itemType> dictionary = new Dictionary<string, itemType>();

    /// <summary>
    /// Abstrakcyjna procedura dodawania elementu. Powinna dodać element też do indeksu.
    /// </summary>
    /// <param name="item"></param>
    public new abstract void Add(itemType item);

    /// <summary>
    /// Dodanie elementu z kluczem
    /// </summary>
    /// <param name="key">klucz elementu</param>
    /// <param name="item">dodawany element</param>
    protected virtual void Add (string key, itemType item)
    {
      base.Add(item);
      dictionary.Add(key, item);
    }

    /// <summary>
    /// Dostęp do elementu indeksowanego przez klucz
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public itemType GetItem(string key)
    {
      return dictionary[key];
    }  

    /// <summary>
    /// Czy indeks zawiera klucz
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool ContainsKey(string key)
    {
      return dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Próba pobrania elementu po kluczu
    /// </summary>
    /// <param name="key"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool TryGetValue (string key, out itemType item)
    {
      return dictionary.TryGetValue(key, out item);
    }

    /// <summary>
    /// Usunięcie elementu o podanym kluczu
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Remove(string key)
    {
      itemType item = GetItem(key);
      dictionary.Remove(key);
      return base.Remove(item);
    }


    /// <summary>
    /// Konstruktor domyślny. Dla wprowadzenia konstruktora z właścicielem
    /// </summary>
    public ItemIndex () { }

    /// <summary>
    /// Konstruktor z właścicielem.
    /// </summary>
    public ItemIndex (object owner) 
    {
      SetOwner(owner);
    }
  }
}
