using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Iml.Serialization
{
  //== ImlAttributeAttribute ======================================
  [AttributeUsageAttribute(AttributeTargets.Property |
                            AttributeTargets.Field |
                            AttributeTargets.Parameter |
                            AttributeTargets.ReturnValue,
                            AllowMultiple = false)]
  public class ImlAttributeAttribute : XmlAttributeAttribute
  {
    /// <summary>
    ///     Initializes a new instance of the ImlAttributeAttribute
    ///     class.
    /// </summary>
    public ImlAttributeAttribute(): base() { }

    /// <summary>
    ///     Initializes a new instance of the ImlAttributeAttribute
    ///     class and specifies the name of the generated XML attribute.
    /// </summary>
    /// <param name="attributeName">
    //     The name of the XML attribute that the ImlSerializer
    //     generates.
    /// </param>
    public ImlAttributeAttribute(string attributeName) : base(attributeName) { }

    /// <summary>
    ///   Initializes a new instance of the ImlAttributeAttribute
    ///   class.
    /// </summary>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlAttributeAttribute(Type type) : base(type) { }

    /// <summary>
    ///   Initializes a new instance of the ImlAttributeAttribute
    ///   class.
    /// </summary>
    /// <param name="attributeName">The name of the XML attribute that is generated.</param>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlAttributeAttribute(string attributeName, Type type) : base(attributeName, type) { }

    /// <summary>
    ///    Gets or sets the explicit order in which the elements are serialized or deserialized.
    /// </summary>
    public int Order { get; set; }
  }

  //== ImlDictionaryAttribute ======================================
  [AttributeUsageAttribute( AttributeTargets.Property | 
                            AttributeTargets.Field | 
                            AttributeTargets.Parameter | 
                            AttributeTargets.ReturnValue |
                            AttributeTargets.Class,
                            AllowMultiple = false)]
  public class ImlDictionaryAttribute: XmlArrayAttribute
  {
    /// <summary>
    ///    Initializes a new instance of the ImlDictionaryAttribute class.
    /// </summary>
    public ImlDictionaryAttribute() : base() { Order = 0; }

    /// <summary>
    // /   Initializes a new instance of the ImlDictionaryAttribute
    ///    class and specifies the name of the XML element.
    /// </summary>
    /// <param name="elementName">The XML element name of the serialized member.</param>
    public ImlDictionaryAttribute(string elementName) : base(elementName) { Order = 0; }
  }

  //== ImlDictionaryItemAttribute ======================================
  [AttributeUsageAttribute( AttributeTargets.Property | 
                            AttributeTargets.Field | 
                            AttributeTargets.Parameter | 
                            AttributeTargets.ReturnValue |
                            AttributeTargets.Class,
                            AllowMultiple = true)]
  public class ImlDictionaryItemAttribute : XmlArrayItemAttribute
  {
    /// <summary>
    ///    Initializes a new instance of the ImlDictionaryItemAttribute
    ///    class.
    /// </summary>
    public ImlDictionaryItemAttribute() : base() { }

    /// <summary>
    ///    Initializes a new instance of the ImlDictionaryItemAttribute
    ///    class and specifies the name of the XML element generated in the XML document.
    /// </summary>
    /// <param name="elementName">The name of the XML element.</param>
    public ImlDictionaryItemAttribute(string elementName) : base(elementName) { }

    /// <summary>
    ///    Initializes a new instance of the ImlDictionaryItemAttribute
    ///    class and specifies the System.Type that can be inserted into the serialized
    ///    array.
    /// </summary>
    /// <param name="type">The System.Type of the object to serialize.</param>
    public ImlDictionaryItemAttribute(Type type) : base(type) { }

    /// <summary>
    ///    Initializes a new instance of the ImlDictionaryItemAttribute
    ///    class and specifies the name of the XML element generated in the XML document
    ///    and the System.Type that can be inserted into the generated XML document.
    /// </summary>
    /// <param name="elementName">The name of the XML element.</param>
    /// <param name="type">The System.Type of the object to serialize.</param>
    public ImlDictionaryItemAttribute(string elementName, Type type) : base(elementName, type) { }
  }

  //== ImlDictionaryKeyAttribute ======================================
  [AttributeUsageAttribute(AttributeTargets.Property |
                            AttributeTargets.Field |
                            AttributeTargets.Parameter |
                            AttributeTargets.ReturnValue |
                            AttributeTargets.Class,
                            AllowMultiple = false)]
  public class ImlDictionaryKeyAttribute : Attribute
  {
    /// <summary>
    ///     Initializes a new instance of the ImlDictionaryKeyAttribute
    ///     class.
    /// </summary>
    public ImlDictionaryKeyAttribute(): base() { }

    /// <summary>
    ///     Initializes a new instance of the ImlDictionaryKeyAttribute
    ///     class and specifies the name of the generated XML attribute.
    /// </summary>
    /// <param name="attributeName">
    //     The name of the XML attribute that the ImlSerializer
    //     generates.
    /// </param>
    public ImlDictionaryKeyAttribute(string attributeName)
    {
      AttributeName = attributeName;
    }

    /// <summary>
    ///   Initializes a new instance of the ImlDictionaryKeyAttribute
    ///   class.
    /// </summary>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlDictionaryKeyAttribute(Type type)
    {
      Type = type;
    }

    /// <summary>
    ///   Initializes a new instance of the ImlDictionaryKeyAttribute
    ///   class.
    /// </summary>
    /// <param name="attributeName">The name of the XML attribute that is generated.</param>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlDictionaryKeyAttribute(string attributeName, Type type)
    {
      AttributeName = attributeName;
      Type = type;
    }

    /// <summary>
    ///    Gets or sets the name of the XML attribute.
    /// </summary>
    public string AttributeName { get; set; }

    /// <summary>
    ///   Gets or sets the XSD data type of the XML attribute generated by the System.Xml.Serialization.XmlSerializer.
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    ///     Gets or sets a value that indicates whether the XML attribute name generated
    ///     by the System.Xml.Serialization.XmlSerializer is qualified.
    /// </summary>
    public XmlSchemaForm Form { get; set; }

    /// <summary>
    ///     Gets or sets the XML namespace of the XML attribute.
    /// </summary>
    public string Namespace { get; set; }

    /// <summary>
    //     Gets or sets the complex type of the XML attribute.
    /// </summary>
    public Type Type { get; set; }
  }

  //== ImlDictionaryValueAttribute ======================================
  [AttributeUsageAttribute(AttributeTargets.Property |
                            AttributeTargets.Field |
                            AttributeTargets.Parameter |
                            AttributeTargets.ReturnValue |
                            AttributeTargets.Class,
                            AllowMultiple = false)]
  public class ImlDictionaryValueAttribute : Attribute
  {
    /// <summary>
    ///     Initializes a new instance of the ImlDictionaryValueAttribute
    ///     class.
    /// </summary>
    public ImlDictionaryValueAttribute() : base() { }

    /// <summary>
    ///     Initializes a new instance of the ImlDictionaryValueAttribute
    ///     class and specifies the name of the generated XML attribute.
    /// </summary>
    /// <param name="attributeName">
    //     The name of the XML attribute that the ImlSerializer
    //     generates.
    /// </param>
    public ImlDictionaryValueAttribute(string attributeName)
    {
      AttributeName = attributeName;
    }

    /// <summary>
    ///   Initializes a new instance of the ImlDictionaryValueAttribute
    ///   class.
    /// </summary>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlDictionaryValueAttribute(Type type)
    {
      Type = type;
    }

    /// <summary>
    ///   Initializes a new instance of the ImlDictionaryValueAttribute
    ///   class.
    /// </summary>
    /// <param name="attributeName">The name of the XML attribute that is generated.</param>
    /// <param name="type">The System.Type used to store the attribute.</param>
    public ImlDictionaryValueAttribute(string attributeName, Type type)
    {
      AttributeName = attributeName;
      Type = type;
    }

    /// <summary>
    ///    Gets or sets the name of the XML attribute.
    /// </summary>
    public string AttributeName { get; set; }

    /// <summary>
    ///   Gets or sets the XSD data type of the XML attribute generated by the System.Xml.Serialization.XmlSerializer.
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    ///     Gets or sets a value that indicates whether the XML attribute name generated
    ///     by the System.Xml.Serialization.XmlSerializer is qualified.
    /// </summary>
    public XmlSchemaForm Form { get; set; }

    /// <summary>
    ///     Gets or sets the XML namespace of the XML attribute.
    /// </summary>
    public string Namespace { get; set; }

    /// <summary>
    ///    Gets or sets the complex type of the XML attribute.
    /// </summary>
    public Type Type { get; set; }
  }

  //== ImlIgnoreImplicit ======================================
  [AttributeUsageAttribute(AttributeTargets.Property |
                            AttributeTargets.Field |
                            AttributeTargets.Parameter |
                            AttributeTargets.ReturnValue,
                            AllowMultiple = false)]
  public class ImlIgnoreImplicitAttribute : Attribute
  {
    /// <summary>
    ///     Initializes a new instance of the ImlIgnoreImplicitAttribute
    ///     class.
    /// </summary>
    public ImlIgnoreImplicitAttribute() { Value = true; }

    /// <summary>
    ///     Initializes a new instance of the ImlIgnoreImplicitAttribute
    ///     class and specifies the value of this attribute.
    /// </summary>
    /// <param name="value">
    ///     Specifies if implicit properties are ignored by the ImlSerializer.Serialize
    /// </param>
    public ImlIgnoreImplicitAttribute(bool value)
    {
      Value = value;
    }

    /// <summary>
    ///    Gets or sets the value of this attribute.
    /// </summary>
    public bool Value { get; set; }
  }

}
