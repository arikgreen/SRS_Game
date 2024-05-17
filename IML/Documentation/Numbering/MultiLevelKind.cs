using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Rodzaj numerowania wielozpoziomowego
    /// </summary>
    public enum MultiLevelKind
    {

        /// <summary>
        /// Numerowanie jednopoziomowe
        /// </summary>
        SingleLevel,

        /// <summary>
        /// Numerowanie wielopoziomowe
        /// </summary>
        MultiLevel,

        /// <summary>
        /// Numerowanie wielopoziomowe mieszane (numerowane lub wypunktowane)
        /// </summary>
        HybridMultiLevel
    };
}
