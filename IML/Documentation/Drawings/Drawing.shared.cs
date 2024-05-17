using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  public partial class Drawing
  {
    /// <summary>
    /// Dodanie elementu do rysunku
    /// </summary>
    /// <param name="element"></param>
    public void Add (DrawingItem element)
    {
      Content.Add(element);
    }


    /// <summary>
    /// Eksportuje rysunek do bitmapy w podanej rozdzieczości
    /// </summary>
    /// <param name="resolution"></param>
    /// <returns></returns>
    public Bitmap ExportToBitmap (int resolution)
    {
      int intWidth = (int)(Width * resolution / 72.0);
      int intHeight = (int)(Height * resolution / 72.0);
      Bitmap bmp = new Bitmap(intWidth, intHeight);
      Graphics g = Graphics.FromImage(bmp);
      g.SmoothingMode = SmoothingMode.AntiAlias;
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
      g.ScaleTransform((float)(resolution / 72.0), (float)(resolution / 72.0));
      //foreach (DrawingElement element in Components)
      //{
      //  element.Draw(g);
      //}
      g.Flush();

      return bmp;
    }

  }
}
