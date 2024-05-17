using System;
namespace Iml.Modeling
{
  /// <summary>
  /// 
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public partial class MetaclassPropertyAttribute : Attribute
  {
    /// <summary>
    /// Kolejność na liście (liczba porządkowa)
    /// </summary>
    public string Order { get; set; }
  }
}
