using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Organization
{
    /// <summary>
    /// Typ wyliczeniowy reprezentujący status dokumentu
    /// </summary>
    public enum DocumentStatus : byte 
    {
      /// <summary>
      /// Szkic (stan początkowy)
      /// </summary>
      Draft,
      /// <summary>
      /// Propozycja (do zatwierdzenia)
      /// </summary>
      Proposition,
      /// <summary>
      /// Sprawdzony
      /// </summary>
      Checked,
      /// <summary>
      /// Zaakceptowany
      /// </summary>
      Accepted,
      /// <summary>
      /// Odrzucony
      /// </summary>
      Rejected,
      /// <summary>
      /// Zamknięty
      /// </summary>
      Final
    }
}
