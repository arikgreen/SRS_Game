using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Object = Iml.Foundation.Object;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjny format - tekstowy albo akapitowy
  /// </summary>
  public abstract class Format: CompoundItem
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Format () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Format (object owner)
    {
      SetOwner(owner);
    }

    /// <summary>
    /// Możliwość zostawiona na przyszłość
    /// </summary>
    /// <param name="owner"></param>
    public void SetOwner(object owner)
    {
      // Nie zaimplementowane
    }

    /// <summary>
    /// Identyfikator formatu
    /// </summary>
    [DefaultValue(null)]
    public override String Id 
    { 
      get
      {
        if (fId == null && Collection!=null)
          return Type.GetHashCode().ToString();
        return fId;
      }
      set
      {
        fId = value;
      }
    }
    ///// <summary>
    ///// Pole przechowujące identyfikator formatu
    ///// </summary>
    //protected string fId;

    /// <summary>
    /// Typ formatu - czego on dotyczy
    /// </summary>
    public abstract FormatType Type { get; }

    /// <summary>
    /// Identyfikator rewizji
    /// </summary>
    [DefaultValue(null)]
    public string RevisionId { get; set; }

    /// <summary>
    /// Identyfikator stylu powiązanego
    /// </summary>
    [DefaultValue(null)]
    public string StyleId
    {
      get
      {
        return fStyleId ?? ((Style != null) ? Style.Id : null);
      }
      set
      {
        fStyleId = value;
      }
    }
    /// <summary>
    /// Pole przechowujące identyfikator stylu powiązanego
    /// </summary>
    protected string fStyleId;

    /// <summary>
    /// styl (z tabeli stylów)
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Style Style
    {
      get { return fStyle; }
      set
      {
        if (value != fStyle)
        {
          fStyle = value;
          fStyleId = null;
        }
      }
    }
    /// <summary>
    /// Pole przechowujące style powiązany z formatem
    /// </summary>
    protected Style fStyle;

    /// <summary>
    /// Czy format jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return
           fStyleId==null
        && fStyle==null
        && base.IsEmpty();
    }
  }
}
