using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class ComplexFieldRun
  {
    /// <summary>
    /// Konstruktor domyślnych
    /// </summary>
    public ComplexFieldRun () { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="sourceRun">źródłowy fragment tekstowy</param>
    public ComplexFieldRun (Run sourceRun)
      : base(sourceRun)
    {
    }

    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = 0;
        if (Definitions != null)
          hash += Definitions.GetHash();
        if (Collection != null)
          hash = Collection.MakeHashUnique(hash);
        fHashCode = hash;
      }
      return (int)fHashCode;
    }
    /// <summary>
    /// Pole przechowujące kod skrótu
    /// </summary>
    protected int? fHashCode = null;
  }
}
