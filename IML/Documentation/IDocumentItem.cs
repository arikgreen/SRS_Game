namespace Iml.Documentation
{
  /// <summary>
  /// Interfejs, który musi implementować każdy element dokumentu.
  /// </summary>
  public interface IDocumentItem
  {
    /// <summary>
    /// Odwołanie do dokumentu, w którym element się znajduje.
    /// </summary>
    Document Document { get; }
  }
}
