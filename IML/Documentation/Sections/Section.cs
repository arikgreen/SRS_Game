using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using System.Xml.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca sekcję (rozdział, podrozdział) w dokumencie
  /// </summary>
  public partial class Section : DocumentContent
  {
    /// <summary>
    /// Konstruktor domyślny. Tworzy listę elementów i podsekcji.
    /// </summary>
    public Section()
    {
      body = new BlockList(this);
    }

    /// <summary>
    /// Odwołanie do dokumentu, w którym element się znajduje. 
    /// Może być bezpośrednie lub pośrednie.
    /// </summary>
    public Document Document
    {
      get
      {
        object aOwner = Owner;
        while (aOwner != null && !(aOwner is Document))
        {
          if (aOwner is Element)
            aOwner = (aOwner as Element).Owner;
          else
            aOwner = null;
        }
        return aOwner as Document;
      }
    }

    /// <summary>
    /// Obliczany poziom zagłębienia sekcji. Pierwszy poziom, zawarty bezpośrednio w dokumencie, 
    /// ma <see cref="OutlineLevel"/><c>==1</c>
    /// </summary>
    public int OutlineLevel 
    { 
      get 
      {
        if (Owner is Section)
          return (Owner as Section).OutlineLevel + 1;
        else
          return 1; 
      } 
    }

    /// <summary>
    /// Nagłówek - tytuł sekcji
    /// </summary>
    [XmlAttribute("Caption")]
    [DefaultValue(null)]
    public string Caption { get; set; }

    private BlockList body;
    /// <summary>
    /// Lista bloków tekstu zawarta w sekcji
    /// </summary>
    [DataMember]
    [Association("SectionBody", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BlockList Body
    {
      get { return body; }
    }

    /// <summary>
    /// Lista bloków sekcji jest serializowana tylko wtedy, gdy lista ta nie jest pusta
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBody()
    {
      return !body.IsEmpty();
    }

    //private Sections subsections;
    ///// <summary>
    ///// Lista podsekcji
    ///// </summary>
    //[DataMember]
    //[Include]
    //[Association("SectionSubsections", "ID", "OwnerID")]
    //[Composition]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //public Sections Subsections 
    //{ 
    //  get { return subsections; } 
    //}

    ///// <summary>
    ///// Lista podsekcji jest serializowana tylko wtedy, gdy lista ta nie jest pusta
    ///// </summary>
    ///// <returns></returns>
    //public bool ShouldSerializeSubsections()
    //{
    //  return !subsections.IsEmpty();
    //}

    ///// <summary>
    ///// Rozwiązanie referencji z bloków prezentacyjnych w sekcji
    ///// do elementów semantycznych.
    ///// </summary>
    ///// <param name="referencedItems">przeglądana lista elementów</param>
    //public void ResolveReferences(IEnumerable<Element> referencedItems)
    //{
    //  if (Body != null)
    //    Body.ResolveReferences (referencedItems);
    //  foreach (Section aSection in Subsections)
    //    aSection.ResolveReferences(referencedItems);
    //}

    ///// <summary>
    ///// Przepisanie ID z innego elementu
    ///// </summary>
    //public override void MergeID(Element otherElement)
    //{
    //  base.MergeID(otherElement);
    //  if (otherElement is Section)
    //  {
    //    Section otherSection = (Section)otherElement;
    //    this.Body.MergeIDs(otherSection.Body);
    //    this.Subsections.MergeIDs(otherSection.Subsections);
    //  }
    //}

    ///// <summary>
    ///// Mieszanie ID z extra również dla podsekcji
    ///// </summary>
    ///// <param name="extra"></param>
    //public override void MixID (string extra)
    //{
    //  base.MixID (extra);
    //  Body.MixIDs (extra);
    //  Subsections.MixIDs (extra);
    //}

    /// <summary>
    /// Prefix - potrzebny do RefID tabeli
    /// </summary>
    [DefaultValue(null)]
    public string Prefix { get; set; }

    /// <summary>
    /// Czy wypełnienie obowiązkowe - parametr dla kontroli kompletności
    /// </summary>
    [DefaultValue(false)]
    public bool Required { get; set; }

    /// <summary>
    /// Na razie nie jest pusta
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
