using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca listę sekcji
  /// </summary>
  public partial class Sections: ItemList<Section>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Sections() { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="aOwner"></param>
    public Sections(object aOwner) : base(aOwner) { }
  }
}
