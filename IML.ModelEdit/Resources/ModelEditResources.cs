using System;
using System.ComponentModel;

namespace IML.ModelEdit
{

  /// <summary>
  ///  Klasa dostępowa do zasobów aplikacji. 
  ///  Klasa ta jest konieczna, 
  ///  aby włączyć instancję zasobów aplikacji do każdego pliku XAML.
  /// </summary>
  public class ModelEditResources: INotifyPropertyChanged
  {
    /// <summary>
    /// Wspólna instancja dla innych instancji
    /// </summary>
    public ModelEditResources Instance
    {
      get
      {
        if (fInstance == null)
          fInstance = new ModelEditResources();
        return fInstance;
      }
    }
    private static ModelEditResources fInstance;

    /// <summary>
    /// Wspólna instancja dla wszystkich instancji
    /// </summary>
    public static ModelEditResources CommonInstance
    {
      get
      {
        if (fInstance == null)
          fInstance = new ModelEditResources();
        return fInstance;
      }
    }

    public MetamodelsStrings MetamodelsStrings
    {
      get
      {
        return fMetamodelsStrings;
      }
    }
    private static MetamodelsStrings fMetamodelsStrings = new MetamodelsStrings();

    /// <summary>
    /// Ponowne załadowanie zasobów tekstowych
    /// </summary>
    public void RefreshResources ()
    {
      fMetamodelsStrings = new MetamodelsStrings();
      NotifyPropertyChanged("MetamodelsStrings");
    }

    #region INotifyPropertyChanged Members

    /// <summary>
    /// Zdarzenie zmiany
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Metoda powiadomienia o zmianie właściwości
    /// </summary>
    /// <param name="propertyName">nazwa zmienionej właściwości</param>
    public void NotifyPropertyChanged (string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region DefaultBaseMetaclass
    public static Metaclass DefaultBaseMetaclass 
    {
      get { return fDefaultBaseMetaclass; }
      set
      {
        if (fDefaultBaseMetaclass!=value)
        {
          fDefaultBaseMetaclass = value;
          //NotifyPropertyChanged("DefaultBaseMetaclass");
        }
      }
    }
    private static Metaclass fDefaultBaseMetaclass;
    #endregion

  }
}