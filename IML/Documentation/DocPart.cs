using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca pewną część dokumentu
  /// </summary>
  [ContentProperty("Body")]
  public partial class DocPart: Item
  {

    /// <summary>
    /// Nazwa części
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Kategoria części (dowolna)
    /// </summary>
    [DefaultValue(null)]
    public string Category { get; set; }

    /// <summary>
    /// Galeria części (dowolna wartość tekstowa)
    /// </summary>
    [DefaultValue(null)]
    public string Gallery { get; set; }

    /// <summary>
    /// Typ części (dowolna wartość tekstowa)
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }

    /// <summary>
    /// Zachowanie części (dowolna wartość tekstowa)
    /// </summary>
    [DefaultValue(null)]
    public string Behavior { get; set; }

    /// <summary>
    /// Tekst dokumentu
    /// </summary>
    [DataMember]
    [Association("PartBody", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Body Body 
    { 
      get 
      {
        if (fBody == null)
          fBody = new Body();
        return fBody; 
      } 
    }
    /// <summary>
    /// Pole przechowujące ciało części
    /// </summary>
    protected Body fBody;

    /// <summary>
    /// Czy ciało ma być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeBody()
    {
      return fBody != null && !fBody.IsEmpty();
    }
  }
}
