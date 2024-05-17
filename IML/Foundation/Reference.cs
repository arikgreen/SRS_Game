using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using MyLib.GuidUtils;

namespace Iml.Foundation
{

  /// <summary>
  /// Klasa reprezentująca referencję między elementami.
  /// Rozwiązanie referencji polega na znalezieniu elementu docelowego
  /// </summary>
  public partial class Reference: Element, IDisposable
  {
    #region konstruktory
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Reference () { }

    /// <summary>
    /// Konstruktor ze wskazaniem elementu docelowego
    /// </summary>
    public Reference (Element target) { Target = target; }

    /// <summary>
    /// Konstruktor ze wskazaniem identyfikatora elementu docelowego
    /// </summary>
    public Reference (Guid targetID) { TargetID = targetID; }

    /// <summary>
    /// Konstruktor z semantyką i elementem docelowym
    /// </summary>
    /// <param name="semantics">semantyka referencji</param>
    /// <param name="target">element docelowy</param>
    public Reference (string semantics, Element target)
    {
      Semantics = semantics;
      Target = target;
    }

    /// <summary>
    /// Konstruktor z semantyką i ID elementu docelowego
    /// </summary>
    /// <param name="semantics">semantyka referencji</param>
    /// <param name="targetID">ID elementu docelowego</param>
    public Reference (string semantics, Guid targetID)
    {
      Semantics = semantics;
      TargetID = targetID;
    }

    /// <summary>
    /// Konstruktor z semantyką i nazwą widoczną referencji
    /// </summary>
    /// <param name="semantics">semantyka referencji</param>
    /// <param name="displayName">nazwa widoczna - może zawierać RefID i nazwę elementu</param>
    public Reference (string semantics, string displayName)
    {
      Semantics = semantics;
      DisplayName = displayName;
    }
    #endregion konstruktory

    /// <summary>
    /// Destruktor powoduje zwolnienie referencji z elementu docelowego
    /// i elementu źródłowego
    /// </summary>
    ~Reference()
    {
      Dispose();
    }

    /// <summary>
    /// Zniszczenie powoduje zwolnienie referencji z elementu docelowego
    /// i elementu źródłowego
    /// </summary>
    public void Dispose()
    {
      if (Target is IReferencedElement)
        (Target as IReferencedElement).RemoveIncomingReference(this);
      if (Source is IReferencingElement)
        (Source as IReferencingElement).RemoveOutgoingReference(this);
    }

    #region właściwości referencji
    /// <summary>
    /// Źródło referencji określone przez element właścicielski, 
    /// który musi implementować interfejs <see cref="IReferencingElement"/>
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Element Source 
    {
      get
      {
        if (Owner is Reference) // to jest właściwe dla subreferencji
          return (Owner as Reference).Source;
        else
          if (Owner is IReferencingElement)
            return (Owner as IReferencingElement).Instance as Element;
          else
            return null;
      }
    }

    private Guid fTargetID;
    /// <summary>
    /// ID elementu docelowego
    /// </summary>
    [XmlAttribute("TargetID")]
    public Guid TargetID
    {
      get
      {
        if (Target is Element)
          return (Target as Element).ID;
        else
          return fTargetID;
      }
      set { fTargetID = value; }
    }

    /// <summary>
    /// ID elementu docelowego serializowany tylko, gdy niepusty
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeTargetID () { return TargetID != Guid.Empty; }

    /// <summary>
    /// Nazwa elementu docelowego - pole;
    /// </summary>
    protected string fTargetName;
    /// <summary>
    /// Nazwa elementu docelowego
    /// </summary>
    [XmlAttribute ("TargetName")]
    [DefaultValue(null)]
    public string TargetName
    {
      get
      {
        if (Target != null && Target.Instance is INamedElement)
          return (Target.Instance as INamedElement).Name;
        else
          return fTargetName;
      }
      set { fTargetName = value; }
    }

    /// <summary>
    /// RefID elementu docelowego - pole
    /// </summary>
    protected string fTargetRefID;
    /// <summary>
    /// RefID elementu docelowego
    /// </summary>
    [XmlAttribute("TargetRefID")]
    [DefaultValue(null)]
    public string TargetRefID
    {
      get
      {
        if (Target is SemanticElement)
          return (Target as SemanticElement).RefID;
        else
          return fTargetRefID;
      }
      set { fTargetRefID = value; }
    }

