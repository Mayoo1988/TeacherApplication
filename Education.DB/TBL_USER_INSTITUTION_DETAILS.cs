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
    
    public partial class TBL_USER_INSTITUTION_DETAILS
    {
        public long INSTITUTIONID { get; set; }
        public string INSTITUTIONNAME { get; set; }
        public Nullable<long> USERID { get; set; }
        public Nullable<int> CLASSID { get; set; }
        public int BOARDID { get; set; }
        public Nullable<int> PASSINGYEAR { get; set; }
        public string GRADE_PERCENT { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    
        public virtual TBL_MASTER_BOARDS TBL_MASTER_BOARDS { get; set; }
        public virtual TBL_MASTER_CLASS TBL_MASTER_CLASS { get; set; }
        public virtual TBL_USER_LOGIN TBL_USER_LOGIN { get; set; }
    }
}
