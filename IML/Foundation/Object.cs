using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Abstrakcyjna klasa bazowa dla wszystkich obiektów modelu danych IML
  /// </summary>
  [Serializable]
  public partial class Object: IObject
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Object () { }

    /// <summary>
    /// Konstruktor kopiujący (nic nie robi)
    /// </summary>
    /// <param name="source"></param>
    public Object (Object source) { }

    /// <summary>
    /// Zwraca instancję samego siebie
    /// </summary>
    public Object Instance
    {
      get { return this; }
    }
  }
}
