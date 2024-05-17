using System;

namespace Iml.Foundation
{
    /// <summary>
    /// Atrybut porzebny do oznaczenia typów które mogą występować w tabeli specyfikacji
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false,Inherited = true)]
    public partial class IsSpecificationTableType: Attribute
    {
        /// <summary>
        /// Konstruktor domyslny
        /// </summary>
        public IsSpecificationTableType()
        {
        }
    }
}
