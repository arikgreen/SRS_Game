using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Iml.Organization
{
  /// <summary>
  /// Rodzaj mechanizmu bazy danych
  /// </summary>
  public enum DatabaseKind
  {
    /// <value>nieznany typ bazy danych</value>
    Unknown,
    /// <value>wykorzystywany Microsoft SQL Server</value>
    MSSQL,
    /// <value>wykorzystywany mechanizm OleDB</value>
    OLEDB,
    /// <value>wykorzystywany mechanizm ODBC</value>
    ODBC,
    /// <value>wykorzystywane pliki XML</value>
    XML,
  };


}