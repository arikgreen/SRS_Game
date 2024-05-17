using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca tablicę specyfikacji elementu.
  /// Ponieważ jest ona elementem prezentacyjnym (dziedziczy po <see cref="PresentationElement"/>),
  /// a jednocześnie jest elementem dokumentu, więc samodzielnie implementuje 
  /// interfejs <see cref="IDocumentItem"/>
  /// </summary>
  [CanContain(typeof(TableRow),Ordered=true,GroupName="Rows")]
  public partial class SpecificationTable: PresentationElement, IDocumentItem
  {
      
    /// <summary>
    /// Odwołanie do dokumentu, który zawiera tę tablicę
    /// </summary>
      public Document Document
      {
          get
          {
              object aOwner = Owner;
              while (aOwner != null && !(aOwner is Document))
              {
                  if (aOwner is Element)
                      aOwner = (aOwner as Element).Owner;
                  else
                      aOwner = null;
              }
              return aOwner as Document;
              
          }
      }

      /// <summary>
      /// Definicje wierszy tabeli
      /// </summary>
      public SpecificationTableRows Rows {
          get
          {
              if (fRows == null)
                  fRows = new SpecificationTableRows();
              return fRows;
          }
          set
          {
              fRows = value;
          } 
      }

      /// <summary>
      /// Pole przechowujące listę wierszy tabeli specyfikacji
      /// </summary>
      private SpecificationTableRows fRows;
  }
}
