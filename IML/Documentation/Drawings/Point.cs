using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Współrzędne punktu
  /// </summary>
  public struct Point
  {

    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Point(double x, double y): this()
    {
      X = x;
      Y = y;
    }

    /// <summary>
    /// Współrzędna X
    /// </summary>
    double X;
    /// <summary>
    /// Współrzędna Y
    /// </summary>
    double Y;

    /// <summary>
    /// Niejawna konwersja na punkt z pakietu <c>System.Drawing</c>
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static implicit operator PointF(Point p)
    {
      return new PointF((float)p.X, (float)p.Y);
    }
  }
}
