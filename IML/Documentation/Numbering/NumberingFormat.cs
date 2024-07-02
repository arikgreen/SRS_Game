using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Format numerowania
    /// </summary>
    public enum NumberingFormat
    {

        /// <summary>
        /// Wypunktowanie
        /// </summary>
        Bullet,

        /// <summary>
        /// 1, 2, 3
        /// </summary>
        Decimal,

        /// <summary>
        /// a, b, c
        /// </summary>
        LowerLetter,

        /// <summary>
        /// i, ii, iii
        /// </summary>
        LowerRoman,

        /// <summary>
        /// A, B, C
        /// </summary>
        UpperLetter,

        /// <summary>
        /// I, II, III
        /// </summary>
        UpperRoman
    }
}
