using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using MyLib.GuidUtils;
using Iml.Modeling;

namespace Iml.Foundation
{
  /// <summary>
  /// Podstawowa klasa elementu IML. Deklaruje unikatowy identyfikator.
  /// Umożliwia nawiązanie relacji zawierania między elementem tej klasy, 
  /// a innym elementem nadrzędnym (właścicielskim).
  /// </summary>
  [KnownType (typeof(Iml.Documentation.Document))]
  [KnownType (typeof(Iml.Documentation.Property))]
  [KnownType (typeof(Iml.Documentation.Style))]
  [KnownType (typeof(Iml.Foundation.Name))]
  [KnownType (typeof(Iml.Foundation.ImlText))]
  [KnownType (typeof(Iml.Documentation.TablePartFormat))]
  [KnownType (typeof(Iml.Documentation.HistoryItem))]
  [KnownType (typeof(Iml.Documentation.Block))]
  [KnownType (typeof(Iml.Documentation.Inline))]
  [KnownType (typeof(Iml.Documentation.PresentationElement))]
  //[KnownType (typeof(Iml.Documentation.TableColumn))]
  [KnownType (typeof(Iml.Documentation.TableRow))]
  [KnownType (typeof (Iml.Documentation.TableCell))]
  [KnownType (typeof (Iml.Documentation.Section))]
  [KnownType (typeof (Iml.Foundation.NamedElement))]
  [KnownType (typeof (Iml.Foundation.ProjectElement))]
  [KnownType (typeof (Iml.Foundation.SemanticElement))]
  [KnownType (typeof (Iml.Foundation.Reference))]
  //[KnownType (typeof (Iml.Documentation.TextElement))]
  [DataContractAttribute]
  [SerializableAttribute]
  public abstract partial class Element : CompoundItem
  {

    /// <summary>
    /// Identyfikator elementu. Typ <c>Guid</c> zapewnia unikatowość.
    /// </summary>
    [MetaclassProperty(Order="0")]
    [DataMember]
    [DesignerSerializationOptions(DesignerSerializationOptions.SerializeAsAttribute)]
    [Display(Order=0)]
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Domyślny Id jest zwracany tylko wtedy, gdy nie ma ID'a
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        if (ID != default(Guid))
          return null;
        return base.Id;
      }
      set
      {
        base.Id = value;
      }
    }
    /// <summary>
    /// Identyfikator pusty nie powinien być serializowany. 
    /// Nie można użyć atrybutu <c>DefaultValue</c>, 
    /// bo <c>Guid.Empty</c> nie jest stałą.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeID() 
    {
      return ID != Guid.Empty; 
    }
