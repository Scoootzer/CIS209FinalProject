﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NewCarDealerEntities : DbContext
    {
        public NewCarDealerEntities()
            : base("name=NewCarDealerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<basecar> basecars { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<rep> reps { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<trim> trims { get; set; }
    }
}
