//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class NHANKHAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANKHAU()
        {
            this.HOCSINHSINHVIENs = new HashSet<HOCSINHSINHVIEN>();
            this.NHANKHAUTAMTRUs = new HashSet<NHANKHAUTAMTRU>();
            this.NHANKHAUTAMVANGs = new HashSet<NHANKHAUTAMVANG>();
            this.NHANKHAUTHUONGTRUs = new HashSet<NHANKHAUTHUONGTRU>();
            this.TIENANTIENSUs = new HashSet<TIENANTIENSU>();
            this.TIEUSUs = new HashSet<TIEUSU>();
        }
    
        public string MADINHDANH { get; set; }
        public string HOTEN { get; set; }
        public string TENKHAC { get; set; }
        public System.DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public string NOISINH { get; set; }
        public string NGUYENQUAN { get; set; }
        public string DANTOC { get; set; }
        public string TONGIAO { get; set; }
        public string QUOCTICH { get; set; }
        public string HOCHIEU { get; set; }
        public string NOITHUONGTRU { get; set; }
        public string DIACHIHIENNAY { get; set; }
        public string SDT { get; set; }
        public string TRINHDOHOCVAN { get; set; }
        public string TRINHDOCHUYENMON { get; set; }
        public string BIETTIENGDANTOC { get; set; }
        public string TRINHDONGOAINGU { get; set; }
        public string NGHENGHIEP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINHSINHVIEN> HOCSINHSINHVIENs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANKHAUTAMTRU> NHANKHAUTAMTRUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANKHAUTAMVANG> NHANKHAUTAMVANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANKHAUTHUONGTRU> NHANKHAUTHUONGTRUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIENANTIENSU> TIENANTIENSUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIEUSU> TIEUSUs { get; set; }
    }
}
