//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualPool.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class article
    {
        public article()
        {
            this.pool = new HashSet<pool>();
        }
    
        public string Id { get; set; }
        public int Product_Id { get; set; }
        public bool Active { get; set; }
    
        public virtual product product { get; set; }
        public virtual ICollection<pool> pool { get; set; }
    }
}