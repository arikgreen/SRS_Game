using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  public partial class Rotation3D
  {
    /// <summary>
    /// Konwersja na łańcuch wszystkich trzech współrzędnych
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return String.Format("Latitude={0};Longitude={1};Revolution={2}",Latitude,Longitude,Revolution);
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Rotation3D Parse (string s)
    {
      Rotation3D result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Rotation3D string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out Rotation3D result)
    {
      result = new Rotation3D();
      string[] ss = s.Split(';');
      if (ss.Length != 3)
        return false;
      foreach (string s1 in ss)
      {
        if (s1 == null)
          return false;
        string[] ss1 = s1.Split('=');
        if (ss1.Length!=2)
          return false;
        if (ss1[0] == null || ss1[1] == null)
          return false;
          
        string name = ss1[0].ToLowerInvariant();
        Angle val;
        if (!Angle.TryParse(ss1[1], out val))
          return false;
          if (name.StartsWith("lon"))
            result.Longitude=val;
          else if (name.StartsWith("lat"))
            result.Latitude=val;
          else if (name.StartsWith("rev"))
            result.Revolution = val;
          
        }
        return true;
      }

    }
}
