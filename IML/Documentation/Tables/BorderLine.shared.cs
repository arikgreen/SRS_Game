using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class BorderLine
  {
    /// <summary>
    /// Porównanie dwóch linii
    /// </summary>
    /// <param name="obj">drugi kolor</param>
    /// <returns></returns>
    public override bool Equals (object obj)
    {
      if (obj is BorderLine)
      {
        BorderLine other = obj as BorderLine;
        return this.Kind == other.Kind
          && this.LineWidth == other.LineWidth
          && this.LineColor == other.LineColor
          && this.LineStyle == other.LineStyle;
      }
      return base.Equals(obj);
    }

    /// <summary>
    /// Konieczne jeśli nadpisujemy metodę <c>Equals</c>
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode ()
    {
      int n=0;
      if (Kind != null)
        n += Kind.GetHashCode();
      if (LineWidth != null)
        n += LineWidth.GetHashCode();
      if (LineColor != null)
        n += LineColor.GetHashCode();
      if (LineStyle != null)
        n += LineStyle.GetHashCode();
      return n;
    }

    /// <summary>
    /// Połączenie dwóch segmentów obramowań
    /// </summary>
    public static BorderLine operator | (BorderLine A, BorderLine B)
    {
      if (B == null)
        return A;
      if (A == null)
        return B;
      BorderLine result = new BorderLine();
      result.Kind = (LineKind)(Math.Max((int)A.Kind, (int)B.Kind));
      if (A.LineWidth != null && B.LineWidth == null)
        result.LineWidth = A.LineWidth;
      if (A.LineWidth == null && B.LineWidth != null)
        result.LineWidth = B.LineWidth;
      else if (A.LineWidth != null && B.LineWidth != null)
        result.LineWidth = ((double)A.LineWidth + (double)B.LineWidth) / 2.0;
      result.LineColor = Color.Add(A.LineColor, B.LineColor);
      return result;
    }

  }
}
