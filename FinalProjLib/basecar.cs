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
    
    public partial class basecar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public basecar()
        {
            this.inventories = new HashSet<inventory>();
        }
    
        public int basecarID { get; set; }
        public string vin { get; set; }
        public string basecarmodel { get; set; }
        public Nullable<System.DateTime> basecarmodelyear { get; set; }
        public Nullable<decimal> basecarmodelfactorycost { get; set; }
        public Nullable<decimal> basecarmodelmsrp { get; set; }
        public Nullable<bool> sold { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventory> inventories { get; set; }
    }
}
