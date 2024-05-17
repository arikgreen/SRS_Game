using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca interesariusza projektu
  /// </summary>
  [Metaclass(Order = "1.1")]
  public class Stakeholder: Source
  {
    private StakeholderKind kind;
    /// <summary>
    /// Rodzaj źródła
    /// </summary>
    //[Required]
    [MetaclassProperty]
    [Obsolete]
    [IgnoreDataMember]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StakeholderKind Kind 
    {
      get { return kind; }
      set
      {
        kind = value;
        Stereotype = stereotypes[(int)value];
      }
    }

    private readonly string[] stereotypes = { null, "person", "organization", "group" };

    /// <summary>
    /// Osoba reprezentująca (nazwisko, dane kontaktowe etc.)
    /// </summary>
    public string Representative { get; set; }
  }

  



}

