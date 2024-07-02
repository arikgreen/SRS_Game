using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using MyLib.GuidUtils;

namespace Iml.Foundation
{
  /// <summary>
  /// Uogólniona lista elementów. Umożliwia operacje na identyfikatorach unikatowych
  /// </summary>
  /// <typeparam name="itemType">element składowy musi być typu <see cref="Element"/></typeparam>
  public partial class ElementList<itemType>: ItemList<itemType> where itemType: Element
  {
    /// <summary>
    /// Konstruktor domyślny.
    /// </summary>
    public ElementList() { }

    /// <summary>
    /// Konstruktor ustalający właściciela listy.
    /// </summary>
    /// <param name="aOwner"></param>
    public ElementList(object aOwner) { SetOwner(aOwner); }

    /// <summary>
    /// Przepisanie identyfikatorów ID z innej listy.
    /// Przepisanie następuje od początku listy
    /// </summary>
    public virtual void MergeIDs(ElementList<itemType> otherList)
    {
      for (int i = 0; i < Math.Min(Count,otherList.Count); i++)
      {
        itemType thisItem = this[i];
        itemType otherItem = otherList[i];
        thisItem.MergeID(otherItem);
      }
    }

    /// <summary>
    /// Operacja XOR na identyfikatorach elementów z podanym łańcuchem znaków.
    /// Konieczna dla zapewnienia unikatowości identyfikatorów w sytuacji,
    /// gdy ten sam dokument w wielu wersjach jest wysyłany do klienta.
    /// Podaje się wówczas identyfikator wersji.
    /// </summary>
    /// <param name="extra">dodawany metodą XOR łańcuch znaków</param>
    public virtual void MixIDs (string extra)
    {
      foreach (Element item in this)
        item.MixID (extra);
    }
    /// <summary>
    /// Konwersja z nieznanego obiektu na obiekt akceptowany przez tę kolekcję. 
    /// Metoda wywoływana przy wczytywaniu z XAML.
    /// </summary>
    public virtual itemType ConvertItemFrom (object obj)
    {
      throw new Exception (String.Format("Can't convert from \"{0}\" to {1}",obj.ToString(), typeof(itemType).Name));
    }


  }
}
