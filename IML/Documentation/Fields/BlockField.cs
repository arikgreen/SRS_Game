using System.ComponentModel;
using System.Xml.Serialization;
using Iml.Foundation;
using WinDocs = System.Windows.Documents;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa implementująca pole (jak w dokumencie Word'a), ale na bazie elementu typu <see cref="Block"/>
  /// z pakietu <see cref="Iml.Foundation"/>
  /// </summary>
  public partial class BlockField : Block
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public BlockField()
    { }

    /// <summary>
    /// Konstruktor właściwy dla elementu typu <see cref="Block"/>
    /// </summary>
    /// <param name="instrText"></param>
    public BlockField(string instrText)
    { InstrText = instrText; }

    /// <summary>
    /// Tekst formuły definiującej pole
    /// </summary>
    [XmlAttribute("InstrText")]
    [DefaultValue(null)]
    public string InstrText { get; set; }

    /// <summary>
    /// Opcjonalny nagłówek - tytuł pola
    /// </summary>
    [DefaultValue(null)]
    public string Caption { get; set; }

    /// <summary>
    /// Czy pole jest puste
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
