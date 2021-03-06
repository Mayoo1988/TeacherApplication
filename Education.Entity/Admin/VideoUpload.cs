﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin
{
  public class VideoUploaddetails
    {
        public long DIGITALDOCID { get; set; }
        public Nullable<int> DIGITALDOCTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<bool> ALLOWANONYMOUS { get; set; }
        public Nullable<int> DOWNLOADCOUNT { get; set; }
        public Nullable<int> VIEWCOUNT { get; set; }

    }
}
