using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Master;

namespace Education.Entity.Students
{
    public class StudentDetails
    {
        public long PERSONALDETAILID { get; set; }
        public string PASSWORD { get; set; }
        public long USERID { get; set; }
        public string EMAILID { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string MOTHERNAME { get; set; }
        public string FATHERNAME { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string DISABILITY { get; set; }
        public string ENROLNMENTID { get; set; }

        public string NATIONALITY { get; set; }
        public string MOBILENO { get; set; }
        public long CREATEDBY { get; set; }
        public UserLoginStatus LoginStatus { get; set; }
        public Gender Gender { get; set; }
        public Education.Entity.Master.UserType UserType { get; set; }


        public int AddressTypeID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public int CityID { get; set; }

        public int Pincode { get; set; }

    }
}
