using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Stereotyping
{
  /// <summary>
  /// Oznaczenie właściwości wymaganej
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
  public partial class RequiredAttribute : Attribute
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public RequiredAttribute()
    {
      IsRequired = true;
    }

    /// <summary>
    /// Konstruktor z wartością
    /// </summary>
    /// <param name="value"></param>
    public RequiredAttribute (bool value)
    {
      IsRequired = value;
    }

    /// <summary>
    /// Czy wartość jest wymagana
    /// </summary>
    public bool IsRequired { get; set; }
  }
}
