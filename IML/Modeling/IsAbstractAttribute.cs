using System;

namespace Iml.Modeling
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca oznaczenie klasy elementu jako klasy abstrakcyjnej.
  /// Potrzebna, gdy klasa abstrakcyjna nie jest przenoszona na stronę klienta przez RIA.
  /// Wówczas trzeba ją oznaczyć jako zwykłą klasę i oznaczyć tym atrybutem.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false,Inherited = true)]
  public partial class IsAbstractAttribute: Attribute 
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public IsAbstractAttribute()
    {
    }

  }
}
