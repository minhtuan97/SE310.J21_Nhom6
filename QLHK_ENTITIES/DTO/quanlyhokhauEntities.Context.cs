﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class quanlyhokhauEntities : DbContext
    {
        public quanlyhokhauEntities()
            : base("name=quanlyhokhauEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CANBO> CANBOes { get; set; }
        public virtual DbSet<HOCSINHSINHVIEN> HOCSINHSINHVIENs { get; set; }
        public virtual DbSet<NHANKHAU> NHANKHAUs { get; set; }
        public virtual DbSet<NHANKHAUTAMTRU> NHANKHAUTAMTRUs { get; set; }
        public virtual DbSet<NHANKHAUTAMVANG> NHANKHAUTAMVANGs { get; set; }
        public virtual DbSet<NHANKHAUTHUONGTRU> NHANKHAUTHUONGTRUs { get; set; }
        public virtual DbSet<QUANHUYEN> QUANHUYENs { get; set; }
        public virtual DbSet<SOHOKHAU> SOHOKHAUs { get; set; }
        public virtual DbSet<SOTAMTRU> SOTAMTRUs { get; set; }
        public virtual DbSet<TIENANTIENSU> TIENANTIENSUs { get; set; }
        public virtual DbSet<TIEUSU> TIEUSUs { get; set; }
        public virtual DbSet<TINHTHANHPHO> TINHTHANHPHOes { get; set; }
        public virtual DbSet<XAPHUONGTHITRAN> XAPHUONGTHITRANs { get; set; }
    }
}
