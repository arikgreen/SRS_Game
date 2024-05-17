using System;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa atrybutu umożliwiająca określenie, jakie właściwości
  /// może posiadać dany element semantyczny. Określenie to obejmuje: 
  /// nazwę właściwości oraz atrybuty wymagalności.
  /// </summary>
  public partial class PropertyAttribute: ImlSemanticAttribute 
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="propertyName">nazwa właściwości</param>
    public PropertyAttribute(string propertyName)
    {
      PropertyName = propertyName;
    }

    /// <summary>
    /// Nazwa właściwości
    /// </summary>
    public string PropertyName { get; set; }

  }
}
