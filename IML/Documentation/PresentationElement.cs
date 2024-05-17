using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using IML = Iml.Foundation;
using Iml.Foundation;
using System.Windows.Media;
using System.ComponentModel.DataAnnotations;

namespace Iml.Documentation
{

  /// <summary>
  /// Klasa reprezentująca element prezentacyjny. 
  /// Podobnie jak <see cref="SemanticElement"/> jest to klasa abstrakcyjna.
  /// Ma pojedynczą referencję odnoszącą się do elementu semantycznego
  /// będącego przedmiotem prezentacji.
  /// </summary>
  [KnownType("GetKnownTypes")]
  public abstract partial class PresentationElement : ProjectElement//, IReferencingElement, IDisposable
  {
    /// <summary>
    /// Ponieważ <see cref="PresentationElement"/> jest klasą abstrakcyjną,
    /// więc musi udostępniać listę znanych typów konkretnych
    /// dla deserializacji. Typy te będą deklarowane w innych
    /// modułach, stąd lista typów jest budowana dynamicznie.
    /// </summary>
    public static List<Type> KnownTypes = new List<Type>();

    static Type[] GetKnownTypes()
    {
      return KnownTypes.ToArray();
    }
/*
    /// <summary>
    /// Przy fizycznym zniszczeniu elementu ulega zniszczeniu jego referencja do przedmiotu prezentacji.
    /// </summary>
    public void Dispose()
    {
      (this as IReferencingElement).ClearReferences();
    }
*/
    /// <summary>
    /// ID przedmiotu prezentacji.
    /// </summary>
    [DataMember]
    public Guid SubjectID
    {
      get
      {
        if (SubjectRef!=null)
          return SubjectRef.TargetID;
        else
          return Guid.Empty;
      }
      set
      {
        SubjectRef = new Reference { Owner = this, TargetID = value };
      }
    }

    partial void OnSubjectIDChanged ();

    /// <summary>
    /// ID elementu docelowego serializowany tylko, gdy niepusty
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeSubjectID() { return SubjectID != Guid.Empty; }

    /// <summary>
    /// Mieszanie ID z extra również dla referencji
    /// </summary>
    /// <param name="extra"></param>
    public override void MixID (string extra)
    {
      base.MixID (extra);
      //if (SubjectRef != null)
      //  SubjectRef.MixID (extra);
    }

    /// <summary>
    /// RefID elementu docelowego
    /// </summary>
    [XmlAttribute("SubjectRefID")]
    //[DefaultValue(null)]
    public string SubjectRefID
    {
      get
      {
        if (Subject is SemanticElement)
          return (Subject).RefID;
        else
          return null;
      }
      set 
      {
        SubjectRef = new Reference { Semantics = "presentation", TargetRefID = value };
      }
    }

    /// <summary>
    /// SubjectRefID zapamiętywany tylko wtedy, gdy <c>SubjectID=Guid.Empty</c>
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeSubjectRefID() 
    {
      return SubjectID == Guid.Empty && Subject is SemanticElement; 
    }

    /// <summary>
    /// Obiekt jest zapamiętywany jako SubjectID
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeSubject() { return false; }
/*
    #region implementacja interfejsu IRefencingElement

    /// <summary>
    /// Podaje listę elementów do rozwiązywania referencji
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerable<IReferencingElement> GetReferencingItems()
    {
      return new IReferencingElement[0];
    }

    void IReferencingElement.AddOutgoingReference(Reference aReference)
    {
      SubjectRef = aReference;
    }

    void IReferencingElement.RemoveOutgoingReference(Reference aReference)
    {
      if (aReference == SubjectRef)
        SubjectRef = null;
    }

    void IReferencingElement.ClearReferences()
    {
      SubjectRef = null;
      foreach (IReferencingElement item in GetReferencingItems ())
        item.ClearReferences ();
    }

    bool IReferencingElement.HasUnresolvedReferences 
    {
      get
      {
        if (SubjectRef != null)
          if (!SubjectRef.IsResolved)
            return true;
        foreach (IReferencingElement item in GetReferencingItems ())
          if (item.HasUnresolvedReferences)
            return true;
     
        return false;
      }
    }

    void IReferencingElement.ResolveReferences(IEnumerable<Element> referencedItems)
    {
      if (SubjectRef != null)
        SubjectRef.TryResolveReference (referencedItems);
      foreach (IReferencingElement item in GetReferencingItems ())
        item.ResolveReferences (referencedItems);
    }

    bool IReferencingElement.HasReferences
    {
      get
      {
        if (SubjectRef != null)
          return true;
        foreach (IReferencingElement item in GetReferencingItems ())
          if (item.HasReferences)
            return true;
        return false;
      }
    }

    IEnumerable<Reference> IReferencingElement.GetOutgoingReferences()
    {
      if (SubjectRef != null) 
        return new[] { SubjectRef };
      else
        return new Reference[] { };
    }
    #endregion
*/
    /// <summary>
    /// Sam przedmiot prezentacji.
    /// </summary>
    [DataMember]
    [Association ("PresentationElementSubject", "SubjectID", "ID")]
    public SemanticElement Subject
    {
      get
      {
        if (SubjectRef != null)
          return SubjectRef.Target as SemanticElement;
        else
          return null;
      }
      set
      {
        SubjectRef = new Reference { Target = value };
      }
    }

    private Brush background;
    /// <summary>
    /// Kolor tła elementu
    /// </summary>
    [DefaultValue(null)]
    public virtual Brush Background 
    {
      get { return background; }
      set
      {
        if (value != background)
        {
          background = value;
          NotifyPropertyChanged ("Background");
          IsModified = true;
        }
      }
    }

    /// <summary>
    /// Identyfikator stylu
    /// </summary>
    [DefaultValue(null)]
    public string StyleID
    {
      get
      {
        return _StyleID ?? ((Style != null) ? Style.Id : null);
      }
      set
      {
        _StyleID = value;
      }
    }
    private string _StyleID;

    /// <summary>
    /// styl fragmentu (z tabeli stylów)
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Style Style
    {
      get { return _Style; }
      set
      {
        if (value != _Style)
        {
          _Style = value;
          _StyleID = null;
        }
      }
    }
    private Style _Style;

    ///// <summary>
    ///// Identyfikator rewizji utworzenia elementu
    ///// </summary>
    //[DefaultValue(null)]
    //public string RevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji właściwości
    ///// </summary>
    //[DefaultValue(null)]
    //public string PropertiesRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji zawartości
    ///// </summary>
    //[DefaultValue(null)]
    //public string ContentRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji wyglądu
    ///// </summary>
    //[DefaultValue(null)]
    //public string LayoutRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji usunięcia elementu
    ///// </summary>
    //[DefaultValue(null)]
    //public string DeleteRevisionId { get; set; }
  }
}
