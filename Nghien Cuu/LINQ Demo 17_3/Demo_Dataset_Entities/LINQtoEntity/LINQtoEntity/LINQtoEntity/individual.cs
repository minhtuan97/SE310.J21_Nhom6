//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQtoEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class individual
    {
        public Nullable<System.DateTime> BIRTH_DATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public int CUST_ID { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