/*
    /// <summary>
    /// Unikatowy identyfikator dla wszystkich wersji elementu.
    /// Musi być deklarowany osobno, bo w RIA Services nie można deklarować klucza wielopolowego.
    /// Z kolei każda encja otwierana w różnych wersjach może mieć różne właściwości,
    /// stąd muszą to być różne encje.
    /// </summary>
    [Key]
    [DataMember]
    [DesignerSerializationOptions (DesignerSerializationOptions.SerializeAsAttribute)]
    public Guid UID { get; set; }

    /// <summary>
    /// Identyfikator pusty nie powinien być serializowany. 
    /// Nie można użyć atrybutu <c>DefaultValue</c>, 
    /// bo <c>Guid.Empty</c> nie jest stałą.
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeUID () { return UID != Guid.Empty; }
*/
    ///// <summary>
    ///// Główny konstruktor. Ustawia nowy ID.
    ///// </summary>
    //public Element()
    //{
    //  ID = Guid.NewGuid();
    //}

    /// <summary>
    /// Znacznik jawnego usunięcia elementu.
    /// </summary>
    [DataMember]
    [DefaultValue(false)]
    [Display (AutoGenerateField = false)]
    public bool Deleted { get; set; }

    /// <summary>
    /// Identyfikator elementu właścicielskiego, zawierającego dany element.
    /// </summary>
    [DataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Display (AutoGenerateField = false)]
    [XmlIgnore]
    public Guid OwnerID 
    { 
      get { if (Owner is Element) return (Owner as Element).ID; else return fOwnerID; }
      set { fOwnerID = value; }
    }
    Guid fOwnerID;

    /// <summary>
    /// Identyfikator właściciela nie jest serializowany, jeśli jest pusty
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeOwnerID ()
    {
      return OwnerID != Guid.Empty;
    }

    /// <summary>
    /// Przepisanie ID z innego elementu
    /// </summary>
    public virtual void MergeID(Element otherElement)
    {
      ID = otherElement.ID;
    }


    /// <summary>
    /// Operacja XOR na identyfikatorze z podanym łańcuchem znaków.
    /// Konieczna dla zapewnienia unikatowości identyfikatorów w sytuacji,
    /// gdy ten sam dokument w wielu wersjach jest wysyłany do klienta.
    /// Podaje się wówczas identyfikator wersji.
    /// </summary>
    /// <param name="extra">dodawany metodą XOR łańcuch znaków</param>
    public virtual void MixID (string extra)
    {
      ID = GuidTools.Mix (ID, extra);
    }


    /// <summary>
    /// Dynamiczna zmiana klasy elementu. Stary element jest serializowany z nową nazwą klasy, a po deserializacji
    /// zwracany jest nowa instancja elementu (w nowej klasie), ale z zachowanymi właściwościami publicznymi.
    /// Nowa klasa musi akceptować właściwości serializowanego elementu.
    /// </summary>
    /// <param name="newClass">nowa klasa elementu</param>
    /// <returns>nowy element (w nowej klasie)</returns>
    public virtual Element ChangeClass (System.Type newClass)
    {
      string s0 = XamlWriter.Save (this);
      string[] lines = s0.Split (new char[]{'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
      string s1 = lines[0];
      lines[0]=s1.Replace("utf-16","utf-8");
      s1 = lines[1];
      if (s1.Length > 0 && s1[0]=='<')
      {
        int m = s1.IndexOf (':');
        int n = s1.IndexOf (' ');
        if (n <= 0)
          n = s1.IndexOf ('/');
        if (n <= 0)
          n = s1.IndexOf ('>');
        if (m > n)
          m = 0;
        string oldName = s1.Substring (m + 1, n - m - 1).Trim ();
        if (oldName == this.GetType ().Name)
        {
          s1 = s1.Remove (m + 1, n - m - 1);
          s1 = s1.Insert (m + 1, newClass.Name);
          lines[1] = s1;
          if (lines.Length > 2)
          {
            s1 = lines[lines.Length-1];
            if (s1.Length > 0 && s1[0] == '<')
            {
              m = s1.IndexOf (':');
              n = s1.IndexOf (' ');
              if (n <= 0)
                n = s1.IndexOf ('>');
              if (m > n)
                m = s1.IndexOf ('/');
              oldName = s1.Substring (m + 1, n - m - 1).Trim ();
              if (oldName == this.GetType ().Name)
              {
                s1 = s1.Remove (m + 1, n - m - 1);
                s1 = s1.Insert (m + 1, newClass.Name);
                lines[lines.Length - 1] = s1;
              }
            }
          }
          MemoryStream aStream = new MemoryStream ();
          TextWriter aWriter = new StreamWriter(aStream, Encoding.UTF8);
          foreach (string s in lines)
            aWriter.WriteLine (s);
          aWriter.Flush ();
          aStream.Seek(0,SeekOrigin.Begin);
          XmlReader xReader = XmlTextReader.Create (aStream);
          Element result = XamlReader.Load (xReader) as Element;
          return result;
        }
      }
      return this;
    }

    /// <summary>
    /// Kopia elementu (pełna kopia - przez serializację)
    /// </summary>
    /// <returns></returns>
    public Element Duplicate ()
    {
      string s = XamlWriter.Save (this);
      StringReader stringReader = new StringReader(s);
      XmlReader xReader = XmlReader.Create(stringReader);
      return XamlReader.Load (xReader) as Element;
    }

  }
}
