using SRS_Game.Models.Srs;
using System.Text;

namespace SRS_Game.Helpers
{
    public class XamlGenerator
    {
        public static string GenerateSRSXaml(SRS srs)
        {
            StringBuilder xaml = new StringBuilder();

            // Begin XAML document
            xaml.AppendLine("<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">");

            // Project Title
            xaml.AppendLine($"<TextBlock FontSize=\"20\" FontWeight=\"Bold\" Text=\"Project: {srs.ProjectName}\" />");
            xaml.AppendLine($"<TextBlock Text=\"Version: {srs.Version}\" />");
            xaml.AppendLine($"<TextBlock Text=\"Author: {srs.Author}\" />");
            xaml.AppendLine($"<TextBlock Text=\"Date: {srs.CreatedDate}\" />");

            // Introduction
            xaml.AppendLine("<TextBlock FontSize=\"16\" FontWeight=\"Bold\" Text=\"Introduction\" />");
            xaml.AppendLine($"<TextBlock Text=\"{srs.Introduction}\" TextWrapping=\"Wrap\" />");

            // Functional Requirements
            xaml.AppendLine("<TextBlock FontSize=\"16\" FontWeight=\"Bold\" Text=\"Functional Requirements\" />");
            foreach (var req in srs.FuncionalityRequirements)
            {
                xaml.AppendLine($"<TextBlock FontWeight=\"Bold\" Text=\"{req.Name}\" />");
                xaml.AppendLine($"<TextBlock Text=\"{req.Description}\" TextWrapping=\"Wrap\" />");
                xaml.AppendLine($"<TextBlock Text=\"Priority: {req.Priority}\" />");
            }

            // Closing XAML document
            xaml.AppendLine("</StackPanel>");

            return xaml.ToString();
        }
    }
}
