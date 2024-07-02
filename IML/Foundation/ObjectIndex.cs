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
    public partial class ObjectIndex<itemType>: ObjectList<itemType>
    {
      /// <summary>
      /// Nazwa własna indeksu
      /// </summary>
      [DefaultValue(null)]
      public string Name { get; set; }

      private Dictionary<string, itemType> dictionary = new Dictionary<string, itemType>();

      /// <summary>
      /// Dodanie elementu z kluczem
      /// </summary>
      /// <param name="key">klucz elementu</param>
      /// <param name="item">dodawany element</param>
      public virtual void Add (string key, itemType item)
      {
        base.Add(item);
        dictionary.Add(key, item);
      }

      /// <summary>
      /// Dostęp do elementu indeksowanego przez klucz
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      public itemType GetItem (string key)
      {
        return dictionary[key];
      }

      /// <summary>
      /// Czy indeks zawiera klucz
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      public bool ContainsKey (string key)
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
      public bool Remove (string key)
      {
        itemType item = GetItem(key);
        dictionary.Remove(key);
        return base.Remove(item);
      }

      ///// <summary>
      ///// Na razie nie zaimplementowane, ale potrzebne aby móc zastąpić 
      ///// obiekt klasy <c>ObjectIndex</c>przez obiekt klasy <c>ItemList</c> w klasach potomnych
      ///// </summary>
      ///// <param name="owner"></param>
      //public void SetOwner (object owner)
      //{

      //}

      /// <summary>
      /// Konstruktor domyślny. Dla wprowadzenia konstruktora z właścicielem
      /// </summary>
      public ObjectIndex () { }

      /// <summary>
      /// Konstruktor z właścicielem.
      /// </summary>
      public ObjectIndex (object owner)
      {
        SetOwner(owner);
      }
    }
  }


