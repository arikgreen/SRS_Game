using System.Text.RegularExpressions;

namespace SRS_Game.Helpers
{
    public class MyRegex
    {
        public static string NewLineToBr(string text)
        {
            Regex regex = new Regex(@"((\r)?\n|\u0010)");
            return regex.Replace(text, "<br />");
        }
    }
}
