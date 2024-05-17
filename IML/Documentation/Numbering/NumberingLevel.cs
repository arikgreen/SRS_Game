using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
    /// <summary>
    /// Typ wyrównania
    /// </summary>
    public enum LevelJustification 
    {
        /// <summary>
        /// Wyrównanie do lewej
        /// </summary>
        Left,

        /// <summary>
        /// Wyrównanie do środka
        /// </summary>
        Center,

        /// <summary>
        /// Wyrównanie do prawej
        /// </summary>
        Right
    }

    /// <summary>
    /// Definicja poziomu numerowania
    /// </summary>
    public class NumberingLevel 
    {
        /// <summary>
        /// Numer poziomu
        /// </summary>
        public int ItemLevel { get; set; }

        /// <summary>
        /// Format numerowania
        /// </summary>
        [DefaultValue(null)]
        public NumberingFormat Format { get; set; }

        /// <summary>
        /// Wartość początkowa
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Tekst punktora
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Wyrównanie punktora
        /// </summary>
        public LevelJustification Justification { get; set; }

        /// <summary>
        /// Specyfikuje czcionkę, która ma być użyta do znaków
        /// z zakresu Unicode
        /// </summary>
        public string Ascii { get; set; }

        /// <summary>
        /// Specyfukuje czcionkę, która ma być użyta do znaków
        /// spoza zakresu obejmowanych przez Ascii, Complex Script i EastAsia
        /// </summary>
        public string HighAnsi { get; set; }

        /// <summary>
        /// Specyfikuje, który typ ma być użyty dla znaków
        /// należących do kilku zakresów
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Odstęp z lewej
        /// </summary>
        [DefaultValue(null)]
        public string LeftIndent { get; set; }

        /// <summary>
        /// Odstęp z prawej
        /// </summary>
        [DefaultValue(null)]
        public string RightIndent { get; set; }

        /// <summary>
        /// Wysunięcie pierwszej linii
        /// </summary>
        [DefaultValue(null)]
        public string HangingIndent { get; set; }
    }
}
