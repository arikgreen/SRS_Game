using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Komenda ścieżki z parametrami
  /// </summary>
  public partial class ShapePathCommand
  {
    /// <summary>
    /// Konstruktor bez parametrów
    /// </summary>
    /// <param name="cmd"></param>
    public ShapePathCommand (ShapePathCmd cmd)
    {
      Cmd = cmd;
    }

    /// <summary>
    /// Konstruktor z jednym parametrem
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="p"></param>
    public ShapePathCommand (ShapePathCmd cmd, Point p)
    {
      Cmd = cmd;
      Points = new Point[1];
      Points[0] = p;
    }

    /// <summary>
    /// Konstruktor z wieloma parametrami
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="points"></param>
    public ShapePathCommand (ShapePathCmd cmd, Point[] points)
    {
      Cmd = cmd;
      Points = points;
    }

    /// <summary>
    /// Wartość komendy
    /// </summary>
    public ShapePathCmd Cmd { get; set; }
    /// <summary>
    /// Lista parametrów - współrzędnych punktów
    /// </summary>
    public Point[] Points { get; set; }
  }
}
