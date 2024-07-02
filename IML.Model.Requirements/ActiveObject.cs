using System.Runtime.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Abstrakcyjna klasa aktywnego obiektu systemu. 
  /// Zalicza się tu obiekty zewnętrzne (np. użytkowników) jak i obiekty wewnętrzne (np. komponenty)
  /// Zawiera motywacje (potrzeby i zadania).
  /// </summary>
  [Metaclass(Order="3")]
  [IsAbstract]
  [KnownType(typeof(ExternalObject))]
  [KnownType(typeof(ComponentObject))]
  [CanContain(typeof(Motivation),GroupName="needs", Stereotype="need")]
  [CanContain(typeof(Motivation), GroupName="tasks", Stereotype="task")]
  public class ActiveObject : RequirementsElement
  {
    /// <summary>
    /// Konstruktor publiczny tworzy listę motywacji
    /// </summary>
    public ActiveObject()
    {
      Motivations = new SemanticQuery<Motivation>(this.Items, item => item is Motivation);
    }

    /// <summary>
    /// potrzeby obiektu, które system musi zaspokoić; zadania, które system musi pomóc wykonać
    /// </summary>
    [MetaclassProperty]
    public SemanticQuery<Motivation> Motivations { get; private set;}
    

  }
}
