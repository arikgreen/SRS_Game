using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa pomocnicza tworząca identyfikator globalnie unikatowy (GUID) z dowolnego unikatowego łańcucha
  /// </summary>
  public static class GuidGenerator
  {
    /// <summary>
    /// Klucz mieszania stały dla wszystkich instancji
    /// zapewnia powtarzalność funkcji mieszania.
    /// </summary>
    static byte[] sKey = new byte[] { 
      0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 
      0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
      0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0106, 0x17, 
      0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
      0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 
      0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
      0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 
      0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F};
    /// <summary>
    /// Algorytm oparty na MD5 daje wynik 128 bitowy
    /// </summary>
    static HMAC hashAlgorithm = new HMACMD5 (sKey);

    /// <summary>
    ///  Funkcja podająca identyfikator typu GUID dla unikatowego łańcucha znaków.
    ///  Identyfikator jest obliczany przez funkcję mieszającą
    /// </summary>
    public static Guid HashString (string str)
    {
      byte[] result = hashAlgorithm.ComputeHash (UTF8Encoding.UTF8.GetBytes (str));
      return new Guid (result);
    }
  }
}
