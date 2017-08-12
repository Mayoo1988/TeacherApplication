using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education.WebApp.Areas.Admin.Models.Students
{
    public class StudentDocument
    {
        public long USERDOCUMENTID { get; set; }
        [Required(ErrorMessage = "Select Document Type")]
        public int DOCUMENTTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        public long USERID { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
       
        public string DOCUMENTTYPENAME { get; set; }
    }
}