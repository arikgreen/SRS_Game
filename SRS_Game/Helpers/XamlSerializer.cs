using SRS_Game.Models.Srs;
using System.Text;
using Portable.Xaml;

namespace SRS_Game.Helpers
{
    public class XamlSerializer
    {
        public static string SerializeObjectToXaml(object obj)
        {
            using var stringWriter = new StringWriter();
            XamlServices.Save(stringWriter, obj);
            return stringWriter.ToString();
        }

        public static SRS DeserializeObjectToXaml(string xamlContent)
        {
            // Deserialize the XAML content into an object
            using var stringReader = new StringReader(xamlContent);
            return (SRS)XamlServices.Load(stringReader);
        }
    }
}
