//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProjLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inventory()
        {
            this.sales = new HashSet<sale>();
        }
    
        public int inventoryID { get; set; }
        public Nullable<int> basecarID { get; set; }
        public Nullable<int> trimID { get; set; }
    
        public virtual basecar basecar { get; set; }
        public virtual trim trim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale> sales { get; set; }
    }
}
