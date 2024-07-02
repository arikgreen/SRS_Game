using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Organization
{
  /// <summary>
  /// Informacja o użytkowniku
  /// </summary>
  public partial class UserInfo
  {
    /// <summary>
    /// ID użytkownika
    /// </summary>
    public Guid UserID { get; set; }
    /// <summary>
    /// Nazwa (login) użytkownika
    /// </summary>
    public string Login { get; set; }
    /// <summary>
    /// Role użytkownika
    /// </summary>
    public string[] Roles { get; set; }
    /// <summary>
    /// Imię użytkownika
    /// </summary>
    public string Firstname { get; set; }
    /// <summary>
    /// Nazwisko użytkownika
    /// </summary>
    public string Lastname { get; set; }
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return Login;
    }
  }
}
