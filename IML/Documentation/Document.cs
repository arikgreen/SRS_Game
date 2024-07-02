using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Iml.Foundation;
using Iml.Documentation;
using Iml.Documentation.Drawings;
using Iml.Documentation.Bibliography;
using Iml.Modeling;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca dokument projektowy. 
  /// Dokument zawiera bloki tekstu oraz sekcje (rozdziały i podrozdziały).
  /// Elementy, do których występują odwołania w tekście,
  /// są dołączone do dokumentu.
  /// </summary>
  [DataContract]
  public partial class Document : ProjectElement
  {
    /// <summary>
    /// Konstruktor dokumentu. Tworzy niezbędne listy.
    /// </summary>
    public Document ()
    {
    }

    #region właściwości główne dokumentu

    //protected string language;
    ///// <summary>
    ///// Język, w którym dokument został sporządzony.
    ///// </summary>
    //[XmlAttribute ("Language")]
    //[DefaultValue (null)]
    //[DataMember]
    //[DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
    //public new string Language { get { return language; } set { language = value; } }

    /// <summary>
    /// Nazwa pliku, w którym dokument został zapisany
    /// </summary>
    [XmlAttribute ("Filename")]
    [DataMember]
    [DefaultValue (null)]
    public string Filename { get; set; }

    /// <summary>
    /// Symbol projektu (niekoniecznie RefID!), którego dotyczy dokument
    /// </summary>
    [XmlAttribute ("ProjectSymbol")]
    [DataMember]
    [DefaultValue (null)]
    public string ProjectSymbol 
    {
      get { return fProjectSymbol; }
      set
      {
        if (fProjectSymbol != value)
        {
          fProjectSymbol = value;
          NotifyPropertyChanged("ProjectSymbol");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące symbol (akronim) projektu
    /// </summary>
    protected string fProjectSymbol;

    /// <summary>
    /// Nazwa projektu, którego dotyczy dokument
    /// </summary>
    [XmlElement ("ProjectName")]
    [DataMember]
    [DefaultValue (null)]
    public string ProjectName 
    {
      get { return fProjectName; }
      set
      {
        if (fProjectName != value)
        {
          fProjectName = value;
          NotifyPropertyChanged("ProjectName");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące nazwę projektu
    /// </summary>
    protected string fProjectName;

/*
    /// <summary>
    /// Nazwa dokumentu (wewnętrzna)
    /// </summary>
    [XmlElement ("DocumentName")]
    [DataMember]
    [DefaultValue (null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string DocumentName { get { return Name; } set { Name = value; } }
*/
    /// <summary>
    /// Tytuł dokumentu (do prezentacji)
    /// </summary>
    [XmlAttribute ("Title")]
    [DataMember]
    [DefaultValue (null)]
    public string Title 
    {
      get { return fTitle; }
      set
      {
        if (fTitle != value)
        {
          fTitle = value;
          NotifyPropertyChanged("Title");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące tytuł dokumentu
    /// </summary>
    protected string fTitle;

    /// <summary>
    /// Identyfikator referencyjny elementu. W odróżnieniu od ID
    /// jest unikatowy tylko w ramach listy elementów należących
    /// do pewnego elementu właścicielskiego. Za to jest czytelny
    /// dla człowieka.
    /// </summary>
    [XmlAttribute("RefID")]
    [DefaultValue(null)]
    public string RefID 
    {
      get { return fRefID; }
      set
      {
        if (fRefID != value)
        {
          fRefID = value;
          NotifyPropertyChanged("RefID");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące identyfikator referencyjny dokumentu
    /// </summary>
    protected string fRefID;
    /// <summary>
    /// Który to zapisu dokumentu.
    /// </summary>
    [XmlAttribute("Revision")]
    [DefaultValue(0)]
    public int Revision 
    {
      get { return fRevision; }
      set
      {
        if (fRevision != value)
        {
          fRevision = value;
          NotifyPropertyChanged("Revision");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące nr rewizji dokumentu
    /// </summary>
    protected int fRevision;

    /// <summary>
    /// Data/czas utworzenia dokumentu
    /// </summary>
    [XmlAttribute("CreatedAt")]
    [DefaultValue(null)]
    public Date CreatedAt 
    {
      get { return fCreatedAt; }
      set
      {
        if (fCreatedAt != value)
        {
          fCreatedAt = value;
          NotifyPropertyChanged("CreatedAt");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące datę utworzenia dokumentu
    /// </summary>
    protected Date fCreatedAt;

    /// <summary>
    /// Id autora odpowiedzialnego za dokument
    /// </summary>
    [XmlAttribute("OwnedBy")]
    [DefaultValue(null)]
    public string OwnedBy 
    {
      get { return fOwnedBy; }
      set
      {
        if (fOwnedBy != value)
        {
          fOwnedBy = value;
          NotifyPropertyChanged("OwnedBy");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące Id właściela dokumentu
    /// </summary>
    protected string fOwnedBy;

    /// <summary>
    /// Data/czas ostatniej modyfikacji dokumentu
    /// </summary>
    [XmlAttribute("ModifiedAt")]
    [DefaultValue(null)]
    public Date ModifiedAt 
    {
      get { return fModifiedAt; }
      set
      {
        if (fModifiedAt != value)
        {
          fModifiedAt = value;
          NotifyPropertyChanged("ModifiedAt");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące datę modyfikacji
    /// </summary>
    protected Date fModifiedAt;

    /// <summary>
    /// Id autora, który dokonał ostatniej modyfikacji dokumentu
    /// </summary>
    [XmlAttribute("ModifiedBy")]
    [DefaultValue(null)]
    public string ModifiedBy 
    {
      get { return fModifiedBy; }
      set
      {
        if (fModifiedBy != value)
        {
          fModifiedBy = value;
          NotifyPropertyChanged("ModifiedBy");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące Id autora modyfikacji
    /// </summary>
    protected string fModifiedBy;

    /// <summary>
    /// Status dokumentu
    /// </summary>
    [DefaultValue(null)]
    public string Status { get; set; }

    /// <summary>
    /// Dodatkowa właściwość oznaczające kategorię dokumentu
    /// </summary>
    public string Category {get; set;}

    /// <summary>
    /// Numer iteracji projektu, z której został pobrany ten dokument
    /// (wypełniany przez IMACStorage)
    /// </summary>
    [XmlAttribute ("Iteration")]
    [DataMember]
    [DefaultValue (0)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public int Iteration
    {
      get { return fIteration; }
      set
      {
        if (fIteration != value)
        {
          fIteration = value;
          NotifyPropertyChanged("Iteration");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące iterację projektu
    /// </summary>
    protected int fIteration;

    /// <summary>
    /// Numer fazy projektowej, z której został pobrany ten dokument
    /// (wypełniany przez IMACStorage)
    /// </summary>
    [XmlAttribute ("Phase")]
    [DataMember]
    [DefaultValue (0)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public int Phase 
    {
      get { return fPhase; }
      set
      {
        if (fPhase != value)
        {
          fPhase = value;
          NotifyPropertyChanged("Phase");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące fazę procesu wytwarzania
    /// </summary>
    protected int fPhase;

    /// <summary>
    /// Identyfikator kubełka, do którego należy dokument
    /// (wypełniany przez IMACStorage)
    /// </summary>
    [XmlAttribute ("Bucket")]
    [DataMember]
    [DefaultValue (null)]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public string Bucket 
    {
      get { return fBucket; }
      set
      {
        if (fBucket != value)
        {
          fBucket = value;
          NotifyPropertyChanged("Bucket");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące Id koszyka dokumentu
    /// </summary>
    protected string fBucket;

    /// <summary>
    /// Aktualna wersja/wydanie dokumentu
    /// (wypełniany przez IMACStorage, ale też przez IMACStorage czytany)
    /// </summary>
    [XmlAttribute ("Version")]
    [DataMember]
    [DefaultValue (null)]
    public string Version 
    {
      get { return fVersion; }
      set
      {
        if (fVersion != value)
        {
          fVersion = value;
          NotifyPropertyChanged("Version");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące wersję dokumentu
    /// </summary>
    protected string fVersion;
    /// <summary>
    /// Data ostatniej modyfikacji dokumentu.
    /// </summary>
    [XmlAttribute ("LastModified")]
    [DataMember]
    public DateTime LastModified 
    {
      get { return fLastModified; }
      set
      {
        if (fLastModified != value)
        {
          fLastModified = value;
          NotifyPropertyChanged("LastModified");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące czas ostatniej modyfikacji
    /// </summary>
    protected DateTime fLastModified;

    /// <summary>
    /// Funkcja wymagana przez serializer
    /// </summary>
    public bool ShouldSerializeLastModified () { return LastModified != new DateTime (); }

    #endregion

    #region właściwości dodatkowe dokumentu
    /// <summary>
    ///  Właściwości dokumentu
    /// </summary>
    public Properties Properties
    {
      get 
      {
        if (fProperties == null)
          fProperties = new Properties(this);
        return fProperties; 
      }
      set { fProperties = value; if (value != null) value.SetOwner (this); }
    }
    /// <summary>
    /// Pole przechowujące listę właściwości dokumentu
    /// </summary>
    protected Properties fProperties;
    /// <summary>
    /// Właściwości dokumentu będą serializowane tylko wtedy, gdy lista właściwości nie jest pusta.
    /// </summary>
    public bool ShouldSerializeProperties ()
    {
      return fProperties != null && !fProperties.IsEmpty ();
    }
    #endregion

    #region właściwości statystyczne dokumentu
    /// <summary>
    ///  Statystyka dokumentu
    /// </summary>
    public Properties Statistics
    {
      get
      {
        if (fStatistics == null)
          fStatistics = new Properties(this);
        return fStatistics;
      }
      set { fStatistics = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę właściwości dokumentu
    /// </summary>
    protected Properties fStatistics;
    /// <summary>
    /// Właściwości dokumentu będą serializowane tylko wtedy, gdy lista właściwości nie jest pusta.
    /// </summary>
    public bool ShouldSerializeStatistics ()
    {
      return fStatistics != null && !fStatistics.IsEmpty();
    }
    #endregion

    #region lista autorów
    /// <summary>
    ///  Lista autorów dokumentu
    /// </summary>
    [DataMember]
    [Association("Author", "ID", "OwnerID")]
    [XmlArray("Authors")]
    [XmlArrayItem("Author", Type = typeof(Author))]
    public AuthorList Authors
    {
      get {
        if (fAuthors == null)
          fAuthors = new AuthorList(this);
        return fAuthors; 
      }
      //set { authors = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę autorów dokumentu
    /// </summary>
    protected AuthorList fAuthors;
    #endregion

    /// <summary>
    /// Lista autorów będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeAuthors()
    {
      return fAuthors != null && fAuthors.Count != 0;
    }

    /// <summary>
    /// Lista rewizji dokumentu (określają kiedy co było zmienione)
    /// </summary>
    public Revisions Revisions
    {
      get
      {
        if (fRevisions == null)
          fRevisions = new Revisions(this);
        return fRevisions;
      }
      set
      {
        fRevisions = value; if (value != null) value.SetOwner(this);
      }
    }
    /// <summary>
    /// Pole przechowujące rewizje dokumentu
    /// </summary>
    protected Revisions fRevisions;

    /// <summary>
    /// Czy rewizje mają być serializowane
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeRevisions()
    {
      return fRevisions != null && !fRevisions.IsEmpty();
    }

    /// <summary>
    ///  Domyślne formaty dokumentu
    /// </summary>
    [DataMember]
    [Association("DefaultFormats", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Formats DefaultFormats
    {
      get 
      {
        if (fDefaultFormats == null)
          fDefaultFormats = new Formats(this);
        return fDefaultFormats; 
      }
      set { fDefaultFormats = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące domyślne formaty dokumentu
    /// </summary>
    protected Formats fDefaultFormats;

    /// <summary>
    /// Czy domyślne formaty dokumentu mają być serializowane
    /// </summary>
    public bool ShouldSerializeDefaultFormats ()
    {
      return fDefaultFormats != null && !fDefaultFormats.IsEmpty();
    }

    /// <summary>
    ///  Definicje czcionek używanych w dokumencie
    /// </summary>
    [DataMember]
    [Association("FontScheme", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public FontScheme FontScheme
    {
      get { return fFontScheme; }
      set { fFontScheme = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    ///  Pole przechowujące definicje czcionek używanych w dokumencie
    /// </summary>
    protected FontScheme fFontScheme;

    /// <summary>
    /// Czy definicje czcionek mają być serializowane
    /// </summary>
    public bool ShouldSerializeFontScheme ()
    {
      return fFontScheme != null && !fFontScheme.IsEmpty();
    }

    /// <summary>
    ///  Definicje kolorów używanych w dokumencie
    /// </summary>
    [DataMember]
    [Association("ColorSchemes", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ColorScheme ColorScheme
    {
      get { return fColorScheme; }
      set { fColorScheme = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    ///  Pole przechowujące definicje kolorów używanych w dokumencie
    /// </summary>
    protected ColorScheme fColorScheme;

    /// <summary>
    /// Czy definicje kolorów używanych w dokumencie mają być serializowane
    /// </summary>
    public bool ShouldSerializeColorScheme ()
    {
      return fColorScheme != null && !fColorScheme.IsEmpty();
    }

    /// <summary>
    ///  Odwzorowanie kolorów w dokumencie
    /// </summary>
    [DataMember]
    [Association("ColorSchemeMap", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ColorSchemeMap ColorSchemeMap
    {
      get 
      {
        if (fColorSchemeMap == null)
          fColorSchemeMap = new ColorSchemeMap(this);
        return fColorSchemeMap; 
      }
      //set { colorSchemeMap = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące odwzorowanie kolorów w dokumencie
    /// </summary>
    protected ColorSchemeMap fColorSchemeMap;
    
    /// <summary>
    /// Schematy będą serializowane tylko wtedy, gdy lista nie jest pusta.
    /// </summary>
    public bool ShouldSerializeColorSchemeMap ()
    {
      return fColorSchemeMap != null && !fColorSchemeMap.IsEmpty();
    }

    /// <summary>
    ///  Lista stylów graficznych dokumentu
    /// </summary>
    [DataMember]
    [Association("GraphicStyles", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public GraphicScheme GraphicStyles
    {
      get 
      {
        if (fGraphicStyles == null)
          fGraphicStyles = new GraphicScheme { Owner = this };
        return fGraphicStyles; 
      }
      set { fGraphicStyles = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę stylów graficznych dokumentu
    /// </summary>
    protected GraphicScheme fGraphicStyles;

    /// <summary>
    /// Czy lista stylów graficznych ma być serializowana
    /// </summary>
    public bool ShouldSerializeGraphicStyles ()
    {
      return fGraphicStyles != null && !fGraphicStyles.IsEmpty();
    }

    /// <summary>
    ///  Lista stylów dokumentu
    /// </summary>
    [DataMember]
    [Association ("Style", "ID", "OwnerID")]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    public StyleList Styles
    {
      get 
      {
        if (fStyles == null)
          fStyles = new StyleList(this);
        return fStyles; 
      }
      set { fStyles = value; if (value != null) value.SetOwner (this); }
    }
    /// <summary>
    /// Pole przechowujące listę stylów
    /// </summary>
    protected StyleList fStyles;

    /// <summary>
    /// Lista stylów będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeStyles()
    {
        return fStyles != null && !fStyles.IsEmpty();
    }

    /// <summary>
    /// Definicja numeracji używanych w dokumencie
    /// </summary>
    [DataMember]
    [Association("Numbering", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Numbering Numbering
    {
        get
        {
            if (fNumbering == null)
                fNumbering = new Numbering();
            return fNumbering;
        }

        set { fNumbering = value; }
    }

    /// <summary>
    /// Pole przechowujące definicję numeracji używanych w dokumencie
    /// </summary>
    protected Numbering fNumbering;

    /// <summary>
    /// Definicja numeracji będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeNumbering()
    {
        return fNumbering != null && (!fNumbering.AbstractNums.IsEmpty() || !fNumbering.NumInstances.IsEmpty());
    }

    /// <summary>
    /// Lista tabeli specyfikacji
    /// </summary>
    [DataMember]
    [Association("SpecificationTables", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SpecificationTableList SpecificationTables
    {
        get
        {
            if (fSpecificationTables == null)
                fSpecificationTables = new SpecificationTableList();
            return fSpecificationTables;
        }

        set { fSpecificationTables = value; }
    }

    /// <summary>
    /// Pole przechowujące listę tabeli specyfikacji
    /// </summary>
    protected SpecificationTableList fSpecificationTables;

    /// <summary>
    /// Lista tabeli specyfikacji będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeSpecificationTables()
    {
        return fSpecificationTables != null && !fSpecificationTables.IsEmpty();
    }

    /// <summary>
    ///  Lista stylów ukrytych dokumentu
    /// </summary>
    [DataMember]
    [Association("LatentStyle", "ID", "OwnerID")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public StyleList LatentStyles
    {
      get
      {
        if (fLatentStyles == null)
          fLatentStyles = new StyleList(this);
        return fLatentStyles;
      }
      set { fLatentStyles = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące style ukryte
    /// </summary>
    protected StyleList fLatentStyles;


    /// <summary>
    /// Lista stylów będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeLatentStyles()
    {
        return fLatentStyles != null && !fLatentStyles.IsEmpty();
    }

    /// <summary>
    ///  Lista części dokumentu
    /// </summary>
    //[DataMember]
    ////[Association("Style", "ID", "OwnerID")]
    //[Composition]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DocParts DocParts
    {
      get 
      {
        if (fDocParts == null)
          fDocParts = new DocParts(this);
        return fDocParts; 
      }
      set { fDocParts = value; if (value != null) value.SetOwner (this); }
    }
    /// <summary>
    /// Pole przechowujące listę części dokumentu
    /// </summary>
    protected DocParts fDocParts;

    /// <summary>
    /// Czy lista części dokumentu
    /// </summary>
    public bool ShouldSerializeDocParts ()
    {
      return fDocParts != null && !fDocParts.IsEmpty();
    }

    /// <summary>
    /// Historia zmian dokumentu
    /// </summary>
    public History History 
    { 
      get 
      {
        if (fHistory == null)
          fHistory = new History(this);
        return fHistory; 
      }
      set { fHistory = value; if (value == null) value.SetOwner(this); }
    }

    /// <summary>
    /// Pole przechowujące historię zmian dokumentu
    /// </summary>
    protected History fHistory;

    /// <summary>
    /// Historia będzie serializowana tylko wtedy, gdy nie jest pusta.
    /// </summary>
    public bool ShouldSerializeHistory()
    {
      return fHistory != null && !fHistory.IsEmpty();
    }

    /// <summary>
    /// Ciało dokumentu - lista bloków
    /// </summary>
    public Body Body 
    { 
      get 
      {
        if (fBody == null)
          fBody = new Body(this);
        return fBody; 
      }
      set 
      { fBody = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące ciało dokumentu
    /// </summary>
    protected Body fBody;

    /// <summary>
    /// Czy ciało dokumentu ma być serializowane
    /// </summary>
    public bool ShouldSerializeBody ()
    {
      return fBody != null && !fBody.IsEmpty ();
    }

    /// <summary>
    /// Lista sekcji (rozdziałów)
    /// </summary>
    [DataMember]
    [Association ("DocumentSections", "ID", "OwnerID")]
    public Sections Sections 
    { 
      get 
      {
        if (fSections == null)
          fSections = new Sections(this);
        return fSections; 
      }
      set { fSections = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę sekcji dokumentu
    /// </summary>
    protected Sections fSections;

    /// <summary>
    /// Lista sekcji będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeSections ()
    {
      return Sections != null && !Sections.IsEmpty ();
    }

    /// <summary>
    /// Lista przypisów dolnych
    /// </summary>
    [DataMember]
    [Association("DocumentFootnotes", "ID", "OwnerID")]
    public ContentList Footnotes
    {
      get
      {
        if (fFootnotes == null)
          fFootnotes = new ContentList(this);
        return fFootnotes;
      }
      set { fFootnotes = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę przypisów dolnych
    /// </summary>
    protected ContentList fFootnotes;

    /// <summary>
    /// Czy lista przypisów dolnych ma być serializowana
    /// </summary>
    public bool ShouldSerializeFootnotes ()
    {
      return fFootnotes != null && !fFootnotes.IsEmpty();
    }

    /// <summary>
    /// Lista przypisów końcowych
    /// </summary>
    [DataMember]
    [Association("DocumentEndnotes", "ID", "OwnerID")]
    public ContentList Endnotes
    {
      get
      {
        if (fEndnotes == null)
          fEndnotes = new ContentList(this);
        return fEndnotes;
      }
      set { fEndnotes = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące Listę przypisów końcowych
    /// </summary>
    protected ContentList fEndnotes;

    /// <summary>
    /// Czy lista przypisów końcowych ma być serializowana
    /// </summary>
    public bool ShouldSerializeEndnotes ()
    {
      return fEndnotes != null && !fEndnotes.IsEmpty();
    }

    /// <summary>
    /// Lista stopek
    /// </summary>
    [DataMember]
    [Association("DocumentFooters", "ID", "OwnerID")]
    public Footers Footers
    {
      get
      {
        if (fFooters == null)
          fFooters = new Footers(this);
        return fFooters;
      }
      set { fFooters = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę stopek
    /// </summary>
    protected Footers fFooters;
    /// <summary>
    /// Czy lista stopek ma być serializowana
    /// </summary>
    public bool ShouldSerializeFooters ()
    {
      return fFooters != null && !fFooters.IsEmpty();
    }

    /// <summary>
    /// Lista stopek
    /// </summary>
    [DataMember]
    [Association("DocumentSources", "ID", "OwnerID")]
    public Sources BibliographySources
    {
      get
      {
        if (fSources == null)
          fSources = new Sources(this);
        return fSources;
      }
      set { fSources = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę stopek
    /// </summary>
    protected Sources fSources;
    /// <summary>
    /// Czy lista stopek ma być serializowana
    /// </summary>
    public bool ShouldSerializeSources ()
    {
      return fSources != null && !fSources.IsEmpty();
    }

    /// <summary>
    /// Lista nagłówków
    /// </summary>
    [DataMember]
    [Association("DocumentHeaders", "ID", "OwnerID")]
    public Headers Headers
    {
      get
      {
        if (fHeaders == null)
          fHeaders = new Headers(this);
        return fHeaders;
      }
      set { fHeaders = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę nagłówków
    /// </summary>
    protected Headers fHeaders;
    /// <summary>
    /// Czy lista nagłówków ma być serializowana
    /// </summary>
    public bool ShouldSerializeHeaders ()
    {
      return fHeaders != null && !fHeaders.IsEmpty();
    }

    /// <summary>
    /// Lista obrazów z dokumentu
    /// </summary>
    //[DefaultValue(null)]
    public ImageList Images
    {
      get
      {
        if (fImages == null)
          fImages = new ImageList(this);
        return fImages;
      }
      set { fImages = value; if (value != null) value.SetOwner(this); }
    }
    /// <summary>
    /// Pole przechowujące listę obrazów
    /// </summary>
    protected ImageList fImages;

    /// <summary>
    /// Czy lista obrazów ma być serializowana
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeImages()
    {
      return fImages != null && !fImages.IsEmpty();
    }

    /// <summary>
    /// Lista elementów semantycznych
    /// </summary>
    [DataMember]
    [Association ("DocumentCustomXmlParts", "ID", "OwnerID")]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    public CustomXmlParts CustomXmlParts
    {
      get 
      {
        if (fCustomXmlParts == null)
          fCustomXmlParts = new CustomXmlParts(this);
        return fCustomXmlParts; 
      }
      set { fCustomXmlParts = value; if (value!=null) value.SetOwner(this); } 
    }
    /// <summary>
    /// Pole przechowujące listę elementów semantycznych
    /// </summary>
    protected CustomXmlParts fCustomXmlParts;

    /// <summary>
    /// Lista elementów będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeCustomXmlParts ()
    {
      return CustomXmlParts != null && CustomXmlParts.Count > 0;
    }

    /// <summary>
    /// Lista modeli semantycznych
    /// </summary>
    [DataMember]
    [Association ("DocumentElements", "ID", "OwnerID")]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
    public Metamodels Models
    {
      get 
      {
        if (fModels == null)
          fModels = new Metamodels(this);
        return fModels; 
      }
      set { fModels = value; if (value!=null) value.SetOwner(this); } 
    }
    /// <summary>
    /// Pole przechowujące listę modeli semantycznych
    /// </summary>
    protected Metamodels fModels;

    /// <summary>
    /// Lista modeli będzie serializowana tylko wtedy, gdy lista ta nie jest pusta.
    /// </summary>
    public bool ShouldSerializeModels ()
    {
      return fModels != null && fModels.Count > 0;
    }


    /// <summary>
    /// Klucz dostępu przekazywany pomiędzy serwerem a klientem
    /// </summary>
    [DataMember]
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public string AccessKey { get; set; }
  }
}
