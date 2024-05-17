using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Runtime;
using System.IO;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;
using System.ComponentModel.Design.Serialization;

namespace Iml.Serialization
{
  public class WriteOptions
  {
    public bool UseNamespaces = true;
    public bool WhitespacePreserve = true;
    public bool Indent = true;
    public bool OmitXmlDeclaration = true;
    public System.Text.Encoding Encoding;

    public WriteOptions()
    {
      Encoding = System.Text.Encoding.UTF8;
    }
  }

  public class ReadOptions
  {
    public bool UseNamespaces = true;
    public bool WhitespacePreserve = true;
  }

  /// <summary>
  ///  Własny serializer. Zastępuje XmlSerializer. Zgodny z XamlReader i XamlWriter.
  /// </summary>
  public class ImlSerializer : XmlObjectSerializer
  {

    private Type RootType;
    private bool IsRootElement = true;

    public TypeReflection KnownTypes = new TypeReflection();
    public ImlNamespaceManager NamespaceManager { get { return KnownTypes.NamespaceManager; } }
    public WriteOptions WriteOptions = new WriteOptions();
    public ReadOptions ReadOptions = new ReadOptions();
    public Assembly RootAssembly;

    private class DefaultValueInfo
    {
      public string PropertyName;
      public object PropertyValue;
    }

