//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Education.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_USER_LOGIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USER_LOGIN()
        {
            this.TBL_TEST_ATAMPT = new HashSet<TBL_TEST_ATAMPT>();
            this.TBL_USER_ADDRESS_DETAILS = new HashSet<TBL_USER_ADDRESS_DETAILS>();
            this.TBL_USER_COURSE_DETAILS = new HashSet<TBL_USER_COURSE_DETAILS>();
            this.TBL_USER_DETAILS = new HashSet<TBL_USER_DETAILS>();
            this.TBL_USER_DOCUMENTS_DETAILS = new HashSet<TBL_USER_DOCUMENTS_DETAILS>();
            this.TBL_USER_INSTITUTION_DETAILS = new HashSet<TBL_USER_INSTITUTION_DETAILS>();
            this.TBL_USER_LOGIN_TRAIL = new HashSet<TBL_USER_LOGIN_TRAIL>();
            this.TBL_USER_PARENTS_DETAILS = new HashSet<TBL_USER_PARENTS_DETAILS>();
            this.TBL_USER_PROFESSIONAL_DETAILS = new HashSet<TBL_USER_PROFESSIONAL_DETAILS>();
            this.TBL_USER_ROLE = new HashSet<TBL_USER_ROLE>();
            this.TBL_USER_SUBJECTS = new HashSet<TBL_USER_SUBJECTS>();
        }
    
        public long USERID { get; set; }
        public string LOGIN_EMAIL { get; set; }
        public string LOGIN_MOBILE { get; set; }
        public string PASSWORD { get; set; }
        public int STATUSID { get; set; }
        public int USERTYPEID { get; set; }
        public int PASSWORDRETRYCOUNT { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    
        public virtual TBL_MASTER_STATUS TBL_MASTER_STATUS { get; set; }
        public virtual TBL_MASTER_USERTYPE TBL_MASTER_USERTYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TEST_ATAMPT> TBL_TEST_ATAMPT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_ADDRESS_DETAILS> TBL_USER_ADDRESS_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_COURSE_DETAILS> TBL_USER_COURSE_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_DETAILS> TBL_USER_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_DOCUMENTS_DETAILS> TBL_USER_DOCUMENTS_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_INSTITUTION_DETAILS> TBL_USER_INSTITUTION_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_LOGIN_TRAIL> TBL_USER_LOGIN_TRAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_PARENTS_DETAILS> TBL_USER_PARENTS_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_PROFESSIONAL_DETAILS> TBL_USER_PROFESSIONAL_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_ROLE> TBL_USER_ROLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_SUBJECTS> TBL_USER_SUBJECTS { get; set; }
    }
}
