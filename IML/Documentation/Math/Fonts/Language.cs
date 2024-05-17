using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa zastępująca string dla właściwości "Language". 
  /// Umożliwia zdefiniowanie różnych nazw języków dla różnych skryptów.
  /// </summary>
  public partial class Language
  {
    /// <summary>
    /// Podstawowa nazwa języka
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Języki zastępcze (dla różnych skryptów)
    /// </summary>
    public LanguageSubstitutes Substitutes
    {
      get
      {
        if (substitutes == null)
          substitutes = new LanguageSubstitutes(this);
        return substitutes;
      }
      set { substitutes = value; if (value != null) value.SetOwner(this); }
    }
    private LanguageSubstitutes substitutes;

    /// <summary>
    /// Czy języki zastępcze są zdefiniowane?
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeLanguageSubstitutes ()
    {
      return substitutes != null && !substitutes.IsEmpty();
    }
  }
}

