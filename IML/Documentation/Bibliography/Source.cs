using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using IML = Iml.Documentation;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Klasa reprezentująca pojedynczy element bibliografii
  /// </summary>
  public partial class Source: Item
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    public Source()
    {
      Authors = new Authors();
    }

    /// <summary>
    /// Identyfikator unikatowy (GUID)
    /// </summary>
    public Guid ID { get; set; }
    /// <summary>
    /// Identyfikator referencyjny (znacznik), do którego odwołują się cytowania w tekście
    /// </summary>
    public new string Tag { get; set; }
    /// <summary>
    /// Kolejność w bibliografii
    /// </summary>
    public int RefOrder { get; set; }
    /// <summary>
    /// Typ źródła
    /// </summary>
    public SourceTypes SourceType { get; set; }
    /// <summary>
    /// Lista autorów
    /// </summary>
    public Authors Authors { get; private set; }
    /// <summary>
    /// Tytuł
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Rok publikacji
    /// </summary>
    public string Year { get; set; }
    /// <summary>
    /// Język publikacji (LCID)
    /// </summary>
    public string LCID { get; set; }    
    /// <summary>
    /// Dodatkowe właściwości
    /// </summary>
    public NameValueList ExtraProperties 
    { 
      get
      {
        if (fExtraProperties == null)
          fExtraProperties = new NameValueList(this);
        return fExtraProperties;
      }
      set { fExtraProperties = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę dodatkowych właściwości
    /// </summary>
    protected NameValueList fExtraProperties;

    /// <summary>
    /// Czy lista dodatkowych właściwości ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeExtraProperties()
    {
      return fExtraProperties != null && !fExtraProperties.IsEmpty();
    }
    /// <summary>
    /// Dostęp do odczytu właściwości dodatkowej
    /// </summary>
    public T GetExtraProperty<T>(string propertyName) where T: class
    {
      NameValuePair param;
      if (this.ExtraProperties.TryGetValue(propertyName, out param))
        return param.Value as T;
      else
        return null;
    }

    /// <summary>
    /// Dostęp do zapisu właściwości dodatkowej
    /// </summary>
    public void SetExtraProperty<T> (string propertyName, T value) where T : class
    {
      if (value != null)
      {
        NameValuePair param;
        if (this.ExtraProperties.TryGetValue(propertyName, out param))
          param.Value = value.ToString();
        else
          this.ExtraProperties.Add(new NameValuePair { Name = propertyName, Value = value } );
      }
      else
      {
        if (this.ExtraProperties.ContainsKey(propertyName))
          this.ExtraProperties.Remove(propertyName);
      }
    }

  }
}
