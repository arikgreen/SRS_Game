using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Iml.Serialization
{
  public class ValueInfo
  {
    public PropertyInfo Property { get; set; }

    public bool IsRequired { get; set; }

    public bool EmitDefaultValue { get; set; }

    public ValueInfo(PropertyInfo aProperty)
    {
      Property = aProperty;
    }

    public void SetAttribute(Attribute aAttribute)
    {
      Type aType = aAttribute.GetType();
      if (aType == typeof(DataMemberAttribute))
        SetDataMemberAttribute((DataMemberAttribute)aAttribute);
    }

    public void SetDataMemberAttribute(DataMemberAttribute aAttribute)
    {
      IsRequired = aAttribute.IsRequired;
      EmitDefaultValue = aAttribute.EmitDefaultValue;
    }
  }

}
