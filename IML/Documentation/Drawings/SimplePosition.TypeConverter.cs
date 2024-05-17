using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation.Drawings
{
    [TypeConverter(typeof(SimplePositionTypeConverter))]
    public partial class SimplePosition
    {
        /// <summary>
        /// Konwersja z łańcucha
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static SimplePosition Parse(string str)
        {
            SimplePosition result;
            if (TryParse(str, out result))
                return result;
            throw new FormatException(String.Format("Cannot parse SimplePosition from string \"{0}\"", str));
        }

        /// <summary>
        /// Próba konwersji z łańcucha
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParse(string str, out SimplePosition value)
        {
            return FormatHelper.TryParse<SimplePosition>(str, out value);
        }

        /// <summary>
        /// Konwersja na łańcuch
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = FormatHelper.ToString(this);
            return result;
        }
    }

    /// <summary>
    /// Konwerter tekstowy formatu tekstowego
    /// </summary>
    public partial class SimplePositionTypeConverter : TypeConverter
    {
        /// <summary>
        /// Konwersja z postaci tekstowej dozwolona
        /// </summary>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Konwersja do postaci tekstowej dozwolona
        /// </summary>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                SimplePosition result = SimplePosition.Parse(value as string);
                return result;
            }
            else
                return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Konwersja do postaci tekstowej
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is SimplePosition)
            {
                SimplePosition val = (SimplePosition)value;
                return val.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
