using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Lista źródeł bibliografii w dokumencie
  /// </summary>
  public class Sources: ItemIndex<Source>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Sources(): base() {}

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    public Sources (object owner): base(owner){}
    
    /// <summary>
    /// Dodanie elementu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (Source item)
    {
        if (!this.ContainsKey(item.Tag))
          this.Add(item.Tag, item);
    }

    /// <summary>
    /// Nazwa pliku ze stylem
    /// </summary>
    [DefaultValue(null)]
    public string XslFileName { get; set; }

    /// <summary>
    /// Nazwa stylu
    /// </summary>
    [DefaultValue(null)]
    public string StyleName { get; set; }

    /// <summary>
    /// Uri źródła
    /// </summary>
    [DefaultValue(null)]
    public string Uri { get; set; }
  }
}