    private class ObjectValue
    {
      public object Value;
      public List<DefaultValueInfo> DefaultValues;
      public void SetDefaultValues(List<DefaultValueInfo> aList)
      {
        if (aList != null)
          DefaultValues = new List<DefaultValueInfo>(aList.ToArray());
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Konstruktor podstawowy. Dodaje podstawowe przestrzenie nazw: XAML i XmlSchema Instance
    /// </summary>
    public ImlSerializer()
      : base()
    {
      NamespaceManager.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");
      NamespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
    }


    #region Metody publiczne - wywołanie serializacji i deserializacji

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Serializuje podany obiekt zapisując dokument XML do strumienia.   
    /// </summary>
    /// <param name="stream">Strumień do zapisu dokumentu XML</param>
    /// <param name="o">Obiekt do serializacji</param>
    public void Serialize(Stream stream, Object obj)
    {
      IsRootElement = true;
      RootType = obj.GetType();
      TypeInfo aTypeInfo = KnownTypes.Reflect(RootType);
      XmlWriter aWriter = XmlWriter.Create(stream,
        new XmlWriterSettings
        {
          Indent = WriteOptions.Indent,
          Encoding = WriteOptions.Encoding,
          OmitXmlDeclaration = WriteOptions.OmitXmlDeclaration
        });
      WriteObject(aWriter, obj);
      stream.Flush();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Serializuje podany obiekt zapisując dokument XML przez TextWriter.   
    /// </summary>
    /// <param name="writer">Obiekt TextWriter do zapisu dokumentu XML</param>
    /// <param name="obj">Obiekt do serializacji</param>
    public void Serialize(TextWriter writer, Object obj)
    {
      IsRootElement = true;
      XmlWriter aWriter = XmlWriter.Create(writer,
        new XmlWriterSettings
        {
          Indent = WriteOptions.Indent,
          Encoding = WriteOptions.Encoding,
          OmitXmlDeclaration = WriteOptions.OmitXmlDeclaration
        });
      WriteObject(aWriter, obj);
      aWriter.Flush();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Serializuje podany obiekt zapisując dokument XML przez XmlWriter.   
    /// </summary>
    /// <param name="writer">Obiekt XmlWriter do zapisu dokumentu XML</param>
    /// <param name="obj">Obiekt do serializacji</param>
    public void Serialize(XmlWriter writer, Object obj)
    {
      IsRootElement = true;
      WriteObject(writer, obj);
      writer.Flush();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///    Deserializuje obiekt z dokumentu XML czytanego ze strumienia.
    /// </summary>
    /// <param name="stream">Strumień do czytania dokumentu XML</param>
    /// <returns>Zdeserializowany obiekt</returns>
    public object Deserialize(Stream stream)
    {
      IsRootElement = true;
      if (RootAssembly == null)
        RootAssembly = Assembly.GetCallingAssembly();
      return ReadObject(stream);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///    Deserializuje obiekt z dokumentu XML czytanego z TextReadera.
    /// </summary>
    /// <param name="textReader">Obiekt TextReader do czytania dokumentu XML</param>
    /// <returns>Zdeserializowany obiekt</returns>
    public object Deserialize(TextReader textReader)
    {
      XmlReader aReader = new XmlTextReader(textReader);
      IsRootElement = true;
      if (RootAssembly == null)
        RootAssembly = Assembly.GetCallingAssembly();
      return ReadObject(aReader);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///    Deserializuje obiekt z dokumentu XML czytanego z XmlReadera.
    /// </summary>
    /// <param name="textReader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <returns>Zdeserializowany obiekt</returns>
    public object Deserialize(XmlReader xmlReader)
    {
      IsRootElement = true;
      if (RootAssembly == null)
        RootAssembly = Assembly.GetCallingAssembly();
      return ReadObject(xmlReader);
    }

    #endregion

    #region Metody odczytu

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Ta funkcja sprawdza, czy pozycja do czytania jest na początku głównego elementu 
    ///   dokumentu XML. W tej klasie nie zaimplementowano metody tej funkcji, ale jej deklaracja
    ///   musi nadpisać abstrakcyjną metodę z klasy XmlObjectSerializer.
    /// </summary>
    /// <param name="reader">Obiekt XmlDictionaryReader do odczytu dokumentu XML</param>
    public override bool IsStartObject(XmlDictionaryReader reader)
    {
      throw new NotImplementedException();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Odczytuje dokument XML przez XmlDictionaryReader i zwraca obiekt zdeserializowany.
    ///   Ta metoda nadpisuje metodę dziedziczoną z klasy XmlObjectSerializer.
    /// </summary>
    /// <param name="reader">Obiekt XmlDictionaryReader do odczytu dokumentu XML</param>
    /// <param name="verifyObjectName">
    ///   Nie interpretowany parametr. W klasie XmlObjectSerializer używany do sprawdzenia,
    ///   czy dokument XML zawiera obiekt klasy zgodnej z klasą główną podaną przy tworzeniu
    ///   serializera.  W klasie ImlSerializer zrezygnowano z podawania klasy głównej. 
    ///   W zamian można po utworzeniu instancji serializera dodać przestrzenie nazw
    ///   albo wczytać przestrzenie nazw z głównego elementu dokumentu XML (jak w XAML).
    /// </param>
    /// <returns>Odczytany obiekt</returns>
    public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
    {
      // Wczytywany dokument XML może zawierać nagłówek. To jest właściwe miejsce do przeczytania nagłówka.
      TryReadXmlHeading(reader);

      // Pole IsRootElement jest ustawione, gdy wejście następuje przez którąś z metod Deserialize.
      if (IsRootElement)
      {
        // Główny element może zawierać deklaracje przestrzeni nazw, które tu są czytane.
        TryReadXmlns(reader);
        IsRootElement = false;
      }

      // Przechodzi do właściwego czytania obiektu.
      return ReadObjectElement(reader);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///    Pomija deklaracje XML na początku dokumentu XML.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    private void TryReadXmlHeading(XmlReader reader)
    {
      if (reader.ReadState == ReadState.Initial && reader.ReadState != ReadState.EndOfFile)
      {
        reader.Read();
        if (reader.NodeType == XmlNodeType.XmlDeclaration)
        {
          reader.Read();
          while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();
        }
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytuje deklaracje przestrzeni nazw z atrybutów xmlns umieszczonych wewnątrz elementu XML.
    ///   Deklaracje są przekazywane do menedżera znanych typów i będą służyły do wyszukiwania typów.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    private void TryReadXmlns(XmlReader reader)
    {
      if (reader.MoveToFirstAttribute())
      {
        do
        {
          string aName = reader.Name;
          if (aName == "xmlns" || aName.StartsWith("xmlns:"))
          {
            string aValue = reader.Value;
            SetXmlnsAttribute(aName, aValue);
          }
        } while (reader.MoveToNextAttribute());
        reader.MoveToElement();
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Odczytanie obiektu z elementu XML.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <returns>Odczytany obiekt</returns>
    public object ReadObjectElement(XmlReader reader)
    {
      // Nazwa elementu XML zawiera nazwę klasy, a prefiks nazwy XML odwołuje się do przestrzeni nazw
      string elementPrefix = reader.Prefix;
      string elementName = reader.LocalName;

      // Pobrany opis typu z listy znanych typów. 
      TypeInfo aTypeInfo = null;
      if (!KnownTypes.TryGetValue(elementPrefix, elementName, out aTypeInfo))
        throw new SerializationException(String.Format("Unrecognized '{0}' element", elementName));

      // obiekt musi być utworzony, a więc najpierw z opisu typu jest pobierany domyślny konstruktor
      ConstructorInfo aConstructor = aTypeInfo.Type.GetConstructor(new Type[] { });
      if (aConstructor == null)
        throw new SerializationException(String.Format("Parameterless constructor for '{0}' type not found", aTypeInfo.Type.FullName));
      object result = aConstructor.Invoke(null);

      // wczytanie zawartości utworzonego już obiektu
      //if (!reader.IsEmptyElement)
      ReadObjectContent(reader, result, aTypeInfo);

      return result;
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie zawartości obiektu z elementu XML
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Obiekt, którego zawartość trzeba wczytać</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    private void ReadObjectContent(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      // nazwa elementu XML posłuży do rozpoznania właściwości obiektu 
      string oName = reader.Name;

      ReadObjectAttributes(reader, obj, objTypeInfo);

      reader.MoveToElement();
      if (reader.IsEmptyElement)
      {
        reader.Read();
        reader.MoveToContent();
      }
      else
      {
        // a teraz wczytanie elementów XML i napisów tekstowych
        if (reader.NodeType == XmlNodeType.Text)
        {
          this.ReadTextValue(reader, obj, objTypeInfo);
        }
        else
        {
          reader.ReadStartElement();
          reader.MoveToContent();
          ReadElementContent(reader, obj, objTypeInfo, oName);
          reader.ReadEndElement();
          reader.MoveToContent();
        }
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie zawartości elementu XML do danego obiektu.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Obiekt, którego zawartość trzeba wczytać</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    /// <param name="oName">Nazwa nadrzędnego elementu Xml (może być pusta)</param>
    private void ReadElementContent(XmlReader reader, object obj, TypeInfo objTypeInfo, string oName = null)
    {
      while (reader.IsStartElement() || reader.NodeType == XmlNodeType.Text)
      {
        string eName = reader.Name;
        // nazwa elementu Xml może być nazwą złożoną
        // wówczas oznacza właściwość danego obiektu
        if (eName.StartsWith(oName + "."))
        {
          string propName = eName.Substring(oName.Length + 1);
          TryReadPropertyElement(reader, obj, objTypeInfo, propName);
        }
        else
        {
          string propName = eName;
          if (!String.IsNullOrEmpty(propName))
          {
            int n = oName.IndexOf(':');
            if (n > 0 && propName.Substring(0, n) == oName.Substring(0, n))
              propName = propName.Substring(n + 1);
          }
          if (!TryReadPropertyElement(reader, obj, objTypeInfo, propName))
          {
            // jeśli obiekt jest kolekcją, to zawiera wprost elementy kolekcji
            if (objTypeInfo.IsList)
              ReadItemElement(reader, obj, objTypeInfo);
            else
              // wreszcie w każdym innym przypadku trzeba dopiero rozpoznać, 
              // co to jest za element
              ReadChildElement(reader, obj, objTypeInfo);
          }
        }
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie właściwości obiektu z atrybutów XML
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Obiekt, którego zawartość trzeba wczytać</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    private void ReadObjectAttributes(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      // Przeglądanie atrybutów XML
      for (int i = 0; i < reader.AttributeCount; i++)
      {
        reader.MoveToAttribute(i);
        string prefix = reader.Prefix;
        string aName = reader.Name;
        string aValue = reader.Value;

        // pusty tekst atrybutu oznacza wartość null dla właściwości
        if (aValue == "")
          aValue = null;

        if (prefix == "xml") // to może być atrybut xml:space
          SetXmlAttribute(reader.LocalName, aValue);
        else
          // Deklaracje przestrzeni nazw zazwyczaj występują w głównym elemencie XML
          // ale mogą też wystąpić w zagłębionym elemencie. 
          if (aName == "xmlns" || aName.StartsWith("xmlns:"))
            SetXmlnsAttribute(aName, aValue);
          else
          {
            // dopiero teraz rozpoznanie atrybutu, który oznacza właściwość obiektu
            aName = reader.Name;
            SetAttributeValue(obj, objTypeInfo, aName, aValue);
          }
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie wartości tekstowej
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Obiekt, którego zawartość trzeba wczytać</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    private void ReadTextValue(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      string aValue = reader.Value;

      // pusty tekst oznacza wartość null dla właściwości
      if (aValue == "")
        aValue = null;
      ImlItemInfo aValueInfo = objTypeInfo.ValueInfo;
      if (aValueInfo == null)
        throw new SerializationException(string.Format("Value property in {0} class not found", obj.GetType().Name));

      // wartość może się odwoływać do właściwości "zwykłej"
      if (aValueInfo.Property != null)
      {
        MethodInfo aSetMethod = aValueInfo.Property.GetSetMethod(true);
        if (aSetMethod == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has no set method",
            aValueInfo.Property.Name, obj.GetType().Name));
        object value = ConvertStringToValue(aValue, aValueInfo.Property.PropertyType);
        aSetMethod.Invoke(obj, new object[] { value });
      }
      // albo do właściwości zależnej
      else if (aValueInfo.DependencyProperty != null)
      {
        //PropertyMetadata aMetadata = aAttributeInfo.DependencyProperty.DefaultMetadata;
        DependencyObject dpo = obj as DependencyObject;
        if (dpo == null)
          throw new SerializationException(String.Format("DependencyProperty '{0}' defined in class '{1}' which is not DependencyObject",
            aValueInfo.DependencyProperty.Name, obj.GetType().Name));
        object value = ConvertStringToValue(aValue, aValueInfo.DependencyProperty.PropertyType);
        dpo.SetValue(aValueInfo.DependencyProperty, value);
      }
      reader.Read();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Próba wczytania elementu reprezentującego podaną właściwość danego obiektu
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="propName">Nazwa właściwości</param>
    /// <returns>czy zostało wczytane</returns>
    private bool TryReadPropertyElement(XmlReader reader, object obj, TypeInfo objTypeInfo, string propName)
    {
      ImlItemInfo aElementInfo = FindElementNameInfo(objTypeInfo, propName);

      // jeśli nazwa elementu została znaleziona
      if (aElementInfo != null)
      {
        // to może się on odwoływać do właściwości "zwykłej"
        if (aElementInfo.Property != null)
        {
          ReadPropertyElement(reader, obj, objTypeInfo, aElementInfo.Property);
          return true;
        }
        // albo do właściwości zależnej
        else if (aElementInfo.DependencyProperty != null)
        {
          ReadPropertyElement(reader, obj, objTypeInfo, aElementInfo.DependencyProperty);
          return true;
        }
      }
      return false;
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu reprezentującego podaną właściwość danego obiektu
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="propInfo">Opis właściwości</param>
    private void ReadPropertyElement(XmlReader reader, object obj, TypeInfo objTypeInfo, PropertyInfo propInfo)
    {
      if (IsConstructable(propInfo.PropertyType) || TypeReflection.IsSimpleType(propInfo.PropertyType))
      {
        MethodInfo aSetMethod = propInfo.GetSetMethod(true);
        if (aSetMethod == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has no set method",
            propInfo.Name, obj.GetType().Name));
        object value = ReadPropertyValue(reader, obj, objTypeInfo, propInfo.PropertyType);
        aSetMethod.Invoke(obj, new object[] { value });
      }
      else
      {
        MethodInfo aGetMethod = propInfo.GetGetMethod(true);
        if (aGetMethod == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has no get method",
            propInfo.Name, obj.GetType().Name));
        object value = aGetMethod.Invoke(obj, new object[] { });
        if (value == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has null value",
            propInfo.Name, obj.GetType().Name));
        TypeInfo propTypeInfo = KnownTypes.Reflect(value.GetType());
        if (propTypeInfo == null)
          throw new SerializationException(String.Format("Unknown class '{0}'",
            propInfo.PropertyType.Name));
        if (propInfo == objTypeInfo.ContentProperty)
          ReadElementContent(reader, value, propTypeInfo);
        else
          ReadObjectContent(reader, value, propTypeInfo);
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu reprezentującego podaną właściwość danego obiektu
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="deProp">deklarator właściwości zależnej</param>
    private void ReadPropertyElement(XmlReader reader, object obj, TypeInfo objTypeInfo, DependencyProperty deProp)
    {
      // PropertyMetadata aMetadata = aElementInfo.DependencyProperty.DefaultMetadata;
      DependencyObject dpo = obj as DependencyObject;
      if (dpo == null)
        throw new SerializationException(String.Format("DependencyProperty '{0}' defined in class '{1}' which is not DependencyObject",
          deProp.Name, obj.GetType().Name));
      if (IsConstructable(deProp.PropertyType))
      {
        object value = ReadPropertyValue(reader, obj, objTypeInfo, deProp.PropertyType);
        dpo.SetValue(deProp, value);
      }
      else
      {
        object value = dpo.GetValue(deProp);
        ReadPropertyValue(reader, obj, objTypeInfo, deProp.PropertyType);
        if (value == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has null value",
            deProp.Name, obj.GetType().Name));
        TypeInfo propTypeInfo = KnownTypes.Reflect(value.GetType());
        if (propTypeInfo == null)
          throw new SerializationException(String.Format("Unknown class '{0}'",
            deProp.PropertyType.Name));
        ReadObjectContent(reader, value, propTypeInfo);
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie nowo tworzonej wartości właściwości dla danego obiektu.
    ///   Ta metoda rozróżnia, czy jest to prosty typ właściwości i wtedy woła
    ///   ReadSimplePropertyValue, czy nie i wtedy woła ReadObjectPropertyValue.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="propType">Typ właściwości</param>
    /// <returns>instancja właściwości</returns>
    private object ReadPropertyValue(XmlReader reader, object obj, TypeInfo objType, Type propType)
    {
      if (TypeReflection.IsSimpleType(propType))
        return ReadSimplePropertyValue(reader, obj, objType, propType);
      else
        return ReadObjectPropertyValue(reader, obj, objType, propType);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie nowo tworzonej wartości właściwości prostej dla danego obiektu.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="propType">Typ właściwości</param>
    /// <returns>instancja właściwości</returns>
    private object ReadSimplePropertyValue(XmlReader reader, object obj, TypeInfo objType, Type propType)
    {
      string aValue = reader.Value;
      object value = ConvertStringToValue(aValue, propType);
      reader.Read();
      reader.MoveToContent();
      return value;
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie nowo tworzonej wartości właściwości obiektowej dla danego obiektu.
    ///   Klasa obiektu musi mieć konstruktor bezparametrowy.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="propType">Typ właściwości</param>
    /// <returns>instancja właściwości</returns>
    private object ReadObjectPropertyValue(XmlReader reader, object obj, TypeInfo objType, Type propType)
    {
      ConstructorInfo aConstructor = propType.GetConstructor(new Type[] { });
      if (aConstructor == null)
        throw new SerializationException(String.Format("Parameterless constructor for '{0}' type not found", propType.FullName));
      object value = aConstructor.Invoke(new object[] { });
      TypeInfo valueTypeInfo = KnownTypes.Reflect(propType);
      ReadObjectContent(reader, value, valueTypeInfo);
      return value;
    }

    private void ReadChildElement(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      if (objTypeInfo.ContentProperty != null)
      {
        ReadPropertyElement(reader, obj, objTypeInfo, objTypeInfo.ContentProperty);
      }
      else
      {
        ReadObjectContent(reader, obj, objTypeInfo);
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu innego obiektu. Rozpoznaje, czy obiekt jest słownikiem (Dictionary)
    ///   i wówczas wywołuje ReadDictionaryItem. Jeśli nie, to wywołuje ReadDictionaryItem.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt kontenerowy</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    private void ReadItemElement(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      if (objTypeInfo.IsDictionary)
        ReadDictionaryItem(reader, obj, objTypeInfo);
      else
        ReadCollectionItem(reader, obj, objTypeInfo);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu słownika (Dictionary)
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt słownika</param>
    /// <param name="objType">Opis typu danego obiektu</param>
    private void ReadDictionaryItem(XmlReader reader, object obj, TypeInfo objType)
    {
      object key = null;
      object value = null;
      bool isDictionary = objType.IsDictionary;
      bool isValueType = false;
      string elementName = reader.Name;
      TypeInfo keyTypeInfo = objType.KeyType;
      if (isDictionary)
      {
        if (keyTypeInfo == null)
        {
          KnownTypes.TryGetValue("String", out keyTypeInfo);
        }
        if (keyTypeInfo == null)
          throw new SerializationException(String.Format("Unknown key type for '{0}'", objType.ElementName));
      }
      TypeInfo expectedTypeInfo = objType.ItemType;
      TypeInfo currentTypeInfo;
      KnownTypes.TryGetValue(elementName, out currentTypeInfo);

      if (expectedTypeInfo == null && currentTypeInfo == null)
        throw new SerializationException(String.Format("Unknown item type for class '{0}'", objType.Type.Name));
      ConstructorInfo aConstructor = null;
      if (currentTypeInfo != null)
      {
        aConstructor = currentTypeInfo.Type.GetConstructor(new Type[] { });
        isValueType = TypeReflection.IsValueType(currentTypeInfo);
        if (aConstructor == null && !isValueType)
        {
          throw new SerializationException(String.Format("Parameterless constructor for '{0}' type not found element", currentTypeInfo.Type.FullName));
        }
      }
      else
      {
        if (!String.IsNullOrEmpty(elementName))
          throw new SerializationException(String.Format("Unknown item type '{0}'", elementName));
        if (expectedTypeInfo != null)
        {
        }
      }
      if (isDictionary)
      {
        string aKeyName = "key";
        if (objType.KeyAttribute != null && !String.IsNullOrEmpty(objType.KeyAttribute.ImlName))
          aKeyName = objType.KeyAttribute.ImlName;
        if (reader.MoveToAttribute(aKeyName))
        {
          string aValue = reader.Value;
          if (aValue == "")
            aValue = null;
          key = ConvertStringToValue(aValue, keyTypeInfo.Type);
        }
        else
          throw new InvalidOperationException(String.Format("\"{0}\" attribute not found", aKeyName));
      }
      if (aConstructor != null)
      {
        value = aConstructor.Invoke(null);
        ReadObjectContent(reader, value, currentTypeInfo);
      }
      else if (TypeReflection.IsValueType(currentTypeInfo))
      {
        string aValueName = "value";
        if (objType.ValueAttribute != null && !String.IsNullOrEmpty(objType.ValueAttribute.ImlName))
          aValueName = objType.ValueAttribute.ImlName;
        if (reader.MoveToAttribute(aValueName))
        {
          string aValue = reader.Value;
          if (aValue == "")
            aValue = null;
          value = ConvertStringToValue(aValue, currentTypeInfo.Type);
        }
        else
          throw new InvalidOperationException(String.Format("\"{0}\" attribute not found", aValueName));
        reader.MoveToElement();
        if (reader.IsEmptyElement)
        {
          reader.Read();
          reader.MoveToContent();
        }
        else
        {
          reader.ReadStartElement();
          reader.MoveToContent();
          reader.ReadEndElement();
          reader.MoveToContent();
        }
      }
      if (isDictionary)
        (obj as IDictionary).Add(key, value);
      else
      {
        IList aList = obj as IList;
        if (aList != null)
          aList.Add(value);
        else
        {
          Type[] interfaces = obj.GetType().GetInterfaces();
          foreach (Type aType in interfaces)
          {
            if (aType.Name.StartsWith("IList") && aType.FullName.Contains(value.GetType().Name))
            {
              MethodInfo addMethod = obj.GetType().GetMethod("Add", new Type[] { value.GetType() });
              if (addMethod == null)
                addMethod = obj.GetType().GetMethod("Add");
              if (addMethod != null)
              {
                addMethod.Invoke(obj, new object[] { value });
                return;
              }
            }
          }
        }
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu kolekcji
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt kolekcji</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    private void ReadCollectionItem(XmlReader reader, object obj, TypeInfo objTypeInfo)
    {
      string elementName = reader.Name;

      // sprawdzenie typu elementu: typu oczekiwanego i typu odczytanego z dokumentu XML
      TypeInfo expectedTypeInfo = objTypeInfo.ItemType;
      TypeInfo currentTypeInfo;
      KnownTypes.TryGetValue(elementName, out currentTypeInfo);
      if (expectedTypeInfo == null && currentTypeInfo == null)
        throw new SerializationException(String.Format("Unknown item type for class '{0}'", objTypeInfo.Type.Name));

      if (currentTypeInfo != null)
        ReadCurrentTypeItem(reader, obj, objTypeInfo, currentTypeInfo);
      else
        ReadExpectedTypeItem(reader, obj, objTypeInfo, expectedTypeInfo);
    }
    /*
          {
          }
          else
          {
            if (!String.IsNullOrEmpty(elementName))
              throw new SerializationException(String.Format("Unknown item type '{0}'", elementName));
            if (expectedTypeInfo != null)
            {
            }
          }
          if (aConstructor != null)
          {
          }
          else if (TypeReflection.IsValueType(currentTypeInfo))
          {
            string aValueName = "value";
            if (objType.ValueAttribute != null && !String.IsNullOrEmpty(objType.ValueAttribute.ImlName))
              aValueName = objType.ValueAttribute.ImlName;
            if (reader.MoveToAttribute(aValueName))
            {
              string aValue = reader.Value;
              if (aValue == "")
                aValue = null;
              value = ConvertStringToValue(aValue, currentTypeInfo.Type);
            }
            else
              throw new InvalidOperationException(String.Format("\"{0}\" attribute not found", aValueName));
            reader.MoveToElement();
            if (reader.IsEmptyElement)
            {
              reader.Read();
              reader.MoveToContent();
            }
            else
            {
              reader.ReadStartElement();
              reader.MoveToContent();
              reader.ReadEndElement();
              reader.MoveToContent();
            }
          }
          if (isDictionary)
            (obj as IDictionary).Add(key, value);
          else
          {
            IList aList = obj as IList;
            if (aList != null)
              aList.Add(value);
            else
            {
              Type[] interfaces = obj.GetType().GetInterfaces();
              foreach (Type aType in interfaces)
              {
                if (aType.Name.StartsWith("IList") && aType.FullName.Contains(value.GetType().Name))
                {
                  MethodInfo addMethod = obj.GetType().GetMethod("Add", new Type[] { value.GetType() });
                  if (addMethod == null)
                    addMethod = obj.GetType().GetMethod("Add");
                  if (addMethod != null)
                  {
                    addMethod.Invoke(obj, new object[] { value });
                    return;
                  }
                }
              }
            }
          }
        }
    */

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu kolekcji jeśli rozpoznany jest typ elementu.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt kolekcji</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="itemTypeInfo">Opis rozpoznanego typu elementu</param>
    private void ReadCurrentTypeItem(XmlReader reader, object obj, TypeInfo objTypeInfo, TypeInfo itemTypeInfo)
    {
      ConstructorInfo aConstructor = itemTypeInfo.Type.GetConstructor(new Type[] { });
      if (aConstructor != null)
      {
        object value = aConstructor.Invoke(null);
        ReadObjectContent(reader, value, itemTypeInfo);
        (obj as IList).Add(value);
      }
      else
      {
        bool isValueType = TypeReflection.IsValueType(itemTypeInfo);
        if (!isValueType)
          throw new SerializationException(String.Format("Parameterless constructor for '{0}' type not found element", itemTypeInfo.Type.FullName));
        throw new SerializationException("Unimplemented method");
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wczytanie elementu kolekcji jeśli nierozpoznany jest typ elementu.
    /// </summary>
    /// <param name="reader">Obiekt XmlReader do czytania dokumentu XML</param>
    /// <param name="obj">Dany obiekt kolekcji</param>
    /// <param name="objTypeInfo">Opis typu danego obiektu</param>
    /// <param name="itemTypeInfo">Opis oczekiwanego typu elementu</param>
    private void ReadExpectedTypeItem(XmlReader reader, object obj, TypeInfo objTypeInfo, TypeInfo itemTypeInfo)
    {
      if (itemTypeInfo.ConverterTypeName != null)
      {
        TypeConverter aConverter = null;
        if (KnownTypes.Converters.TryGetValue(itemTypeInfo.Type.Name, out aConverter))
        {
          if (aConverter.CanConvertFrom(typeof(string)))
          {
            string value = reader.Value;
            object item = aConverter.ConvertFrom(value);
            IList collection = obj as IList;
            if (collection == null)
              throw new SerializationException(String.Format("Class '{0}' does not implement IList", obj.GetType().Name));
            collection.Add(item);
            reader.Read();
            reader.MoveToContent();
            return;
          }
        }
      }
      if (!itemTypeInfo.Type.IsAbstract)
      {
        ConstructorInfo aConstructor = itemTypeInfo.Type.GetConstructor(new Type[] { });
        if (aConstructor == null)
          throw new SerializationException(String.Format("Parameterless constructor for '{0}' type not found element", itemTypeInfo.Type.Name));
        throw new SerializationException("Unimplemented method");
      }
      else
        throw new SerializationException(String.Format("Abstract item type '{0}'", itemTypeInfo.Type.Name));
    }

    #endregion

    #region Metody zapisu
    public override void WriteStartObject(XmlDictionaryWriter writer, object obj)
    {
      Type aType = obj.GetType();
      TypeInfo aTypeInfo = KnownTypes.Reflect(aType);
      if (aTypeInfo != null)
      {
        bool done = false;
        if (aTypeInfo.HasAliases)
        {
          string alias = KnownTypes.GetObjectAlias(aTypeInfo.Type, obj);
          if (alias != null)
          {
            writer.WriteStartElement(alias);
            done = true;
          }
        }
        string prefix = null;
        if (!done)
        {
          prefix = aTypeInfo.ElementPrefix ?? "";
          writer.WriteStartElement(prefix, aTypeInfo.ElementName, NamespaceManager.LookupNamespace(prefix));
        }
        if (IsRootElement)
        {
          //IsRootElement = false;
          //if (WriteOptions.UseNamespaces)
          //  foreach (XmlNamespaceMapping nm in NamespaceManager)
          //  {
          //    if (nm.Prefix!=prefix)
          //       writer.WriteXmlnsAttribute(nm.Prefix, nm.Uri.ToString());
          //  }
          //if (WriteOptions.WhitespacePreserve)
          //  writer.WriteXmlAttribute("space", "preserve");
        }
      }
      else
        writer.WriteStartElement(obj.GetType().Name);
    }

    public override void WriteEndObject(XmlDictionaryWriter writer)
    {
      writer.WriteEndElement();
    }

    //int n = 0;
    public override void WriteObjectContent(XmlDictionaryWriter writer, object obj)
    {
      //if (n++ > 300)
      //  return;
      ObjectValue objValue = obj as ObjectValue;
      if (objValue == null)
        objValue = new ObjectValue { Value = obj };
      obj = objValue.Value;
      Type aType = obj.GetType();
      if (obj == null)
      {
        writer.WriteAttributeString("nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
      }
      else
      {
        TypeInfo aTypeInfo = KnownTypes.Reflect(aType);
        bool ok = false;
        if (aTypeInfo != null)
        {
          if (aTypeInfo.Attributes != null)
          {
            WriteImlAttributes(writer, objValue, aTypeInfo);
            ok = true;
          }
          if (aTypeInfo.Elements != null)
          {
            WriteImlElements(writer, objValue, aTypeInfo);
            ok = true;
          }
          if (aTypeInfo.IsDictionary)
          {
            WriteImlDictionary(writer, objValue, aTypeInfo);
            ok = true;
          }
          else if (aTypeInfo.IsList)
          {
            WriteImlList(writer, objValue, aTypeInfo);
            ok = true;
          }
          if (aTypeInfo.ContentProperty != null)
          {
            WriteContentProperty(writer, objValue, aTypeInfo.ContentProperty);
            ok = true;
          }
          if (aTypeInfo.ValueInfo != null)
          {
            WriteValueProperty(writer, obj, aTypeInfo.ValueInfo);
            ok = true;
          }
        }
        if (!ok)
        {
          string s = ConvertValueToString(obj, obj.GetType());
          s = EncodeEntities(s);
          writer.WriteRaw(s);
        }
      }
    }

    private bool IsDefaultValue(object value, ImlItemInfo aImlInfo, ref List<DefaultValueInfo> dvis)
    {

      bool ok = false;
      if (aImlInfo.EmitDefaultValue)
        return false;
      else if (value == null)
        return true;
      if (dvis != null)
      {
        DefaultValueInfo dvi =
          (from item in dvis
           where item.PropertyName == aImlInfo.Property.Name && DeepEquals(value, item.PropertyValue)
           select item).FirstOrDefault();
        if (dvi != null)
          return true;
      }
      if (aImlInfo.DefaultValue != null)
      {
        ok = DeepEquals(aImlInfo.DefaultValue, value);
        if (ok)
        {
          if (aImlInfo.SpanDefaultValue)
          {
            if (dvis == null)
              dvis = new List<DefaultValueInfo>();
            DefaultValueInfo dvi = new DefaultValueInfo { PropertyName = aImlInfo.Property.Name, PropertyValue = value };
            dvis.Add(dvi);
          }
        }
      }
      else if (aImlInfo.TypeInfo.DefaultValue != null)
        ok = DeepEquals(value, aImlInfo.TypeInfo.DefaultValue);
      if (!ok)
        ok = IsDefaultValue(value, aImlInfo.Property);
      return ok;
    }

    private static bool DeepEquals(object val1, object val2)
    {
      /*
            if (val1 is IEnumerable && val2 is IEnumerable)
            {
              foreach (object item1 in val1 as IEnumerable)
              {
                bool found = false;
                foreach (object item2 in val2 as IEnumerable)
                {
                  if (DeepEquals(item1, item2))
                  {
                    found = true;
                    break;
                  }
                }
                if (!found)
                  return false;
              }
              return true;
            }
            else
       */
      return val1.Equals(val2);
    }

    private bool IsDefaultValue(object value, PropertyInfo aPropertyInfo)
    {
      if (value == null)
        return true;
      //PropertyInfo aPropertyInfo = aItemInfo.Property;
      Type aPropertyType = aPropertyInfo.PropertyType;
      /*
            TypeConverter aTypeConverter=null;
            if (aItemInfo.ConverterTypeName != null)
            {
              Converters.TryGetValue(aItemInfo.Property.PropertyType.Name, out aTypeConverter);
            }
            if (aTypeConverter == null)
            {
              TypeInfo PropTypeInfo = KnownTypes.Reflect(aPropertyType);
              if (PropTypeInfo.ConverterTypeName != null)
              {
                Converters.TryGetValue(PropTypeInfo.Type.Name, out aTypeConverter);
              }
            }
            if (aTypeConverter != null)
            {
              bool ok = aTypeConverter.CanConvertTo(typeof(string));
              if (ok)
              {
                ICollection stdValues = aTypeConverter.GetStandardValues();
              }
            }
       */
      if (aPropertyType == typeof(System.String))
        return (value as String) == "";
      if (aPropertyType.IsValueType)
      {
        if (aPropertyType == typeof(System.Boolean))
          return (Boolean)(value) == false;
        if (aPropertyType == typeof(System.Int32))
          return (Int32)(value) == 0;
        if (aPropertyType == typeof(System.Int64))
          return (Int64)(value) == 0;
        if (aPropertyType == typeof(System.Int16))
          return (Int16)(value) == 0;
        if (aPropertyType == typeof(System.Byte))
          return (Byte)(value) == 0;
        if (aPropertyType == typeof(System.UInt32))
          return (UInt32)(value) == 0;
        if (aPropertyType == typeof(System.UInt64))
          return (UInt64)(value) == 0;
        if (aPropertyType == typeof(System.UInt16))
          return (UInt16)(value) == 0;
        if (aPropertyType == typeof(System.SByte))
          return (SByte)(value) == 0;
        if (aPropertyType == typeof(System.Single))
        {
          if (Single.IsNaN((Single)value))
            return true;
          return (Single)(value) == 0;
        }
        if (aPropertyType == typeof(System.Double))
        {
          if (Double.IsNaN((double)value))
            return true;
          return (Double)(value) == 0;
        }
        if (aPropertyType == typeof(System.Decimal))
          return (Decimal)(value) == 0;
        if (aPropertyType == typeof(System.DateTime))
          return (DateTime)(value) == new DateTime();
        if (aPropertyType == typeof(System.TimeSpan))
          return (TimeSpan)(value) == TimeSpan.Zero;
        if (aPropertyType.IsEnum)
        {
          int n = (Int32)value;
          return n == 0;
        }
        /*
                if (aPropertyType == typeof(System.Windows.Point))
                  return (Point)(value) == new Point(0, 0);
                if (aPropertyType == typeof(System.Windows.Size))
                  return (Size)(value) == new Size(0, 0);
         */
        ConstructorInfo constructor = aPropertyType.GetConstructor(new Type[] { });
        if (constructor != null)
        {
          object newInstance = constructor.Invoke(new object[] { });
          return value.Equals(newInstance);
        }
        constructor = aPropertyType.GetConstructor(new Type[] { typeof(int) });
        if (constructor != null)
        {
          object newInstance = constructor.Invoke(new object[] { 0 });
          if (value.Equals(newInstance))
            return true;
        }
        constructor = aPropertyType.GetConstructor(new Type[] { typeof(double) });
        if (constructor != null)
        {
          object newInstance = constructor.Invoke(new object[] { 0 });
          if (value.Equals(newInstance))
            return true;
          newInstance = constructor.Invoke(new object[] { double.NaN });
          if (value.Equals(newInstance))
            return true;
        }
        //        if (aPropertyType == typeof(System.Windows.Thickness))
        //          return (Thickness)(value) == new Thickness(0); 
        return false;
      }
      else
      {
        //        if (aPropertyType == typeof(System.Windows.Media.Transform))
        //          return (Transform)(value) == Transform.Identity;
        ICollection aCollection = value as ICollection;
        if (aCollection != null)
          return aCollection.Count == 0;
        else
          return false;
      }
    }

    private void WriteImlAttributes(XmlDictionaryWriter writer, ObjectValue obj, TypeInfo aTypeInfo)
    {
      foreach (ImlItemInfo aImlInfo in aTypeInfo.Attributes)
      {
        if (aImlInfo.Property.CanRead)
        {
          MethodInfo aMethodInfo = aImlInfo.Property.GetGetMethod(true);
          if (aMethodInfo != null)
          {
            ParameterInfo[] Parameters = aMethodInfo.GetParameters();
            if (Parameters.Length == 0)
            {
              object value = aMethodInfo.Invoke(obj.Value, null);
              bool ok = !IsDefaultValue(value, aImlInfo, ref obj.DefaultValues);
              if (ok)
                writer.WriteAttributeString(aImlInfo.ImlName, ConvertValueToString(value, aImlInfo.Property));
            }
          }
        }
      }
    }

    private void WriteImlElements(XmlDictionaryWriter writer, ObjectValue obj, TypeInfo aTypeInfo)
    {
      foreach (ImlItemInfo aImlInfo in aTypeInfo.Elements)
      {
        if (aImlInfo.Property.CanRead)
        {
          MethodInfo aMethodInfo = aImlInfo.Property.GetGetMethod(true);
          if (aMethodInfo != null)
          {
            ParameterInfo[] Parameters = aMethodInfo.GetParameters();
            if (Parameters.Length == 0)
            {
              object value = aMethodInfo.Invoke(obj.Value, null);
              bool ok = (value != null) && !IsDefaultValue(value, aImlInfo, ref obj.DefaultValues);
              if (ok)
              {
                bool isDefault = value == obj;
                if (value is DependencyObjectType)
                  isDefault = (value as DependencyObjectType).SystemType == obj.GetType();
                if (!isDefault)
                {
                  string prefix = aTypeInfo.ElementPrefix ?? "";
                  writer.WriteStartElement(prefix, aImlInfo.ImlName, NamespaceManager.LookupNamespace(prefix));
                  bool done = false;
                  TypeConverter aTypeConverter;
                  if (KnownTypes.Converters.TryGetValue(value.GetType().Name, out aTypeConverter))
                  {
                    if (aTypeConverter.CanConvertTo(typeof(string)))
                    {
                      string s = (string)aTypeConverter.ConvertTo(value, typeof(string));
                      writer.WriteRaw(s);
                      done = true;
                    }
                  }
                  if (!done)
                    WriteObjectContent(writer, value);
                  writer.WriteEndElement();
                }
              }
            }
          }
        }
      }
    }

    private void WriteImlList(XmlDictionaryWriter writer, ObjectValue obj, TypeInfo aTypeInfo)
    {
      foreach (object aItem in obj.Value as IEnumerable)
      {
        if (aItem != null)
        {
          Type aType = aItem.GetType();
          TypeInfo itemTypeInfo = KnownTypes.Reflect(aType);
          if (itemTypeInfo != null)
            WriteStartObject(writer, aItem);
          else if (aTypeInfo.ItemType != null)
            writer.WriteStartElement(aTypeInfo.ItemType.ElementName);
          else
            writer.WriteStartElement("item");
          ObjectValue objValue = new ObjectValue { Value = aItem };
          objValue.SetDefaultValues(obj.DefaultValues);
          WriteObjectContent(writer, objValue);
          writer.WriteEndElement();
        }
      }
    }

    private void WriteImlDictionary(XmlDictionaryWriter writer, ObjectValue obj, TypeInfo aTypeInfo)
    {
      if (aTypeInfo.IsDictionary)
      {
        if (aTypeInfo.KeyType != null && aTypeInfo.ItemType != null)
          foreach (DictionaryEntry aItem in obj as IDictionary)
          {
            if (TypeReflection.IsValueType(aTypeInfo))
            {
              writer.WriteStartElement("item");
              string aKeyName = "key";
              if (aTypeInfo.KeyAttribute != null && !String.IsNullOrEmpty(aTypeInfo.KeyAttribute.ImlName))
                aKeyName = aTypeInfo.KeyAttribute.ImlName;
              writer.WriteAttributeString(aKeyName, ConvertValueToString(aItem.Key, aTypeInfo.KeyType.Type));
              string aValueName = "value";
              if (aTypeInfo.ValueAttribute != null && !String.IsNullOrEmpty(aTypeInfo.ValueAttribute.ImlName))
                aValueName = aTypeInfo.ValueAttribute.ImlName;
              writer.WriteAttributeString(aValueName, ConvertValueToString(aItem.Value, aTypeInfo.ItemType.Type));
              writer.WriteEndElement();
            }
            else
            {
              writer.WriteStartElement(aTypeInfo.ItemType.ElementName);
              string aKeyName = "key";
              if (aTypeInfo.KeyAttribute != null && !String.IsNullOrEmpty(aTypeInfo.KeyAttribute.ImlName))
                aKeyName = aTypeInfo.KeyAttribute.ImlName;
              writer.WriteAttributeString(aKeyName, ConvertValueToString(aItem.Key, aTypeInfo.KeyType.Type));
              ObjectValue objValue = new ObjectValue { Value = aItem };
              objValue.SetDefaultValues(obj.DefaultValues);
              WriteObjectContent(writer, objValue);
              writer.WriteEndElement();
            }
          }
      }
    }

    private void WriteContentProperty(XmlDictionaryWriter writer, ObjectValue obj, PropertyInfo aPropertyInfo)
    {
      MethodInfo aGetMethod = aPropertyInfo.GetGetMethod();
      if (aGetMethod != null)
      {
        object value = aGetMethod.Invoke(obj.Value, new Object[] { });
        if (value != null)
        {
          TypeInfo aTypeInfo = KnownTypes.Reflect(aPropertyInfo.PropertyType);
          if (aTypeInfo.Type == typeof(string))
            writer.WriteRaw(EncodeString((string)value));
          else
          {
            ObjectValue objValue = new ObjectValue { Value = value };
            objValue.SetDefaultValues(obj.DefaultValues);
            if (aTypeInfo.IsDictionary)
              WriteImlDictionary(writer, objValue, aTypeInfo);
            else if (aTypeInfo.IsList)
              WriteImlList(writer, objValue, aTypeInfo);
            else
              WriteObject(writer, value);
          }
        }
      }
    }

    private void WriteValueProperty(XmlDictionaryWriter writer, object obj, ImlItemInfo aValueInfo)
    {
      MethodInfo aGetMethod = aValueInfo.Property.GetGetMethod();
      if (aGetMethod != null)
      {
        object value = aGetMethod.Invoke(obj, new Object[] { });
        if (value != null)
        {
          string s = ConvertValueToString(value, aValueInfo.Property);
          s = EncodeEntities(s);
          writer.WriteRaw(s);
        }
      }
    }

    #endregion

    #region Metody pomocnicze

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Konwersja wartości binarnej na tekstową dla podanego opisu właściwości
    /// </summary>
    /// <param name="value">Wartość binarna</param>
    /// <param name="aPropertyInfo">Opis właściwości</param>
    /// <returns>Wartość tekstowa</returns>
    private string ConvertValueToString(object value, PropertyInfo aPropertyInfo)
    {
      if (value == null)
        return "";
      Type aPropertyType = aPropertyInfo.PropertyType;
      return ConvertValueToString(value, aPropertyType);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Konwersja wartości binarnej na tekstową dla podanego typu wartości
    /// </summary>
    /// <param name="value">Wartość binarna</param>
    /// <param name="aValueType">Typ wartości</param>
    /// <returns>Wartość tekstowa</returns>
    private string ConvertValueToString(object value, Type aValueType)
    {
      if (value == null)
        return "";
      if (aValueType == typeof(System.String))
        return (string)value;
      if (aValueType.IsValueType)
      {
        if (aValueType == typeof(System.Boolean))
          return Convert.ToString((Boolean)value, CultureInfo.InvariantCulture).ToLower();
        if ((aValueType == typeof(System.Int32))
         || (aValueType == typeof(System.Int64))
         || (aValueType == typeof(System.Int16))
         || (aValueType == typeof(System.Byte))
         || (aValueType == typeof(System.UInt32))
         || (aValueType == typeof(System.UInt64))
         || (aValueType == typeof(System.UInt16))
         || (aValueType == typeof(System.SByte)))
          return value.ToString();
        if (aValueType.IsEnum)
          return value.ToString();
        if (aValueType == typeof(System.Single))
          return Convert.ToString((Single)value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.Double))
          return Convert.ToString((Double)value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.Decimal))
          return Convert.ToString((Decimal)value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.DateTime))
        {
          string result = null;
          DateTime dv = (DateTime)value;
          if (dv == new DateTime())
            return result;
          result = dv.ToString("yyyy-MM-dd");
          if (dv.Hour != 0 || dv.Minute != 0 || dv.Second != 0)
            result += 'T' + dv.ToString("HH:mm:ss");
          return result;
        }
        if (aValueType == typeof(System.TimeSpan))
        {
          TimeSpan tv = (TimeSpan)value;
          if (tv == TimeSpan.Zero)
            return null;
          return tv.ToString();
        }
        if (aValueType.IsEnum)
        {
          return value.ToString();
        }

        return value.ToString();
      }
      else
        return value.ToString();
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Konwersja wartości tekstowej na binarną dla określonego typu właściwości
    /// </summary>
    /// <param name="value">Wartość tekstowa</param>
    /// <param name="aValueType">Type właściwości</param>
    /// <returns>Wartość binarna</returns>
    private object ConvertStringToValue(string value, Type aValueType)
    {
      if (aValueType == typeof(System.String))
        return value;
      if (aValueType.IsValueType)
      {
        if (aValueType == typeof(System.Boolean))
        {
          if (string.IsNullOrEmpty(value))
            return false;
          if (value.ToLower() == "true" || value.ToLower() == "t")
            return true;
          if (value.ToLower() == "false" || value.ToLower() == "f")
            return false;
          throw new SerializationException(string.Format("Invalid boolean value: '{0}'", value));
        }
        if (aValueType == typeof(System.Int32))
          return Int32.Parse(value);
        if (aValueType == typeof(System.Int64))
          return Int64.Parse(value);
        if (aValueType == typeof(System.Int16))
          return Int16.Parse(value);
        if (aValueType == typeof(System.Byte))
          return Byte.Parse(value);
        if (aValueType == typeof(System.UInt32))
          return UInt32.Parse(value);
        if (aValueType == typeof(System.UInt64))
          return UInt64.Parse(value);
        if (aValueType == typeof(System.UInt16))
          return UInt16.Parse(value);
        if (aValueType == typeof(System.SByte))
          return SByte.Parse(value);
        if (aValueType == typeof(System.Single))
          return Single.Parse(value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.Double))
          return Double.Parse(value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.Decimal))
          return Decimal.Parse(value, CultureInfo.InvariantCulture);
        if (aValueType == typeof(System.DateTime))
        {
          if (String.IsNullOrEmpty(value))
            return new DateTime();
          return DateTime.Parse(value);
        }
        if (aValueType == typeof(System.TimeSpan))
        {
          if (String.IsNullOrEmpty(value))
            return TimeSpan.Zero;
          return TimeSpan.Parse(value);
        }
        if (aValueType.IsEnum)
        {
          FieldInfo aFieldInfo = aValueType.GetField(value, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
          if (aFieldInfo == null)
            throw new SerializationException(string.Format("Unknown enum value '{0}'", value));
          return Enum.Parse(aValueType, value, true);
        }
        if (aValueType == typeof(System.Guid))
        {
          if (String.IsNullOrEmpty(value))
            return new Guid();
          return Guid.Parse(value);
        }
      }
      TypeConverter aConverter;
      KnownTypes.Converters.TryGetValue(aValueType.Name, out aConverter);
      if (aConverter != null)
      {
        if (aConverter.CanConvertFrom(typeof(string)))
        {
          return aConverter.ConvertFrom(value);
        }
      }
      throw new SerializationException(string.Format("Unimplemented read of property type '{0}'", aValueType.Name));

    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Ustawienie wczytanego atrybutu xml. Aktualnie rozpoznawany jest tylko atrybut 
    ///   xml:space = preserve, który ustawia opcję czytania WhitespacePreserve na true.
    ///   Opcja ta i tak jest ustawiona domyślnie, ale może być zmieniona po utworzeniu
    ///   instancji serializatora.
    /// </summary>
    /// <param name="name">Nazwa atrybutu (po xml:)</param>
    /// <param name="value">Wartość tekstowa atrybutu</param>
    private void SetXmlAttribute(string name, string value)
    {
      if (name == "space")
      {
        if (value == "preserve")
          ReadOptions.WhitespacePreserve = true;
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Ustawienie wczytanego atrybutu xmlns, który reprezentuje przestrzeń nazw. 
    ///   Wartość atrybutu jest przekazywana do menedżera przestrzeni nazw
    ///   (NamespaceManager), który jest częścią menedżera znanych typów.
    /// </summary>
    /// <param name="name">Pełna nazwa atrybutu (łącznie z dwukropkiem)</param>
    /// <param name="value">Wartość tekstowa atrybutu</param>
    private void SetXmlnsAttribute(string name, string value)
    {
      int n = name.IndexOf(':');
      string prefix = null;
      if (n > 0)
        prefix = name.Substring(n + 1);
      if (prefix != null)
      {
        if (NamespaceManager.HasNamespace(prefix))
        {
          string ns = NamespaceManager.LookupNamespace(prefix);
          if (ns != value)
          {
            NamespaceManager.RemoveNamespace(prefix, ns);
            NamespaceManager.AddNamespace(prefix, value);
          }
        }
        else
          NamespaceManager.AddNamespace(prefix, value);
      }
      else
        NamespaceManager.AddNamespace("", value);
      NamespaceManager.AddNamespace(RootAssembly, prefix, value);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Ustawienie wartości wczytanej z atrybutu XML dla podanego obiektu.
    /// </summary>
    /// <param name="obj">Obiekt, którego właściwości są zmieniane</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    /// <param name="aName">Nazwa atrybutu XML, który identyfikuje właściwość obiektu</param>
    /// <param name="aValue">Wartość tekstowa wczytana z atrybutu XML</param>
    private void SetAttributeValue(object obj, TypeInfo objTypeInfo, string aName, string aValue)
    {
      string prefix = null;
      int n;
      n = aName.IndexOf(':');
      if (n > 0)
      {
        prefix = aName.Substring(0, n);
        aName = aName.Substring(n + 1);
      }
      ImlItemInfo aAttributeInfo = FindAttributeNameInfo(objTypeInfo, aName);

      // jeśli nazwa atrybutu została znaleziona
      if (aAttributeInfo != null)
      {
        // to może się on odwoływać do właściwości "zwykłej"
        if (aAttributeInfo.Property != null)
        {
          MethodInfo aSetMethod = aAttributeInfo.Property.GetSetMethod(true);
          if (aSetMethod == null)
            throw new SerializationException(String.Format("Property '{0}' in {1} class has no set method",
              aAttributeInfo.Property.Name, obj.GetType().Name));
          object value = ConvertStringToValue(aValue, aAttributeInfo.Property.PropertyType);
          aSetMethod.Invoke(obj, new object[] { value });
        }
        // albo do właściwości zależnej
        else if (aAttributeInfo.DependencyProperty != null)
        {
          //PropertyMetadata aMetadata = aAttributeInfo.DependencyProperty.DefaultMetadata;
          DependencyObject dpo = obj as DependencyObject;
          if (dpo == null)
            throw new SerializationException(String.Format("DependencyProperty '{0}' defined in class '{1}' which is not DependencyObject",
              aAttributeInfo.DependencyProperty.Name, obj.GetType().Name));
          object value = ConvertStringToValue(aValue, aAttributeInfo.DependencyProperty.PropertyType);
          dpo.SetValue(aAttributeInfo.DependencyProperty, value);
        }
      }
      else
      {
        // nazwa atrybutu nie została znaleziona wprost, to może jest nazwą złożoną, 
        // która zawiera nazwę klasy ustawiającej daną właściwość.
        if (aName.IndexOf('.') > 0)
        {
          SetCompoundAttributeValue(obj, objTypeInfo, aName, aValue);
        }
        else
          // jeśli atrybut nie mógł być ustawiony przez daną klasę, to może przez klasę bazową
          if (objTypeInfo.BaseType != null)
            SetAttributeValue(obj, objTypeInfo.BaseType, aName, aValue);
          else
            throw new SerializationException(String.Format("Can't set attribute '{0}' for class '{1}'",
              aName, obj.GetType().Name));
      }
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Ustawienie wartości złożonej wczytanej z atrybutu XML dla podanego obiektu.
    /// </summary>
    /// <param name="obj">Obiekt, którego właściwości są zmieniane</param>
    /// <param name="objTypeInfo">Opis typu obiektu</param>
    /// <param name="aName">Nazwa atrybutu XML, który identyfikuje właściwość złożoną (zawiera '.')</param>
    /// <param name="aValue">Wartość tekstowa wczytana z atrybutu XML</param>
    private void SetCompoundAttributeValue(object obj, TypeInfo objTypeInfo, string aName, string aValue)
    {
      int k = aName.IndexOf('.');
      string bName = aName.Substring(k + 1);
      aName = aName.Substring(0, k);
      ImlItemInfo aAttributeInfo = FindAttributeNameInfo(objTypeInfo, aName);
      if (aAttributeInfo == null)
        throw new SerializationException(String.Format("Property '{0}' not found in class '{1}'",
          aName, obj.GetType().Name));
      object value = null;
      if (aAttributeInfo.Property != null)
      {
        MethodInfo aGetMethod = aAttributeInfo.Property.GetGetMethod(true);
        if (aGetMethod == null)
          throw new SerializationException(String.Format("Property '{0}' in {1} class has no get method",
            aAttributeInfo.Property.Name, obj.GetType().Name));
        value = aGetMethod.Invoke(obj, new object[] { });
      }
      else if (aAttributeInfo.DependencyProperty != null)
      {
        //PropertyMetadata aMetadata = aAttributeInfo.DependencyProperty.DefaultMetadata;
        DependencyObject dpo = obj as DependencyObject;
        if (dpo == null)
          throw new SerializationException(String.Format("DependencyProperty '{0}' defined in class '{1}' which is not DependencyObject",
            aAttributeInfo.DependencyProperty.Name, obj.GetType().Name));
        value = dpo.GetValue(aAttributeInfo.DependencyProperty);
      }
      else
        throw new SerializationException(String.Format("Can't get attribute '{0}' for class '{1}'",
          aName, obj.GetType().Name));
      if (value == null)
        throw new SerializationException(String.Format("Attribute '{0}' in class '{1}' is null",
          aName, obj.GetType().Name));
      TypeInfo valueTypeInfo = KnownTypes.Reflect(value.GetType());
      SetAttributeValue(value, valueTypeInfo, bName, aValue);
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wyszukanie opisu atrybutu XML w danym opisie typu
    /// </summary>
    /// <param name="objTypeInfo">dany opis typu</param>
    /// <param name="aName"></param>
    /// <returns>obiekt klasy ImlItemInfo opisujący atrybut</returns>
    private ImlItemInfo FindAttributeNameInfo(TypeInfo objTypeInfo, string aName)
    {
      ImlItemInfo aImlInfo = null;
      // najpierw nazwa atrybutu jest poszukiwana wśród tych właściwości obiektu, 
      // które są przeznaczone do zapisu jako atrybuty XML
      if (objTypeInfo.Attributes != null)
      {
        aImlInfo =
          (from aInfo in objTypeInfo.Attributes
           where aInfo.ImlName.ToLowerInvariant() == aName.ToLowerInvariant()
           select aInfo).FirstOrDefault();
      }
      // a jeśli nie zostanie znaleziona, to wśród tych właściwości obiektu, 
      // które są przeznaczone do zapisu jako elementy XML
      if (aImlInfo == null && objTypeInfo.Elements != null)
      {
        aImlInfo =
          (from aInfo in objTypeInfo.Elements
           where aInfo.ImlName.ToLowerInvariant() == aName.ToLowerInvariant()
           select aInfo).FirstOrDefault();
      }
      return aImlInfo;
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Wyszukanie opisu elementu XML w danym opisie typu
    /// </summary>
    /// <param name="objTypeInfo">dany opis typu</param>
    /// <param name="aName"></param>
    /// <returns>obiekt klasy ImlItemInfo opisujący atrybut</returns>
    private ImlItemInfo FindElementNameInfo(TypeInfo objTypeInfo, string aName)
    {
      ImlItemInfo aImlInfo = null;
      // najpierw nazwa elementu jest poszukiwana wśród tych właściwości obiektu, 
      // które są przeznaczone do zapisu jako elementy XML
      if (objTypeInfo.Elements != null)
      {
        aImlInfo =
          (from aInfo in objTypeInfo.Elements
           where aInfo.ImlName.ToLowerInvariant() == aName.ToLowerInvariant()
           select aInfo).FirstOrDefault();
      }
      // a jeśli nie zostanie znaleziona, to wśród tych właściwości obiektu, 
      // które są przeznaczone do zapisu jako atrybuty XML
      if (aImlInfo == null && objTypeInfo.Attributes != null)
      {
        aImlInfo =
          (from aInfo in objTypeInfo.Attributes
           where aInfo.ImlName.ToLowerInvariant() == aName.ToLowerInvariant()
           select aInfo).FirstOrDefault();
      }
      return aImlInfo;
    }

    //------------------------------------------------------------------------------------------
    /// <summary>
    ///   Sprawdzenie, czy dany typ ma konstruktor domyślny.
    /// </summary>
    /// <param name="aType">dany typ</param>
    private bool IsConstructable(Type aType)
    {
      return (aType.GetConstructor(new Type[] { }) != null);
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    /// <summary>
    ///   Converting Unicode string to Html string encoding XML entities.
    /// </summary>
    public static string EncodeEntities(string s)
    {
      string result = "";
      foreach (char ch in s)
      {
        switch (ch)
        {
          case '&': result += "&amp;"; break;
          case '<': result += "&lt;"; break;
          case '>': result += "&gt;"; break;
          case '\x00A0': result += "&#x00A0;"; break;
          default: result += ch; break;
        }
      };
      return result;
    }

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    /// <summary>
    ///   Converting Unicode string to Html string encoding XML entities and paragraph markers.
    /// </summary>
    public static string EncodeString(string s)
    {
      string result = "";
      foreach (char ch in s)
      {
        switch (ch)
        {
          case '&': result += "&amp;"; break;
          case '<': result += "&lt;"; break;
          case '>': result += "&gt;"; break;
          case '\u00A0': result += "&#x00A0;"; break;
          case '\n':
            result += "</p><p>";
            if (!result.StartsWith("<p>"))
              result = "<p>" + result;
            break;
          default: result += ch; break;
        }
      };
      if (result.EndsWith("<p>"))
        result = result.Substring(0, result.Length - 3);
      else if ((result.StartsWith("<p>") && !result.EndsWith("</p>")))
        result += "</p>";
      return result;
    }
    #endregion
  }

}
