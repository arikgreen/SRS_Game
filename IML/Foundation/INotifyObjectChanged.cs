using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Zdarzenie powiadomienia o zmianie obiektu
  /// </summary>
  public interface INotifyObjectChanged
  {
    /// <summary>
    /// Procedura obsługi
    /// </summary>
    event NotifyObjectChangedEventHandler ObjectChanged;

    /// <summary>
    /// Zgłoszenie zmiany
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="propName"></param>
    void NotifyObjectChanged(object sender, string propName);
  }

  /// <summary>
  /// Delegacja do procedury obsługi
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  public delegate void NotifyObjectChangedEventHandler(object sender, NotifyObjectChangedEventArgs e);

  /// <summary>
  /// Argumenty zdarzenia zmiany obiektu
  /// </summary>
  public partial class NotifyObjectChangedEventArgs : EventArgs
  {
    /// <summary>
    /// Konstruktor inicjujący
    /// </summary>
    /// <param name="changedObject"></param>
    /// <param name="propertyName"></param>
    public NotifyObjectChangedEventArgs(object changedObject, string propertyName=null) 
    {
      ChangedObject = changedObject;
      PropertyName = propertyName; 
    }
    /// <summary>
    /// Zmieniany obiekt
    /// </summary>
    public object ChangedObject { get; private set; }
    /// <summary>
    /// Zmieniana właściwość
    /// </summary>
    public string PropertyName { get; private set; }
  }
}
