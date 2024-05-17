using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Klasa reprezentująca osobę - autora dokumentu
  /// </summary>
  public class Person: Author
  {
    /// <summary>
    /// Imię
    /// </summary>
    public string FirstName;
    /// <summary>
    /// Drugie imię
    /// </summary>
    public string MidName;
    /// <summary>
    /// nazwisko
    /// </summary>
    public string LastName;

    /// <summary>
    /// Lista afiliacji. Każda afiliacja to łańcuch indeksujący 
    /// do wspólnych afiliacji w dokumencie.
    /// </summary>
    public string[] Affiliations;

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Person()
    {
    }

    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="fullName">pełna nazwa autora (rozbijana na części)</param>
    /// <param name="affCount">liczba afiliacji</param>
    public Person (string fullName, int affCount=0)
    {
      string[] Names = fullName.Split(' ');
      if (Names.Length > 0)
      {
        FirstName = Names[0];
        if (Names.Length > 1)
        {
          MidName = Names[1];
          if (Names.Length > 2)
          {
            LastName = Names[2];
          }
        }
      }
      Affiliations = new string[affCount];
    }

    /// <summary>
    /// Złożenie pełnej nazwy osoby
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      string result = null;
      if (this.FirstName != null)
        result = this.FirstName;
      if (this.MidName != null)
      {
        if (result != null)
          result += "\u00A0"; // dodanie spacji niepodzielnej
        result += this.MidName;
      }
      if (this.LastName != null)
      {
        if (result != null)
          result += "\u00A0"; // dodanie spacji niepodzielnej
        result += this.LastName;
      }
      return result;
    }
  }
}
