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
    
    public partial class trim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trim()
        {
            this.inventories = new HashSet<inventory>();
        }
    
        public int trimID { get; set; }
        public string trimtype { get; set; }
        public Nullable<System.DateTime> trimtypeyear { get; set; }
        public Nullable<decimal> trimtypefactorycost { get; set; }
        public Nullable<int> trimtypemsrp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventory> inventories { get; set; }
    }
}