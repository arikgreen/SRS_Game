using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Foundation
{
  /// <summary>
  /// Parametry geometrii kształtu
  /// </summary>
  public partial class NameValueList: ItemIndex<NameValuePair>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public NameValueList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public NameValueList (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie elementu do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (NameValuePair item)
    {
      Add(item.Name, item);
    }

    /// <summary>
    /// Dodawanie parametru bez wartości do indeksu
    /// </summary>
    /// <param name="key">nazwa parametru</param>
    public void Add (string key)
    {
      Add(key, new NameValuePair { Name = key });
    }
    /// <summary>
    /// Dodawanie parametru z wartością do indeksu
    /// </summary>
    /// <param name="key">nazwa parametru</param>
    /// <param name="value">wartość parametry</param>
    public void Add (string key, string value)
    {
      Add(key, new NameValuePair { Name = key, Value = value });
    }
  }
}
