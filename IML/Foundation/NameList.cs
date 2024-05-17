using System;
using System.Linq;

namespace Iml.Foundation
{
  /// <summary>
  /// Lista nazw. Pilnuje, aby nie było nazw pustych
  /// oraz aby w danym języku była tylko jedna nazwa główna.
  /// </summary>
  public partial class NameList: ElementList<Name>
  {
    /// <summary>
    /// Domyślny konstruktor
    /// </summary>
    public NameList() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="aOwner"></param>
    public NameList(Element aOwner) : base(aOwner) { }

    /// <summary>
    /// Pobranie wartości nazwy w danym języku.
    /// </summary>
    /// <param name="language">
    /// Język, dla którego poszukiwana jest nazwa. Jeśli nie zostanie znaleziona,
    /// to poszukiwana jest w języku domyślnym (<c>Language==null</c>)
    /// </param>
    /// <returns>wartość nazwy</returns>
    public string GetValue(string language)
    {
      string result =
        (from item in this where item.Language == language && !item.IsAlias select item.Value).FirstOrDefault();
      if (result != null)
        return result;
      result =
        (from item in this where item.Language == null && !item.IsAlias select item.Value).FirstOrDefault();
      return result;
    }

    /// <summary>
    /// Pobranie nazwy w danym języku.
    /// </summary>
    /// <param name="language">
    /// Język, dla którego poszukiwana jest nazwa.
    /// </param>
    /// <returns>nazwy</returns>
    public Name GetName (string language)
    {
      Name result =
        (from item in this where item.Language == language && !item.IsAlias select item).FirstOrDefault ();
      return result;
    }

    /// <summary>
    /// Ustalenie wartości nazwy w danym języku.
    /// </summary>
    /// <param name="language">Język, dla którego ustawiana jest nazwa</param>
    /// <param name="value">wartość nazwy</param>
    public void SetValue(string language, string value)
    {
      Name aName = GetName (language);
      if (aName == null)
        Add (new Name (language, value));
      else
        aName.Value = value;
    }

    /// <summary>
    /// Lista nazw pilnuje, aby nie było nazw pustych
    /// oraz aby w danym języku była tylko jedna nazwa główna.
    /// Dlatego operacja wstawienia nazwy musi być kontrolowana
    /// </summary>
    /// <param name="index">pozycja wstawiania nazwy</param>
    /// <param name="aName">sama nazwa</param>
    public override void Insert(int index, Name aName)
    {
      // Jeśli wartość nazwy jest pusta, to jest ona usuwana
      if (aName.Value == null)
      {
        Name foundName =
          (from item in this
           where item.ID == aName.ID
           select item).FirstOrDefault();
        // jeśli znaleziono nazwę o danym identyfikatorze
        // to jest ona usuwana
        if (foundName != null)
          base.Remove(foundName);
      }
      else
      {
        Name foundName =
          (from item in this
           where item.ID == aName.ID
           select item).FirstOrDefault();
        // jeśli znaleziono już nazwę o danym identyfikatorze
        if (foundName != null)
        {
          // jeśli wstawiana nazwa nie jest pusta, to ok
          if (aName.Value != null)
            foundName.Value = aName.Value;
          // w przeciwnym wypadku element nazwy jest usuwany
          else
            base.Remove(foundName);
        }
        else
        { // jeśli nie znaleziono, to poszukuje się nazwy o danej wartości
          foundName =
            (from item in this
             where item.Language == aName.Language
               && String.Compare(item.Value, aName.Value, true) == 0
             select item).FirstOrDefault();
          // nazwa jest dodawana tylko wtedy, gdy nie ma jeszcze takiej nazwy w tym języku
          if (foundName == null)
          {
            int count =
                (from item in this
                 where item.Language == aName.Language
                 select item).Count();
            // jeśli już jest jakaś nazwa w danym języku, to druga nazwa musi być aliasem.
            if (count > 0 && !aName.IsAlias)
              aName.IsAlias = true;
            base.Insert(index, aName);
          }
        }
      }
    }

    ///// <summary>
    ///// Przepisanie identyfikatorów ID z innej listy.
    ///// Skojarzenie następuje wg identyfikatorów języka
    ///// </summary>
    //public override void MergeIDs(ElementList<Name> otherList)
    //{
    //  for (int i = 0; i < Count; i++)
    //  {
    //    Name thisItem = this[i];
    //    Name otherItem = (from item in otherList
    //     where item.Language == thisItem.Language
    //     select item).FirstOrDefault();
    //    if (otherItem!=null)
    //      thisItem.MergeID(otherItem);
    //  }
    //}

  }
}
