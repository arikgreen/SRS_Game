using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista formatów zastępczych
  /// </summary>
  public partial class TextFormatSubstitutes : ItemIndex<TextFormatSub>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextFormatSubstitutes () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public TextFormatSubstitutes (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie elementu do indeksu
    /// </summary>
    public override void Add (TextFormatSub item)
    {
      Add(item.Script, item);
    }

    /// <summary>
    /// Próba dodania elementu o podanym indeksie
    /// </summary>
    /// <param name="script">klucz - skrypt dla formatu</param>
    /// <param name="item">istniejący lub nowoutworzony element</param>
    /// <returns>czy dodanie się udało (jeszcze nie było takiego elementu)</returns>
    public bool TryAddValue(string script, out TextFormatSub item)
    {
      if (TryGetValue(script, out item))
        return false;
      item = new TextFormatSub { Script = script };
      Add(script, item);
      return true;
    }
  }
}

