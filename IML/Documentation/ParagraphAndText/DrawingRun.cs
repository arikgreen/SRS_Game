using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Element składowy akapitu, który reprezentuje rysunek
  /// </summary>
  [ContentProperty("Drawing")]
  public partial class DrawingRun: Run
  {
    /// <summary>
    /// Kod skrótu na podstawie zawartości
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (fHashCode == null)
      {
        int hash = "DrawinGRun".GetHashCode();
        if (Drawing != null)
          hash += Drawing.GetHash();
        if (RevisionId != null)
        {
          int val;
          if (int.TryParse(RevisionId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
            hash += val;
        }
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

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DrawingRun (): base() { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    public DrawingRun (Run source): base(source) { }
    
    /// <summary>
    /// Rysunek w tekście
    /// </summary>
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Drawings.Drawing Drawing { get; set; }

    /// <summary>
    /// Czy element jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return Drawing == null && base.IsEmpty();
    }

  }
}
