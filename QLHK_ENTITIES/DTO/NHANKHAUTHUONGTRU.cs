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
    
    public partial class NHANKHAUTHUONGTRU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANKHAUTHUONGTRU()
        {
            this.CANBOes = new HashSet<CANBO>();
        }
    
        public string MANHANKHAUTHUONGTRU { get; set; }
        public string MADINHDANH { get; set; }
        public string DIACHITHUONGTRU { get; set; }
        public string QUANHEVOICHUHO { get; set; }
        public string SOSOHOKHAU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CANBO> CANBOes { get; set; }
        public virtual NHANKHAU NHANKHAU { get; set; }
        public virtual SOHOKHAU SOHOKHAU { get; set; }
    }
}
