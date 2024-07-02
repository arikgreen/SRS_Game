using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation.Drawings
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Anchor : Item
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Anchor()
        {
            // rysunek zawiera zawsze jedno zakotwiczenie
            Id = "1";
        }

        /// <summary>
        /// Odległość górnej krawędzi od tekstu
        /// </summary>
        public int DistanceTop { get; set; }

        /// <summary>
        /// Odległość dolnej krawędzi od tekstu
        /// </summary>
        public int DistanceBottom { get; set; }

        /// <summary>
        /// Odległość lewej krawędzi od tekstu
        /// </summary>
        public int DistanceLeft { get; set; }

        /// <summary>
        /// Odległość prawej krawędzi od tekstu
        /// </summary>
        public int DistanceRight { get; set; }

        /// <summary>
        /// Czy pozycjonowane na stronie
        /// </summary>
        public bool SimplePos { get; set; }

        /// <summary>
        /// Relatywna pozycja w sortowaniu na osi Z
        /// </summary>
        public int RelativeHeight { get; set; }
        
        /// <summary>
        /// Czy rysunek będzie wyświetlany za tekstem dokumentu
        /// </summary>
        public bool BehindDoc { get; set; }

        /// <summary>
        /// Czy zakotwiczenie jest zablokowane
        /// </summary>
        [DefaultValue(false)]
        public bool Locked { get; set; }

        /// <summary>
        /// Czy
        /// </summary>
        [DefaultValue(false)]
        public bool LayoutInCell { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public bool AllowOverlap { get; set; }

        /// <summary>
        /// Identyfikator zakotwiczenia rysunku
        /// </summary>
        [DefaultValue(null)]
        public string AnchorId { get; set; }

        /// <summary>
        /// Identyfikator edycji rysunku
        /// </summary>
        [DefaultValue(null)]
        public string EditId { get; set; }

        /// <summary>
        /// Prosta pozycja(X, Y)
        /// </summary>
        [DefaultValue(null)]
        public SimplePosition SimplePosition { get; set; }

        /// <summary>
        /// Pozycja werykalna
        /// </summary>
        [DefaultValue(null)]
        public Position VerticalPosition { get; set; }

        /// <summary>
        /// Pozycja horyzontalna
        /// </summary>
        [DefaultValue(null)]
        public Position HorizontalPosition { get; set; }

    }
}
