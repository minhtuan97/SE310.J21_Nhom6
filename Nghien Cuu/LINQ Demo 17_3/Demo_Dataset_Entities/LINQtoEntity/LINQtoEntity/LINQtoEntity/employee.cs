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
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.acc_transaction = new HashSet<acc_transaction>();
            this.accounts = new HashSet<account>();
            this.employee1 = new HashSet<employee>();
        }
    
        public int EMP_ID { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public System.DateTime START_DATE { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> ASSIGNED_BRANCH_ID { get; set; }
        public Nullable<int> DEPT_ID { get; set; }
        public Nullable<int> SUPERIOR_EMP_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<acc_transaction> acc_transaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> accounts { get; set; }
        public virtual branch branch { get; set; }
        public virtual department department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employee1 { get; set; }
        public virtual employee employee2 { get; set; }
    }
}
