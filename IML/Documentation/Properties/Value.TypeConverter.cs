using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Iml.Documentation
{

  [TypeConverter(typeof(ValueTypeConverter))]
  public partial class Value
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type">oczekiwany typ wartości</param>
    /// <returns></returns>
    public static Value Parse (string str, ValueType type)
    {
      Value result;
      if (TryParse(str, type, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse Value from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <param name="type">oczekiwany typ wartości</param>
    /// <returns></returns>
    public static bool TryParse (string str, ValueType type, out Value value)
    {
      value = null;
      switch (type.Type)
      {
        case ValueTypes.String:
        case ValueTypes.LongString:
        case ValueTypes.ShortString:
          value = new Value { Type = type, Val = str };
          return true;
        case ValueTypes.Bool:
          bool b;
          if (!bool.TryParse(str, out b))
            return false;
          value = new Value { Type = type, Val = b };
          return true;
        case ValueTypes.Int:
          int i;
          if (!int.TryParse(str, out i))
            return false;
          value = new Value { Type = type, Val = i };
          return true;
        case ValueTypes.Int8:
          sbyte i8;
          if (!sbyte.TryParse(str, out i8))
            return false;
          value = new Value { Type = type, Val = i8 };
          return true;
        case ValueTypes.Int16:
          Int16 i16;
          if (!Int16.TryParse(str, out i16))
            return false;
          value = new Value { Type = type, Val = i16 };
          return true;
        case ValueTypes.Int32:
          Int32 i32;
          if (!Int32.TryParse(str, out i32))
            return false;
          value = new Value { Type = type, Val = i32 };
          return true;
        case ValueTypes.Int64:
          Int64 i64;
          if (!Int64.TryParse(str, out i64))
            return false;
          value = new Value { Type = type, Val = i64 };
          return true;
        case ValueTypes.UInt:
          uint ui;
          if (!uint.TryParse(str, out ui))
            return false;
          value = new Value { Type = type, Val = ui };
          return true;
        case ValueTypes.UInt8:
          byte ui8;
          if (!byte.TryParse(str, out ui8))
            return false;
          value = new Value { Type = type, Val = ui8 };
          return true;
        case ValueTypes.UInt16:
          UInt16 ui16;
          if (!UInt16.TryParse(str, out ui16))
            return false;
          value = new Value { Type = type, Val = ui16 };
          return true;
        case ValueTypes.UInt32:
          UInt32 ui32;
          if (!UInt32.TryParse(str, out ui32))
            return false;
          value = new Value { Type = type, Val = ui32 };
          return true;
        case ValueTypes.UInt64:
          UInt64 ui64;
          if (!UInt64.TryParse(str, out ui64))
            return false;
          value = new Value { Type = type, Val = ui64 };
          return true;
        case ValueTypes.Currency:
        case ValueTypes.Decimal:
          decimal d;
          if (!decimal.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out d))
            return false;
          value = new Value { Type = type, Val = d };
          return true;
        case ValueTypes.Float:
          float f;
          if (!float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out f))
            return false;
          value = new Value { Type = type, Val = f };
          return true;
        case ValueTypes.Double:
          double db;
          if (!double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out db))
            return false;
          value = new Value { Type = type, Val = db };
          return true;
        case ValueTypes.Empty:
        case ValueTypes.Null:
          value = new Value { Type = type };
          return true;
        case ValueTypes.ErrorCode:
          int e;
          if (!int.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out e))
            return false;
          value = new Value { Type = type, Val = e };
          return true;
        case ValueTypes.Guid:
          value = new Value { Type = type, Val = str };
          return true;
        case ValueTypes.Blob:
        case ValueTypes.ObjectBlob:
        case ValueTypes.Storage:
        case ValueTypes.ObjectStorage:
        case ValueTypes.StreamData:
        case ValueTypes.ObjectStreamData:
        case ValueTypes.VersionedStreamData:
        case ValueTypes.ClipboardData:
          value = new Value { Type = type, Val = str };
          return true;
        case ValueTypes.Timestamp:
        case ValueTypes.DateTime:
          DateTime dt;
          if (!DateTime.TryParse(str, out dt))
            return false;
          value = new Value { Type = type, Val = dt };
          return true;
        case ValueTypes.Array:
          return false;
        case ValueTypes.Vector:
          VectorValue vect;
          if (!VectorValue.TryParse(str, type, out vect))
            return false;
          value = vect;
          return true;
        case ValueTypes.Variant:
          VariantValue variant;
          if (!VariantValue.TryParse(str, type, out variant))
            return false;
          value = variant;
          return true;
      }
      return false;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      switch (Type.Type)
      {
        case ValueTypes.String:
        case ValueTypes.LongString:
        case ValueTypes.ShortString:
          return (string)Val;
        case ValueTypes.Bool:
          return Val.ToString();
        case ValueTypes.Int:
          return ((int)Val).ToString();
        case ValueTypes.Int8:
          return ((sbyte)Val).ToString();
        case ValueTypes.Int16:
          return ((Int16)Val).ToString();
        case ValueTypes.Int32:
          return ((Int32)Val).ToString();
        case ValueTypes.Int64:
          return ((Int16)Val).ToString();
        case ValueTypes.UInt:
          return ((uint)Val).ToString();
        case ValueTypes.UInt8:
          return ((byte)Val).ToString();
        case ValueTypes.UInt16:
          return ((UInt16)Val).ToString();
        case ValueTypes.UInt32:
          return ((UInt32)Val).ToString();
        case ValueTypes.UInt64:
          return ((UInt16)Val).ToString();
        case ValueTypes.Currency:
        case ValueTypes.Decimal:
          return ((decimal)Val).ToString(CultureInfo.InvariantCulture);
        case ValueTypes.Float:
          return ((float)Val).ToString(CultureInfo.InvariantCulture);
        case ValueTypes.Double:
          return ((double)Val).ToString(CultureInfo.InvariantCulture);
        case ValueTypes.Empty:
        case ValueTypes.Null:
          return null;
        case ValueTypes.ErrorCode:
          return ((int)Val).ToString("X8");
        case ValueTypes.Guid:
          return (string)Val;
        case ValueTypes.Blob:
        case ValueTypes.ObjectBlob:
        case ValueTypes.Storage:
        case ValueTypes.ObjectStorage:
        case ValueTypes.StreamData:
        case ValueTypes.ObjectStreamData:
        case ValueTypes.VersionedStreamData:
        case ValueTypes.ClipboardData:
          return (string)Val;
        case ValueTypes.Timestamp:
        case ValueTypes.DateTime:
          return ((DateTime)Val).ToString(CultureInfo.InvariantCulture);
        case ValueTypes.Vector:
          return (this as VectorValue).ToString();
        case ValueTypes.Variant:
          return (this as VariantValue).ToString();
        case ValueTypes.Array:
          throw new NotImplementedException("Value type not implemented");
      }
      return null;
    }


    /// <summary>
    /// Konwersja typu wartości na łańcuch
    /// </summary>
    /// <returns></returns>
    public virtual string TypeToString()
    {
      return Type.ToString();
    }
  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class ValueTypeConverter : TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;
      else
        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
    {
      if (!(destinationType == typeof(string)))
      {
        return base.CanConvertTo(context, destinationType);
      }
      if ((context != null))
      {
        if (context.PropertyDescriptor != null)
        {
          return true;
        }
        return false;
      }
      return base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        if ((context != null))
        {
          Property property = context.Instance as Property;
          if (property!=null && property.Type!=null)
          {
            Value result = Value.Parse(value as string, (ValueTypes)property.Type);
            return result;
          }
        }
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Value)
      {
        Value val = (Value)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}

