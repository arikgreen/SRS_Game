using Iml.Documentation.Multimedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Zdarzenie obsługiwane przez hiperłącze
  /// </summary>
  public partial class EventHyperlink
  {
    /// <summary>
    /// Akcja, która ma być podjęta przy obsłudze zdarzenia
    /// </summary>
    [DefaultValue(null)]
    public string Action { get; set; }
    /// <summary>
    /// Czy ma zatrzymywać odtwarzanie dźwięków
    /// </summary>
    [DefaultValue(null)]
    public bool? EndSound { get; set; } 
    /// <summary>
    /// Czy hiperłącze ma być podświetlone jako odwiedzone
    /// </summary>
    [DefaultValue(null)]
    public bool? HighlightClick { get; set; }
    /// <summary>
    /// Czy zdarzenie ma być dodawane do historii
    /// </summary>
    [DefaultValue(null)]
    public bool? AddToHistory { get; set; }
    /// <summary>
    /// Id relacji elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string TargetRef { get; set; }
    /// <summary>
    /// Niepoprawny URL generowany przez aplikację
    /// </summary>
    [DefaultValue(null)]
    public string InvalidURL { get; set; }
    /// <summary>
    /// Miejsce prezentacji elementu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string DisplayWindow { get; set; }

    /// <summary>
    /// Dźwięk odtwarzany przy zdarzeniu
    /// </summary>
    public Sound TargetSound { get; set; }

    /// <summary>
    /// Napis wyświetlany przy wskazaniu hiperłącza myszą
    /// </summary>
    [DefaultValue(null)]
    public string Tooltip { get; set; }

    /// <summary>
    /// Lista rozszerzeń
    /// </summary>
    public ExtensionList Extensions 
    { 
      get { if (fExtensions == null) fExtensions = new ExtensionList(this); return fExtensions; }
      set { fExtensions = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>Pole przechowujące listę rozszerzeń</summary>
    protected ExtensionList fExtensions;

    /// <summary>
    /// Czy lista rozszerzeń powinna być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeExtensions()
    {
      return fExtensions != null && !fExtensions.IsEmpty();
    }
  }
}
