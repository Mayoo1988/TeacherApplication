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
    
    public partial class TBL_USER_LOGIN_TRAIL
    {
        public long LOGIN_TRAIL_ID { get; set; }
        public long USERID { get; set; }
        public string IPADDRESS { get; set; }
        public string LATITUTE { get; set; }
        public string LONGITUTE { get; set; }
        public Nullable<System.DateTime> LOGINDATETIME { get; set; }
    
        public virtual TBL_USER_LOGIN TBL_USER_LOGIN { get; set; }
    }
}
