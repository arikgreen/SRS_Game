using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IML.ModelEdit
{
  /// <summary>
  /// Bazowy generator kodu. 
  /// Udostępnia operacje do wypisywania kodu źródłowego na standardowe wyjście,
  /// które może być inne dla każdej instancji.
  /// </summary>
  public class BaseCodeGenerator
  {

    /// <summary>
    /// Konstruktor domyślny - wymaga podania wyjścia
    /// </summary>
    /// <param name="writer"></param>
    public BaseCodeGenerator (TextWriter writer)
    {
      Output = writer;
    }

    /// <summary>
    /// Standardowe wyjście generatora kodu
    /// </summary>
    protected TextWriter Output { get; set; }

    /// <summary>
    /// Głębokość wcięcia
    /// </summary>
    protected int Indent { get; set; }

    /// <summary>
    /// Łańcuch wcięcia
    /// </summary>
    protected string IndentString
    {
      get { return new String(' ', Indent * 2); }
    }

    /// <summary>
    /// Wypisanie pustej linii na wyjście
    /// </summary>
    protected void WriteLine ()
    {
      Output.WriteLine();
    }

    /// <summary>
    /// Wypisanie linii na wyjście
    /// </summary>
    /// <param name="line"></param>
    protected void WriteLine (string line)
    {
      Output.WriteLine(IndentString + line);
    }

    /// <summary>
    /// Wypisanie linii na wyjście
    /// </summary>
    /// <param name="line"></param>
    protected void WriteLine (string format, params object[] args)
    {
      string line = String.Format(format, args);
      Output.WriteLine(IndentString + line);
    }
  }
}
