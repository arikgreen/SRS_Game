using System.Runtime.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Historia dokumentu. 
  /// Pokazuje jakie zmiany zostały wprowadzone w dokumencie, przez kogo i kiedy
  /// </summary>
  [CollectionDataContract]
  public partial class History : ElementList<HistoryItem>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public History()
    { }

    /// <summary>
    /// Konstruktor właściwy dla listy elementów
    /// </summary>
    /// <param name="aOwner"></param>
    public History(Element aOwner) : base(aOwner) { }

  }
}

