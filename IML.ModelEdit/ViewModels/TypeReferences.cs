using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IML.ModelEdit
{
  /// <summary>
  /// Lista referencji do typu
  /// </summary>
  public class TypeReferences : ViewModelsList<TypeReference>
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="source">element, do którego należy ta lista</param>
    public TypeReferences(ViewModelBase source)
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
    protected override void OnLoad()
    {
      throw new NotImplementedException();
    }
  }

}
