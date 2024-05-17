using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Markup;
using WinDocs = System.Windows.Documents;
using Iml.Foundation;
using System;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca blok zawierający element prezentacyjny.
  /// Ponieważ nie ma dziedziczenia wielokrotnego, więc po prostu
  /// opakowuje element prezentacyjny.
  /// </summary>
  [ContentProperty("Content")]
  public partial class PresentationBlock: Block
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public PresentationBlock() { }

    /// <summary>
    /// Konstruktor ułatwiający tworzenie bloku prezentacyjnego
    /// </summary>
    /// <param name="aContent">element prezentacyjny - inicjalna zawartość bloku</param>
    public PresentationBlock(PresentationElement aContent)
    {
        content = aContent;
    }

    private PresentationElement content;
    /// <summary>
    /// Zawartość bloku - element prezentacyjny
    /// </summary>
    //[DefaultValue(null)]
    [DataMember]
    [Association("BlockContent", "ID", "OwnerID")]
    public PresentationElement Content 
    { 
      get { return content; }
      set
      {
        content = value;
        if (content != null)
        {
          content.Owner = this;
          //SubjectID = content.SubjectID;  
        }
      } 
    }

    /// <summary>
    /// Domyślna tabelka specyfikacji nie jest serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeContent ()
    {

      return Content != null && !(Content is SpecificationTable);
    }
    ///// <summary>
    ///// Przepisanie ID z innego elementu
    ///// </summary>
    //public override void MergeID(Element otherElement)
    //{
    //  base.MergeID(otherElement);
    //  if (otherElement is PresentationBlock)
    //  {
    //    PresentationBlock other = (PresentationBlock)otherElement;
    //    if (this.Content != null && other.Content != null)
    //      this.Content.MergeID(other.Content);
    //  }
    //}

    ///// <summary>
    ///// Mieszanie ID z extra też dla zawartości
    ///// </summary>
    ///// <param name="extra"></param>
    //public override void MixID (string extra)
    //{
    //  base.MixID (extra);
    //  Content.MixID (extra);
    //}

    /// <summary>
    /// Czy blok jest pusty?
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
