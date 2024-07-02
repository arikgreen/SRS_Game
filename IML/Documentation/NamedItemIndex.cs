using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Nazwana lista indeksowana
  /// </summary>
  /// <typeparam name="ItemType"></typeparam>
  public abstract partial class NamedItemIndex<ItemType>: ItemIndex<ItemType> where ItemType: Item
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public NamedItemIndex () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public NamedItemIndex (object owner) : base(owner) { }


    /// <summary>
    /// Identyfikator lokalny tworzony na podstawie nazwy
    /// </summary>
    public string Id
    {
      get
      {
        if (fId != null)
          return fId;
        if (Name != null)
          return Name.GetHashCode().ToString("X8");
        return null;
      }
      set
      {
        fId = value;
      }
    }
    /// <summary>
    /// Pole przechowujące identyfikator lokalny
    /// </summary>
    protected string fId;
    /// <summary>
    /// Nazwa własna indeksu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

  }
}
