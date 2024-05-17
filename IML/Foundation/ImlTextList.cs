using System.Linq;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace Iml.Foundation
{
  /// <summary>
  /// Lista elementów typu <see cref="ImlText"/>.
  /// Umożliwia wybór wersji językowej tekstu.
  /// </summary>
  [CollectionDataContract]
  public partial class ImlTextList: ElementList<ImlText>
  {
    /// <summary>
    /// Domyślny konstruktor
    /// </summary>
    public ImlTextList() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="aOwner"></param>
    public ImlTextList(Object aOwner): base (aOwner)
    {
      //Owner = aOwner;
    }

    //public object Owner { get; private set; }
    /// <summary>
    /// Pobranie tekstu w danym języku.
    /// </summary>
    /// <param name="language">
    /// Język, dla którego poszukiwany jest tekst. Jeśli nie zostanie znaleziony,
    /// to poszukiwany jest w języku domyślnym (<c>Language==null</c>)
    /// </param>
    /// <returns>tekst klasy <see cref="ImlText"/></returns>
    public ImlText GetValue(string language)
    {
      ImlText result =
        (from item in this where item.Language == language select item).FirstOrDefault();
      if (result != null)
        return result;
      result =
        (from item in this where item.Language == null select item).FirstOrDefault();
      return result;
    }

    /// <summary>
    /// Zapisanie tekstu w danym języku.
    /// </summary>
    /// <param name="language">Język, dla którego zapisywany jest tekst</param>
    /// <param name="value">tekst klasy <see cref="ImlText"/></param>
    public void SetValue(string language, ImlText value)
    {
      value.Language = language;
      Add(value);
    }
/*
    /// <summary>
    /// Lista tekstu pilnuje, aby nie było tekstu pustego.
    /// Dlatego operacja wstawienia tekstu musi być kontrolowana
    /// </summary>
    /// <param name="index">pozycja wstawiania tekstu</param>
    /// <param name="aRichText">sam tekst</param>
    public void Insert(int index, ImlText aRichText)
    {
      // Jeśli wartość tekstu jest pusta, to tekst jest usuwany
      if (aRichText.Text == null)
      {
        ImlText foundRichText =
          (from item in this
           where item.ID == aRichText.ID
           select item).FirstOrDefault();
        // jeśli znaleziono tekst o danym identyfikatorze
        // to jest on usuwana
        if (foundRichText != null)
          base.Remove(foundRichText);
      }
      else
      {
        ImlText foundRichText =
          (from item in this
           where item.ID == aRichText.ID
           select item).FirstOrDefault();
        // jeśli znaleziono już tekst o danym identyfikatorze
        if (foundRichText != null)
        {
          // jeśli wstawiany tekst nie jest pusty, to jest zmieniany na nowy
          if (aRichText.Text != null)
            foundRichText.Text = aRichText.Text;
          // w przeciwnym wypadku tekst jest usuwany
          else
            base.Remove(foundRichText);
        }
        else
        { // jeśli nie znaleziono, to poszukuje się tekstu w danym języku
          foundRichText =
              (from item in this
                where item.Language == aRichText.Language
                select item).FirstOrDefault();
           // jeśli już jest tekst w danym języku, to jest zmieniany na nowy.
          if (foundRichText != null)
            foundRichText.Text = aRichText.Text;
          else
            // a jeśli nie istnieje, to jest dodawany
            base.Insert(index, aRichText);
        }
      }
    }
 */ 
  }
}