    /// <summary>
    /// Czy referencja jest już rozwiązana?
    /// </summary>
    public bool IsResolved
    {
      get { return (Source != null) && (Target != null); }
    }

    #endregion właściwości referencji

    #region metody rozwiązywania referencji

    /// <summary>
    /// Próba rozwiązania referencji
    /// </summary>
    /// <param name="referencedItems">lista przeglądanych elementów</param>
    /// <returns>czy rozwiązano referencję?</returns>
    public virtual bool TryResolveReference(IEnumerable<Element> referencedItems)
    {
      bool ok = false;
      VerifyRefData ();
      if (fTargetID!=Guid.Empty)
        ok = TryResolveID (referencedItems, fTargetID);
      if (!ok && fTargetRefID != null)
        ok = TryResolveRefID (referencedItems, fTargetRefID);
      if (!ok && fTargetName != null)
        ok = TryResolveName (referencedItems, fTargetName);
      return ok;
    }

    /// <summary>
    /// Próba rozwiązania referencji przez identyfikator GUID
    /// </summary>
    /// <param name="referencedItems">lista przeglądanych elementów</param>
    /// <param name="targetID">poszukiwany identyfikator GUID</param>
    /// <returns>czy rozwiązano referencję?</returns>
    protected bool TryResolveID (IEnumerable<Element> referencedItems, Guid targetID)
    {
      Element targetByID = (from item in referencedItems 
                 where item.ID == targetID 
                 select item).FirstOrDefault();
      if (targetByID is IReferencedElement)
      {
        fTarget = (targetByID as IReferencedElement).Instance as Element;
        if (fTarget is IReferencedElement)
           (fTarget as IReferencedElement).AddIncomingReference(this);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Próba rozwiązania referencji przez identyfikator referencyjny
    /// </summary>
    /// <param name="referencedItems">lista przeglądanych elementów</param>
    /// <param name="targetRefID">identyfikator referencyjny elementu docelowego</param>
    /// <returns>czy rozwiązano referencję?</returns>
    public bool TryResolveRefID(IEnumerable<object> referencedItems, string targetRefID)
    {
      IReferencedElement targetByID = (from item in referencedItems 
                 where (item is IReferencedElement) && (item as IReferencedElement).RefID == targetRefID 
                 select item as IReferencedElement).FirstOrDefault();
      if (targetByID != null)
      {
        fTarget = targetByID.Instance as Element;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Próba rozwiązania referencji przez nazwę
    /// </summary>
    /// <param name="referencedItems">lista przeglądanych elementów</param>
    /// <param name="targetName">nazwa elementu docelowego</param>
    /// <returns>czy rozwiązano referencję?</returns>
    public bool TryResolveName (IEnumerable<object> referencedItems, string targetName)
    {
      if (targetName == "defer")
        return false;
      IReferencedElement targetByID = (from item in referencedItems
                                       where (item is IReferencedElement) && (item as IReferencedElement).Name == targetName
                                       select item as IReferencedElement).FirstOrDefault ();
      if (targetByID != null)
      {
        fTarget = targetByID.Instance as Element;
        return true;
      }
      return false;
    }

    #endregion metody rozwiązywania referencji
    #region właściwości referencji
    /// <summary>
    /// Semantyka referencji.
    /// </summary>
    [XmlAttribute("Semantics")]
    [DefaultValue(null)]
    public string Semantics { get; set; }

    private Element fTarget;
    /// <summary>
    /// Element docelowy referencji - musi implementować interfejs <see cref="IReferencingElement"/>
    /// </summary>

    [DataMember]
    [Association("ReferenceTarget","TargetID","ID")]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Element Target
    {
      get { return fTarget; }
      set
      {
        if (value != fTarget)
        {
          if (fTarget is IReferencedElement)
            (fTarget as IReferencedElement).RemoveIncomingReference(this);
          fTarget = value;
          if (fTarget is IReferencedElement)
            (fTarget as IReferencedElement).AddIncomingReference(this);
        }
      }
    }
/*
    private Guid targetID;
    /// <summary>
    /// ID elementu docelowego
    /// </summary>
    [XmlAttribute("TargetID")]
    public Guid TargetID
    {
      get
      {
        if (Target != null)
          return Target.ID;
        else
          return targetID;
      }
      set { targetID = value; }
    }

    /// <summary>
    /// ID elementu docelowego serializowany tylko, gdy niepusty
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeTargetID() { return TargetID != Guid.Empty; }
    private string targetName;
    /// <summary>
    /// Nazwa widoczna elementu docelowego.
    /// </summary>
    [XmlAttribute("TargetName")]
    [DefaultValue(null)]
    public new string TargetName
    {
      get
      {
        if ((Target is SemanticElement))
          return (Target as SemanticElement).DisplayName;
        else
          return targetName;
      }
      set
      {
        targetName = value;
      }
    }
*/
    private string displayName;
    /// <summary>
    /// Nazwa widoczna referencji. Składa się z <see cref="IReferencedElement.RefID"/> i nazwy elementu docelowego.
    /// Jeśli referencja jest "odłożona" (<see cref="IsDeferred"/>), to nazwą jest "defer".
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [IgnoreDataMember]
    public string DisplayName
    {
      get
      {
        if (Target is SemanticElement)
          return (Target as SemanticElement).RefID + " " + (Target as SemanticElement).DisplayName;
        else
          if (displayName != null)
            return displayName;
          else if (IsDeferred)
            return "defer";
          else
          {
            return TargetRefID;
          }
      }
      set
      {
        if (value == "defer")
          IsDeferred = true;
        else
          displayName = value;
      }
    }

    /// <summary>
    /// Referencja nie jest rozwiązywalna. Oczekuje na zdefiniowanie elementu docelowego.
    /// </summary>
    [XmlAttribute("IsDeferred")]
    [DefaultValue(false)]
    public bool IsDeferred { get; set; }
 

    private Reference subreference;
    /// <summary>
    /// Subreferencja - odnosi się do elementu składowego elementu docelowego referencji nadrzędnej.
    /// </summary>
    [XmlElement("subreference")]
    [DataMember]
    [Association("Subreference", "ID", "OwnerID")]
    [DefaultValue(null)]
    public Reference Subreference 
    { 
      get { return subreference; }
      set { subreference = value; if (subreference != null) subreference.Owner = this; }
    }

    #endregion

    #region metody rozwiązywania referencji
/*
    /// <summary>
    /// Czy referencja jest już rozwiązana?
    /// </summary>
    public override bool IsResolved
    {
      get { return (Source != null) && (Target != null); }
    }
*/
    /// <summary>
    /// Sprawdzenie napisów identyfikujących element docelowy
    /// </summary>
    private void VerifyRefData ()
    {
      if (fTargetRefID==null)
      {
        string s = fTargetName;
        if (s!=null)
        {
          int n = s.IndexOfAny (new char[]{'_',' '});
          if (n > 0)
          {
            int m = s.IndexOfAny (new char[] { '_', ' ' },n+1);
            if (m > 0)
            {
              string s1 = s.Substring (0, m);
              if (IsValidRefID (s1))
              {
                fTargetRefID = s1;
                fTargetName = s.Substring (m + 1);
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Sprawdzenie, czy napis jest poprawnym identyfikatorem referencyjnym
    /// postaci XXXX_9999
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private bool IsValidRefID (string s)
    {
      int part = 1;
      foreach (char ch in s)
      {
        if (ch == '_')
          part++;
        else if (part == 1)
        {
          if (!Char.IsUpper(ch))
            return false;
        }
        else
        {
          if (!Char.IsDigit (ch))
            return false;
        }
      }
      return part == 2;
    }
    /// <summary>
    /// Podział napisu określającego element docelowy na <see cref="IReferencedElement.RefID"/> i nazwę elementu docelowego.
    /// </summary>
    /// <param name="targetStr">napis wejściowy</param>
    /// <param name="refID">wynik - <see cref="IReferencedElement.RefID"/> elementu docelowego (sprawdzana poprawność składni)</param>
    /// <param name="refName">wynik - nazwa elementu docelowego (po spacji)</param>
    /// <param name="rest">wynik - reszta nazwy widocznej (po kropce)</param>
    public static void Parse(string targetStr, out string refID, out string refName, out string rest)
    {
      //Debug.WriteLine ("Parse: "+ targetStr);
      string s = targetStr.Trim();
      int n = s.IndexOf('.');
      if (n >= 0)
      {
        rest = s.Substring(n + 1).Trim();
        s = s.Substring(0, n).Trim();
      }
      else
      {
        rest = null;
      }
      n = s.IndexOf(' ');
      if (n >= 0)
      {
        refID = s.Substring(0, n).Trim();
        refName = s.Substring(n + 1).Trim();
        if (!IsRefID(refID))
        {
          refName = refID + " " + refName;
          refID = null;
        }
      }
      else
      {
        if (IsRefID(s))
        {
          refID = s;
          refName = null;
        }
        else
        {
          refID = null;
          refName = s;
        }
      }
    }

    /// <summary>
    ///   Sprawdzenie poprawności identyfikatora referencyjnego. 
    ///   Poprawny <see cref="IReferencedElement.RefID"/> musi mieć dowolny przedrostek z liter,
    ///   znak podkreślenia i końcówkę z cyfr.
    /// </summary>
    /// <param name="str">łańcuch wejściowy</param>
    /// <returns>czy jest to poprawny identyfikator referencyjny</returns>
    public static bool IsRefID(string str)
    {
      int n = str.IndexOf('_');
      for (int i = 0; i < n; i++)
        if (!Char.IsLetter(str[i]))
          return false;
      for (int i = n+1; i < str.Length; i++)
        if (!Char.IsDigit(str[i]))
          return false;
      return true;
    }

    /// <summary>
    /// Próba rozwiązania referencji
    /// </summary>
    /// <param name="referencedItems">lista przeglądanych elementów</param>
    /// <param name="targetStr">napis określający element docelowy</param>
    /// <returns>czy rozwiązano referencję?</returns>
    public bool TryResolveReference(IEnumerable<object> referencedItems, string targetStr)
    {
      string refRest;

      Parse(targetStr, out fTargetRefID, out fTargetName, out refRest);
      bool ok = false;
      if (fTargetRefID!=null)
        ok = TryResolveRefID(referencedItems, fTargetRefID);
      if (!ok && fTargetName!=null)
         ok = TryResolveName(referencedItems, fTargetName);
      if (fTarget is IReferencedElement && refRest != null)
      {
        return TryResolveSubreference((fTarget as IReferencedElement), refRest);
      }
      else
        return ok;
    }


    /// <summary>
    /// Próba rozwiązania subreferencji
    /// </summary>
    /// <param name="aElement">element, którego elementy składowe są przeglądane</param>
    /// <param name="refRest">napis składowy określający element docelowy</param>
    /// <returns>czy rozwiązano subreferencję?</returns>
    private bool TryResolveSubreference(IReferencedElement aElement, string refRest)
    {
      if (refRest == null)
        return true;
      if (!aElement.HasItems)
        return false;
      if (Subreference == null)
      {
        Subreference = new Reference(null, refRest);
        Subreference.Owner = this;
      }
      return Subreference.TryResolveReference(aElement.GetItems(), refRest);
    }
    #endregion

    /// <summary>
    /// Porównanie z inną referencją
    /// </summary>
    public virtual bool Equals(Reference other)
    {
      if (this.Semantics != other.Semantics)
        return false;
      if (this.Target != null && this.Target != other.Target)
        return false;
      if (this.TargetID != null && this.TargetID != other.TargetID)
        return false;
      if (this.TargetRefID != null && this.TargetRefID != other.TargetRefID)
        return false;
      if (this.Subreference != null && other.Subreference != null)
        return this.Subreference.Equals(other.Subreference);
      return true;
    }

    /// <summary>
    /// Przepisanie ID z innego elementu
    /// </summary>
    public void MergeID(Object otherElement)
    {
      if (otherElement is Reference)
      {
        Reference other = (Reference)otherElement;
        if (this.Subreference != null && other.Subreference != null)
          this.Subreference.MergeID(other.Subreference);
      }
    }

    /// <summary>
    /// Mieszanie ID z extra również dla TargetID i dla subreferencji
    /// </summary>
    /// <param name="extra"></param>
    public override void MixID (string extra)
    {
      if (fTargetID != Guid.Empty)
        fTargetID = GuidTools.Mix (fTargetID, extra);
      if (Subreference != null)
        Subreference.MixID (extra);
    }
  }
}
