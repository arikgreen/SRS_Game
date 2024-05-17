using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista rewizji dokumentu
  /// </summary>
  public partial class Revisions: ItemIndex<Revision>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Revisions () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner">obiekt właścicielski</param>
    public Revisions (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie rewizji (bez sprawdzenia)
    /// </summary>
    /// <param name="item"></param>
    public override void Add (Revision item)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Próba dodania rewizji o podanym numerze
    /// </summary>
    /// <param name="revisionId"></param>
    /// <param name="revision">wynikowy obiekt rewizji</param>
    /// <returns>czy dodanie się udało</returns>
    public bool TryAdd(string revisionId, out Revision revision)
    {
      if (TryGetValue(revisionId, out revision))
        return false;
      revision = new Revision { Id = revisionId };
      Add(revisionId, revision);
      return true;
    }
  }
}
