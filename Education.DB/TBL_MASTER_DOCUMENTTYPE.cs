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
    
    public partial class TBL_MASTER_DOCUMENTTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MASTER_DOCUMENTTYPE()
        {
            this.TBL_USER_DOCUMENTS_DETAILS = new HashSet<TBL_USER_DOCUMENTS_DETAILS>();
        }
    
        public int DocumentTypeID { get; set; }
        public string DocumentTypeName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_DOCUMENTS_DETAILS> TBL_USER_DOCUMENTS_DETAILS { get; set; }
    }
}