using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class Borders : ObjectList<BorderLine>
  {
    /// <summary>
    /// Pobranie konkretnej linii obramowania
    /// </summary>
    public BorderLine GetBorderLine (BorderLinePlacement placement)
    {
      return (from BorderLine item in this where item.Placement == placement select item).FirstOrDefault();
    }

    /// <summary>
    /// Ustawienie konkretnej linii obramowania
    /// </summary>
    public void SetBorderLine (BorderLinePlacement placement, BorderLine value)
    {
      if (value.Placement == 0)
        value.Placement = placement;
      BorderLine aLine = (from BorderLine item in this where item.Placement == placement select item).FirstOrDefault();
      if (aLine == null)
      {
        if (value != null)
          this.Add(value);
      }
      else
      {
        if (aLine != value)
        {
          this.Remove(value);
          if (value != null)
            this.Add(value);
        }
      }
    }

    /// <summary>
    /// Obramowanie z lewej
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Left
    {
      get { return GetBorderLine(BorderLinePlacement.Left); }
      set { SetBorderLine(BorderLinePlacement.Left, value); }
    }
    /// <summary>
    /// Obramowanie z góry
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Top 
    {
      get { return GetBorderLine(BorderLinePlacement.Top); }
      set { SetBorderLine(BorderLinePlacement.Top, value); }
    }
    /// <summary>
    /// Obramowanie z prawej
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Right 
    {
      get { return GetBorderLine(BorderLinePlacement.Right); }
      set { SetBorderLine(BorderLinePlacement.Right, value); }
    }
    /// <summary>
    /// Obramowanie z dołu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Bottom 
    {
      get { return GetBorderLine(BorderLinePlacement.Bottom); }
      set { SetBorderLine(BorderLinePlacement.Bottom, value); }
    }

    /// <summary>
    /// Linia na początku
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Start
    {
      get { return GetBorderLine(BorderLinePlacement.Start); }
      set { SetBorderLine(BorderLinePlacement.Start, value); }
    }

    /// <summary>
    /// Linia na końcu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine End
    {
      get { return GetBorderLine(BorderLinePlacement.End); }
      set { SetBorderLine(BorderLinePlacement.End, value); }
    }

    /// <summary>
    /// Wewnętrzne linie poziome
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Horizontal 
    {
      get { return GetBorderLine(BorderLinePlacement.InsideHorizontal); }
      set { SetBorderLine(BorderLinePlacement.InsideHorizontal, value); }
    }

    /// <summary>
    /// Wewnętrzne linie pionowe
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Vertical 
    {
      get { return GetBorderLine(BorderLinePlacement.InsideVertical); }
      set { SetBorderLine(BorderLinePlacement.InsideVertical, value); }
    }

    /// <summary>
    /// Linia przekątna "\"
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine Diagonal
    {
      get { return GetBorderLine(BorderLinePlacement.Diagonal); }
      set { SetBorderLine(BorderLinePlacement.Diagonal, value); }
    }

    /// <summary>
    /// Linia przekątna "/"
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine BackDiagonal
    {
      get { return GetBorderLine(BorderLinePlacement.BackDiagonal); }
      set { SetBorderLine(BorderLinePlacement.BackDiagonal, value); }
    }

    /// <summary>
    /// Pomiędzy podobnymi akapitami
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine BetweenSameParagraphs
    {
      get { return GetBorderLine(BorderLinePlacement.BetweenSameParagraphs); }
      set { SetBorderLine(BorderLinePlacement.BetweenSameParagraphs, value); }
    }

    /// <summary>
    /// Pomiędzy sąsiadującymi stronami
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderLine BetweenFacingPages
    {
      get { return GetBorderLine(BorderLinePlacement.BetweenFacingPages); }
      set { SetBorderLine(BorderLinePlacement.BetweenFacingPages, value); }
    }

  }

}
