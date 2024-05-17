using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{

  /// <summary>
  /// Klasa reprezentująca adres autora
  /// </summary>
  public class Address
  {
    /// <summary>
    /// Etykieta identyfikująca adres
    /// </summary>
    public string Label;

    /// <summary>
    /// Kolejne linie adresu
    /// </summary>
    public List<string> Lines = new List<string>();

    /// <summary>
    /// Konstruktor bez podanego adresu
    /// </summary>
    public Address (string label)
    {
      Label = label;
    }

    /// <summary>
    /// Konstruktor z podanym adresem
    /// </summary>
    public Address (string label, string address)
    {
      Label = label;
      Lines.Add(address);
    }

  }
}
