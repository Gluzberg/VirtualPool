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
    
    public partial class client_user
    {
        public client_user()
        {
            this.product = new HashSet<product>();
        }
    
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Product_Category_Id { get; set; }
    
        public virtual ICollection<product> product { get; set; }
        public virtual product_category product_category { get; set; }
    }
}