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
    
    public partial class QUANHUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUANHUYEN()
        {
            this.XAPHUONGTHITRANs = new HashSet<XAPHUONGTHITRAN>();
        }
    
        public string maqh { get; set; }
        public string ten { get; set; }
        public string kieu { get; set; }
        public string matp { get; set; }
    
        public virtual TINHTHANHPHO TINHTHANHPHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XAPHUONGTHITRAN> XAPHUONGTHITRANs { get; set; }
    }
}
