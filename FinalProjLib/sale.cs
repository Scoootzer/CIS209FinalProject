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
    
    public partial class sale
    {
        public int salesID { get; set; }
        public Nullable<int> inventoryID { get; set; }
        public Nullable<int> customerID { get; set; }
        public Nullable<int> repID { get; set; }
        public Nullable<System.DateTime> saledate { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual inventory inventory { get; set; }
        public virtual rep rep { get; set; }
    }
}