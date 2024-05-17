using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista formatów w dokumencie
  /// </summary>
  public partial class Formats: ItemList<Format>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Formats () 
    { 
    }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Formats (object owner) : base(owner) { }

    /// <summary>
    /// Dostęp do domyślnego formatu tekstowego
    /// </summary>
    [DefaultValue(null)]
    public TextFormat TextFormat
    {
      get
      {
        return (TextFormat)this.FirstOrDefault(item => item is TextFormat);
      }
    }
    /// <summary>
    /// Dostęp do domyślnego formatu akapitowego
    /// </summary>
    [DefaultValue(null)]
    public ParagraphFormat ParagraphFormat
    {
      get
      {
        return (ParagraphFormat)this.FirstOrDefault(item => item is ParagraphFormat);
      }
    }
  }
}
