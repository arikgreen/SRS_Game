using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Typy wartości
  /// </summary>
  public enum ValueTypes
  {
    /// <summary>
    /// Dowolny typ
    /// </summary>
    Variant,
    /// <summary>
    /// Łańcuch znaków
    /// </summary>
    String,
    /// <summary>
    /// Podstawowy łańcuch znaków
    /// </summary>
    ShortString,
    /// <summary>
    /// Długi łańcuch znaków
    /// </summary>
    LongString,
    /// <summary>
    /// Typ boolean
    /// </summary>
    Bool,
    /// <summary>
    /// Typ całkowity
    /// </summary>
    Int,
    /// <summary>
    /// Typ całkowity 8-bitowy
    /// </summary>
    Int8,
    /// <summary>
    /// Typ całkowity 16-bitowy
    /// </summary>
    Int16,
    /// <summary>
    /// Typ całkowity 32-bitowy
    /// </summary>
    Int32,
    /// <summary>
    /// Typ całkowity 64-bitowy
    /// </summary>
    Int64,
    /// <summary>
    /// Typ całkowity bez znaku
    /// </summary>
    UInt,
    /// <summary>
    /// Typ całkowity bez znaku 8-bitowy
    /// </summary>
    UInt8,
    /// <summary>
    /// Typ całkowity bez znaku 16-bitowy
    /// </summary>
    UInt16,
    /// <summary>
    /// Typ całkowity bez znaku 32-bitowy
    /// </summary>
    UInt32,
    /// <summary>
    /// Typ całkowity bez znaku 64-bitowy
    /// </summary>
    UInt64,
    /// <summary>
    /// Typ rzeczywisty 32-bitowy
    /// </summary>
    Float,
    /// <summary>
    /// Typ rzeczywisty 64-bitowy
    /// </summary>
    Double,
    /// <summary>
    /// Typ walutowy
    /// </summary>
    Currency,
    /// <summary>
    /// Typ dziesiętny
    /// </summary>
    Decimal,
    /// <summary>
    /// Typ daty i czasu
    /// </summary>
    DateTime,
    /// <summary>
    /// Znacznik czasu
    /// </summary>
    Timestamp,
    /// <summary>
    /// Identyfikator klasy
    /// </summary>
    Guid,
    /// <summary>
    /// Kod błędu
    /// </summary>
    ErrorCode,
    /// <summary>
    /// Typ pusty
    /// </summary>
    Empty,
    /// <summary>
    /// Typ wskaźnikowy pusty
    /// </summary>
    Null,
    /// <summary>
    /// Typ tablicowy
    /// </summary>
    Array,
    /// <summary>
    /// Typ wektorowy
    /// </summary>
    Vector,
    /// <summary>
    /// Blok binarny
    /// </summary>
    Blob,
    /// <summary>
    /// Obiekowy blok binarny
    /// </summary>
    ObjectBlob,
    /// <summary>
    /// Pamięć binarna
    /// </summary>
    Storage,
    /// <summary>
    /// Obiektowa pamięć binarna
    /// </summary>
    ObjectStorage,
    /// <summary>
    /// Strumień binarny
    /// </summary>
    StreamData,
    /// <summary>
    /// Obiektowy strumień binarny
    /// </summary>
    ObjectStreamData,
    /// <summary>
    /// Wersjonowany strumień binarny
    /// </summary>
    VersionedStreamData,
    /// <summary>
    /// Zawartość schowka
    /// </summary>
    ClipboardData,
    /// <summary>
    /// Typ liczby porządkowej - musi mieć odpowiedni format
    /// </summary>
    OrdNumber,
  }

}
