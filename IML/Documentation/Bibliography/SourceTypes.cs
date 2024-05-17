using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Stereotyping;

namespace Iml.Documentation.Bibliography
{
  /// <summary>
  /// Typy źródeł bibliograficznych
  /// </summary>
  public enum SourceTypes
  {
    /// <summary>
    /// Książka
    /// </summary>
    Book,

    /// <summary>
    /// Rozdział w książce
    /// </summary>
    BookSection,

    /// <summary>
    /// Artykuł z magazynu
    /// </summary>
    JournalArticle,

    /// <summary>
    /// Artykuł z czasopisma
    /// </summary>
    ArticleInAPeriodical,

    /// <summary>
    /// Materiały konferencyjne
    /// </summary>
    ConferenceProceedings,

    /// <summary>
    /// Raport
    /// </summary>
    Report,

    /// <summary>
    /// Witryna sieci Web
    /// </summary>
    InternetSite,

    /// <summary>
    /// Dokument z sieci Web
    /// </summary>
    DocumentFromInternetSite,

    /// <summary>
    /// Źródło elektroniczne
    /// </summary>
    ElectronicSource,

    /// <summary>
    /// Sztuka
    /// </summary>
    Art,

    /// <summary>
    /// Nagranie dźwiękowe
    /// </summary>
    SoundRecording,


    /// <summary>
    /// Przedstawienie
    /// </summary>
    Performance,

    /// <summary>
    /// Film
    /// </summary>
    Film,

    /// <summary>
    /// Wywiad
    /// </summary>
    Interview,

    /// <summary>
    /// Patent
    /// </summary>
    Patent,

    /// <summary>
    /// Orzeczenie
    /// </summary>
    Case,

    /// <summary>
    /// Inne
    /// </summary>
    Misc,
  }
}
