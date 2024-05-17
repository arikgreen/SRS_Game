using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IML = Iml.Documentation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista stylów indeksująca style po nazwie
  /// </summary>
  public partial class StyleList : ItemIndex<Style>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public StyleList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public StyleList (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie stylu do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (Style item)
    {
      Add(item.Id, item);
    }

    #region zachowanie dla stylów uśpionych
    /// <summary>
    /// Wartość domyślna dla <see cref="Style.IsPrimary"/>
    /// </summary>
    [DefaultValue(null)]
    public bool? DefaultIsPrimary { get; set; }

    /// <summary>
    /// Wartość domyślna dla <see cref="Style.IsLocked"/>
    /// </summary>
    [DefaultValue(null)]
    public bool? DefaultIsLocked { get; set; }

    /// <summary>
    /// Wartość domyślna dla <see cref="Style.DisplayPriority"/>
    /// </summary>
    [DefaultValue(null)]
    public int? DefaultDisplayPriority { get; set; }

    /// <summary>
    /// Wartość domyślna dla <see cref="Style.DisplayPriority"/>
    /// </summary>
    [DefaultValue(null)]
    public Hideable? DefaultIsHideable { get; set; }

    /// <summary>
    /// Liczba znanych stylów
    /// </summary>
    [DefaultValue(null)]
    public int? KnownStylesCount { get; set; }

    /// <summary>
    /// Identyfikator potrzebny tylko wtedy, gdy jest to lista stylów uśpionych
    /// </summary>
    [DefaultValue(null)]
    public string Id
    {
      get 
      { 
        if (fId!=null)
          return fId;
        if (KnownStylesCount!=null)
          return "0";
        return null;
      }
      set { fId = value;}
    }
    /// <summary>
    /// Pole przechowujące identyfikator własny listy
    /// </summary>
    protected string fId;
    #endregion
  }
}
