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
    
    public partial class HOCSINHSINHVIEN
    {
        public string MAHSSV { get; set; }
        public string MADINHDANH { get; set; }
        public string TRUONG { get; set; }
        public string DIACHITHUONGTRU { get; set; }
        public System.DateTime THOIGIANBATDAUTAMTRUTHUONGTRU { get; set; }
        public System.DateTime THOIGIANKETTHUCTAMTRUTHUONGTRU { get; set; }
        public string VIPHAM { get; set; }
    
        public virtual NHANKHAU NHANKHAU { get; set; }
    }
}
