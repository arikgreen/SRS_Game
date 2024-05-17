using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Numerowanie abstrakcyjne
    /// </summary>
    public class AbstractNum : Item
    {
        /// <summary>
        /// Identyfikator liczbowy
        /// </summary>
        public new int Id { get; set; }

        /// <summary>
        /// Rodzaj numerowania wielpoziomowego
        /// </summary>
        public MultiLevelKind? Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, NumberingLevel> fLevels;

        /// <summary>
        /// Definicje poszczególnych poziomów
        /// </summary>
        public Dictionary<int, NumberingLevel> Levels
        {
            get
            {
                if (fLevels == null)
                    fLevels = new Dictionary<int, NumberingLevel>();
                return fLevels;
            }
            set
            {
                fLevels = value;
            }
        }
    }
}
