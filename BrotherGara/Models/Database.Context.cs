﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrotherGara.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrothersGarageEntities : DbContext
    {
        public BrothersGarageEntities()
            : base("name=BrothersGarageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAOCAOTON> BAOCAOTONs { get; set; }
        public virtual DbSet<CT_TIENCONG> CT_TIENCONG { get; set; }
        public virtual DbSet<CT_VATTU> CT_VATTU { get; set; }
        public virtual DbSet<HIEUXE> HIEUXEs { get; set; }
        public virtual DbSet<NOIDUNGDOANHSO> NOIDUNGDOANHSOes { get; set; }
        public virtual DbSet<NOIDUNGNHAPKHO> NOIDUNGNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUDOANHSO> PHIEUDOANHSOes { get; set; }
        public virtual DbSet<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUSUACHUA> PHIEUSUACHUAs { get; set; }
        public virtual DbSet<PHIEUTHUTIEN> PHIEUTHUTIENs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }
        public virtual DbSet<THANGNAM> THANGNAMs { get; set; }
        public virtual DbSet<TIENCONG> TIENCONGs { get; set; }
        public virtual DbSet<TIEPNHAN> TIEPNHANs { get; set; }
        public virtual DbSet<VATTU> VATTUs { get; set; }
    }
}
