using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element reprezentujący ciało dokumentu
  /// </summary>
  public partial class Body: ContentList
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Body (): base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Body (Item owner) : base(owner) { }

    /// <summary>
    /// Stały identyfikator
    /// </summary>
    public string Id
    {
      get { return "Body".GetHashCode().ToString("X8"); }
      set { }
    }

    /// <summary>
    /// Właściwości sekcji
    /// </summary>
    public SectionFormat SectionFormat { get; set; }
  }
}
