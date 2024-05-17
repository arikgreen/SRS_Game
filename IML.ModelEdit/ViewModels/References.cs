using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace IML.ModelEdit
{
  /// <summary>
  /// Lista referencji do innych modeli widoku
  /// </summary>
  public class References: ViewModelsList<Reference>
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="source">element, do którego należy ta lista</param>
    public References(ViewModelBase source)
    {
      Source = source;
    }

    /// <summary>
    /// Źródło wszystkich referencji
    /// </summary>
    public ViewModelBase Source { get; protected set; }

    /// <summary>
    /// Kolekcja nie jest przewidziana do ładowania
    /// </summary>
    protected override void OnLoad ()
    {
      throw new NotImplementedException();
    }
  }
}
