using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element listy wyboru
  /// </summary>
  public partial class Parameter : Item
  {
    /// <summary>
    /// Identyfikator nie jest pamiętany
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }
    /// <summary>
    /// Nazwa parametru
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Wartość parametru
    /// </summary>
    [DefaultValue(null)]
    public string Value { get; set; }
  }
}
