using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.WebApp.Areas.Admin.Models.TestDetails
{
    public class TestDetailsModel
    {
        public long TESTID { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<System.DateTime> PUBLISHDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<long> GIVENBY { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    }
}