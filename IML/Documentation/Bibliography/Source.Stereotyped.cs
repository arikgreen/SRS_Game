using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Bibliography
{
  public partial class Source: Book, BookSection, 
    JournalArticle, ArticleInAPeriodical, ConferenceProceedings, Report,
    InternetSite, DocumentFromInternetSite, 
    ElectronicSource,
    Art, Performance,
    SoundRecording, Film,
    Interview,
    Patent,
    Case,
    Misc
  {

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Translator"/>
    /// </summary>
    public Authors Translator
    {
      get { return GetExtraProperty<Authors>("Translator"); }      
      set { SetExtraProperty<Authors>("Translator", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Editor"/>
    /// </summary>
    public Authors Editor
    {
      get { return GetExtraProperty<Authors>("Editor"); }      
      set { SetExtraProperty<Authors>("Editor", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="BookSection.BookAuthor"/>
    /// </summary>
    public Authors BookAuthor
    {
      get { return GetExtraProperty<Authors>("BookAuthor"); }
      set { SetExtraProperty<Authors>("BookAuthor", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.ProducerName"/>
    /// </summary>
    public Authors ProducerName
    {
      get { return GetExtraProperty<Authors>("ProducerName"); }
      set { SetExtraProperty<Authors>("ProducerName", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Art.Artist"/>
    /// </summary>
    public Authors Artist
    {
      get { return GetExtraProperty<Authors>("Artist"); }
      set { SetExtraProperty<Authors>("Artist", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Performance.Director"/>
    /// </summary>
    public Authors Director
    {
      get { return GetExtraProperty<Authors>("Director"); }
      set { SetExtraProperty<Authors>("Director", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Performance.Writer"/>
    /// </summary>
    public Authors Writer
    {
      get { return GetExtraProperty<Authors>("Writer"); }
      set { SetExtraProperty<Authors>("Writer", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Performance.Performer"/>
    /// </summary>
    public Authors Performer
    {
      get { return GetExtraProperty<Authors>("Performer"); }
      set { SetExtraProperty<Authors>("Performer", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="SoundRecording.Composer"/>
    /// </summary>
    public Authors Composer
    {
      get { return GetExtraProperty<Authors>("Composer"); }
      set { SetExtraProperty<Authors>("Composer", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="SoundRecording.Conductor"/>
    /// </summary>
    public Authors Conductor
    {
      get { return GetExtraProperty<Authors>("Conductor"); }
      set { SetExtraProperty<Authors>("Conductor", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.Interviewer"/>
    /// </summary>
    public Authors Interviewer
    {
      get { return GetExtraProperty<Authors>("Interviewer"); }
      set { SetExtraProperty<Authors>("Interviewer", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.Interviewee"/>
    /// </summary>
    public Authors Interviewee
    {
      get { return GetExtraProperty<Authors>("Interviewee"); }
      set { SetExtraProperty<Authors>("Interviewee", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.Compiler"/>
    /// </summary>
    public Authors Compiler
    {
      get { return GetExtraProperty<Authors>("Compiler"); }
      set { SetExtraProperty<Authors>("Compiler", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Patent.Inventor"/>
    /// </summary>
    public Authors Inventor
    {
      get { return GetExtraProperty<Authors>("Inventor"); }
      set { SetExtraProperty<Authors>("Inventor", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Case.Councel"/>
    /// </summary>
    public Authors Councel
    {
      get { return GetExtraProperty<Authors>("Councel"); }
      set { SetExtraProperty<Authors>("Councel", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="BookSection.BookTitle"/>
    /// </summary>
    public string BookTitle
    {
      get { return GetExtraProperty<string>("BookTitle"); }
      set { SetExtraProperty<string>("BookTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="JournalArticle.JournalName"/>
    /// </summary>
    public string JournalName
    {
      get { return GetExtraProperty<string>("JournalName"); }
      set { SetExtraProperty<string>("JournalName", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="ArticleInAPeriodical.PeriodicalTitle"/>
    /// </summary>
    public string PeriodicalTitle
    {
      get { return GetExtraProperty<string>("PeriodicalTitle"); }
      set { SetExtraProperty<string>("PeriodicalTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="ConferenceProceedings.ConferenceName"/>
    /// </summary>
    public string ConferenceName
    {
      get { return GetExtraProperty<string>("ConferenceName"); }
      set { SetExtraProperty<string>("ConferenceName", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.InternetSiteTitle"/>
    /// </summary>
    public string InternetSiteTitle
    {
      get { return GetExtraProperty<string>("InternetSiteTitle"); }
      set { SetExtraProperty<string>("InternetSiteTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="ElectronicSource.PublicationTitle"/>
    /// </summary>
    public string PublicationTitle
    {
      get { return GetExtraProperty<string>("PublicationTitle"); }
      set { SetExtraProperty<string>("PublicationTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="SoundRecording.AlbumTitle"/>
    /// </summary>
    public string AlbumTitle
    {
      get { return GetExtraProperty<string>("AlbumTitle"); }
      set { SetExtraProperty<string>("AlbumTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.BroadcastTitle"/>
    /// </summary>
    public string BroadcastTitle
    {
      get { return GetExtraProperty<string>("BroadcastTitle"); }
      set { SetExtraProperty<string>("BroadcastTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Performance.Theater"/>
    /// </summary>
    public string Theater
    {
      get { return GetExtraProperty<string>("Theater"); }
      set { SetExtraProperty<string>("Theater", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.Station"/>
    /// </summary>
    public string Station
    {
      get { return GetExtraProperty<string>("Station"); }
      set { SetExtraProperty<string>("Station", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="BookSection.ChapterNumber"/>
    /// </summary>
    public string ChapterNumber
    {
      get { return GetExtraProperty<string>("ChapterNumber"); }
      set { SetExtraProperty<string>("ChapterNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Publisher"/>
    /// </summary>
    public string Publisher
    {
      get { return GetExtraProperty<string>("Publisher"); }
      set { SetExtraProperty<string>("Publisher", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.ProductionCompany"/>
    /// </summary>
    public string ProductionCompany
    {
      get { return GetExtraProperty<string>("ProductionCompany"); }
      set { SetExtraProperty<string>("ProductionCompany", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Film.Distributor"/>
    /// </summary>
    public string Distributor
    {
      get { return GetExtraProperty<string>("Distributor"); }
      set { SetExtraProperty<string>("Distributor", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Interview.Broadcaster"/>
    /// </summary>
    public string Broadcaster
    {
      get { return GetExtraProperty<string>("Broadcaster"); }
      set { SetExtraProperty<string>("Broadcaster", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Case.Court"/>
    /// </summary>
    public string Court
    {
      get { return GetExtraProperty<string>("Court"); }
      set { SetExtraProperty<string>("Court", value); }
    }


    /// <summary>
    /// Dostęp do właściwości <see cref="Case.Reporter"/>
    /// </summary>
    public string Reporter
    {
      get { return GetExtraProperty<string>("Reporter"); }
      set { SetExtraProperty<string>("Reporter", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.CountryRegion"/>
    /// </summary>
    public string CountryRegion
    {
      get { return GetExtraProperty<string>("CountryRegion"); }
      set { SetExtraProperty<string>("CountryRegion", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.StateProvince"/>
    /// </summary>
    public string StateProvince
    {
      get { return GetExtraProperty<string>("StateProvince"); }
      set { SetExtraProperty<string>("StateProvince", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.City"/>
    /// </summary>
    public string City
    {
      get { return GetExtraProperty<string>("City"); }
      set { SetExtraProperty<string>("City", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Case.CaseNumber"/>
    /// </summary>
    public string CaseNumber
    {
      get { return GetExtraProperty<string>("CaseNumber"); }
      set { SetExtraProperty<string>("CaseNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Case.AbbreviatedCaseNumber"/>
    /// </summary>
    public string AbbreviatedCaseNumber
    {
      get { return GetExtraProperty<string>("AbbreviatedCaseNumber"); }
      set { SetExtraProperty<string>("AbbreviatedCaseNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Misc.Edition"/>
    /// </summary>
    public string Edition
    {
      get { return GetExtraProperty<string>("Edition"); }
      set { SetExtraProperty<string>("Edition", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Issue"/>
    /// </summary>
    public string Issue
    {
      get { return GetExtraProperty<string>("Issue"); }
      set { SetExtraProperty<string>("Issue", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.Version"/>
    /// </summary>
    public string Version
    {
      get { return GetExtraProperty<string>("Version"); }
      set { SetExtraProperty<string>("Version", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.URL"/>
    /// </summary>
    public string URL
    {
      get { return GetExtraProperty<string>("URL"); }
      set { SetExtraProperty<string>("URL", value); }
    }


    /// <summary>
    /// Dostęp do właściwości <see cref="ElectronicSource.Medium"/>
    /// </summary>
    public string Medium
    {
      get { return GetExtraProperty<string>("Medium"); }
      set { SetExtraProperty<string>("Medium", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Volume"/>
    /// </summary>
    public string Volume
    {
      get { return GetExtraProperty<string>("Volume"); }
      set { SetExtraProperty<string>("Volume", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.NumberVolumes"/>
    /// </summary>
    public string NumberVolumes
    {
      get { return GetExtraProperty<string>("NumberVolumes"); }
      set { SetExtraProperty<string>("NumberVolumes", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="SoundRecording.RecordingNumber"/>
    /// </summary>
    public string RecordingNumber
    {
      get { return GetExtraProperty<string>("RecordingNumber"); }
      set { SetExtraProperty<string>("RecordingNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Patent.Type"/>
    /// </summary>
    public string Type
    {
      get { return GetExtraProperty<string>("Type"); }
      set { SetExtraProperty<string>("Type", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Patent.PatentNumber"/>
    /// </summary>
    public string PatentNumber
    {
      get { return GetExtraProperty<string>("PatentNumber"); }
      set { SetExtraProperty<string>("PatentNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Pages"/>
    /// </summary>
    public string Pages
    {
      get { return GetExtraProperty<string>("Pages"); }
      set { SetExtraProperty<string>("Pages", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="JournalArticle.Month"/>
    /// </summary>
    public string Month
    {
      get { return GetExtraProperty<string>("Month"); }
      set { SetExtraProperty<string>("Month", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="JournalArticle.Day"/>
    /// </summary>
    public string Day
    {
      get { return GetExtraProperty<string>("Day"); }
      set { SetExtraProperty<string>("Day", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.YearAccessed"/>
    /// </summary>
    public string YearAccessed
    {
      get { return GetExtraProperty<string>("YearAccessed"); }
      set { SetExtraProperty<string>("YearAccessed", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.MonthAccessed"/>
    /// </summary>
    public string MonthAccessed
    {
      get { return GetExtraProperty<string>("MonthAccessed"); }
      set { SetExtraProperty<string>("MonthAccessed", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="InternetSite.DayAccessed"/>
    /// </summary>
    public string DayAccessed
    {
      get { return GetExtraProperty<string>("DayAccessed"); }
      set { SetExtraProperty<string>("DayAccessed", value); }
    }
    /// <summary>
    /// Dostęp do właściwości <see cref="Report.ThesisType"/>
    /// </summary>
    public string ThesisType
    {
      get { return GetExtraProperty<string>("ThesisType"); }
      set { SetExtraProperty<string>("ThesisType", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Report.Department"/>
    /// </summary>
    public string Department
    {
      get { return GetExtraProperty<string>("Department"); }
      set { SetExtraProperty<string>("Department", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Report.Institution"/>
    /// </summary>
    public string Institution
    {
      get { return GetExtraProperty<string>("Institution"); }
      set { SetExtraProperty<string>("Institution", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.ShortTitle"/>
    /// </summary>
    public string ShortTitle
    {
      get { return GetExtraProperty<string>("ShortTitle"); }
      set { SetExtraProperty<string>("ShortTitle", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.StandardNumber"/>
    /// </summary>
    public string StandardNumber
    {
      get { return GetExtraProperty<string>("StandardNumber"); }
      set { SetExtraProperty<string>("StandardNumber", value); }
    }

    /// <summary>
    /// Dostęp do właściwości <see cref="Book.Comments"/>
    /// </summary>
    public string Comments
    {
      get { return GetExtraProperty<string>("Comments"); }
      set { SetExtraProperty<string>("Comments", value); }
    }


  }
}
