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
    
    public partial class NHANKHAUTAMVANG
    {
        public string MANHANKHAUTAMVANG { get; set; }
        public string MADINHDANH { get; set; }
        public System.DateTime NGAYBATDAUTAMVANG { get; set; }
        public System.DateTime NGAYKETTHUCTAMVANG { get; set; }
        public string LYDO { get; set; }
        public string NOIDEN { get; set; }
    
        public virtual NHANKHAU NHANKHAU { get; set; }
    }
}