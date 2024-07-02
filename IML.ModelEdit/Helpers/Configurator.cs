using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary = MVVM.Dictionary;

namespace IML.ModelEdit
{
  public class Configurator: MVVM.Configurator
  {

    #region zasoby tekstowe metamodeli

    /// <summary>
    /// Słownik słowników zasobów tekstowych dla metamodeli. 
    /// Słowniki są indeksowane nazwą pliku zasobów (np. "Iml.Models.Requirements.Strings.pl.resx")
    /// Każdy słownik zawiera nazwy prezentacyjne klas i ich właściwości.
    /// </summary>
    public static Dictionary<string, Dictionary> MetamodelsResources = new Dictionary<string, Dictionary>();

    #endregion
  }
}
