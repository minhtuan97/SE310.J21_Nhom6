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
    
    public partial class XAPHUONGTHITRAN
    {
        public string maxp { get; set; }
        public string ten { get; set; }
        public string kieu { get; set; }
        public string maqh { get; set; }
    
        public virtual QUANHUYEN QUANHUYEN { get; set; }
    }
}
