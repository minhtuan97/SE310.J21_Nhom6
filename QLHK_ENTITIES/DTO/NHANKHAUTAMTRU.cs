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
    
    public partial class NHANKHAUTAMTRU
    {
        public string MANHAKHAUTAMTRU { get; set; }
        public string MADINHDANH { get; set; }
        public string NOITAMTRU { get; set; }
        public System.DateTime TUNGAY { get; set; }
        public System.DateTime DENNGAY { get; set; }
        public string LYDO { get; set; }
        public string SOSOTAMTRU { get; set; }
    
        public virtual NHANKHAU NHANKHAU { get; set; }
        public virtual SOTAMTRU SOTAMTRU { get; set; }
    }
}
