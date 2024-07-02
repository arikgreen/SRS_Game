using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Organization
{
  /// <summary>
  /// Informacja o konfiguracji szablonów
  /// </summary>
  [ContentProperty("Templates")]
  public partial class TemplateConfigInfo
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TemplateConfigInfo()
    {
      Templates = new List<TemplateInfo>();
    }

    /// <summary>
    /// Ścieżka dostępu do plików szablonów
    /// </summary>
    public string TemplatePath { get; set; }

    /// <summary>
    /// Domyślny szablon (nazwa pliku, bez ścieżki)
    /// </summary>
    public string DefaultTemplate { get; set; }

    /// <summary>
    /// Lista szablonów
    /// </summary>
    public List<TemplateInfo> Templates { get; private set; }
  }
}
