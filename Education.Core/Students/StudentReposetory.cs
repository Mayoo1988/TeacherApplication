using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DB;
using Education.Entity.Students;

namespace Education.Core.Students
{
    public class StudentReposetory : IStudentReposetory
    {
        public EducationDBEntities dbEntities = new EducationDBEntities();
        public bool StudentExist(StudentDetails student)
        {
            bool result = false;
            if (dbEntities.TBL_USER_LOGIN.Count(X => X.LOGIN_EMAIL.ToLower() == student.EMAILID.ToLower() || X.LOGIN_MOBILE == student.MOBILENO) > 0)
            {
                result = true;
            }
            return result;


        }

        public List<InstitutionDetail> GetInstitutes(long UserID)
        {
            return dbEntities.TBL_USER_INSTITUTION_DETAILS.Where(X => X.USERID == UserID).Select(X =>
            new InstitutionDetail()
            {
                BOARDID = X.BOARDID,
                CREATEDBY = X.CREATEDBY,
                CLASSID = X.CLASSID,
                USERID = X.USERID,
                CREATEDDATE = X.CREATEDDATE,
                GRADE_PERCENT = X.GRADE_PERCENT,
                INSTITUTIONID = X.INSTITUTIONID,
                INSTITUTIONNAME = X.INSTITUTIONNAME,
                MODIFIEDBY = X.MODIFIEDBY,
                MODIFIEDDATE = X.MODIFIEDDATE,
                PASSINGYEAR = X.PASSINGYEAR
            }

                ).ToList();
        }

        public InstitutionDetail AddInstitute(InstitutionDetail Institute)
        {
            TBL_USER_INSTITUTION_DETAILS institutionDetails = new TBL_USER_INSTITUTION_DETAILS();
            institutionDetails.BOARDID = Institute.BOARDID;
            institutionDetails.CLASSID = Institute.CLASSID;
            institutionDetails.CREATEDBY = Institute.CREATEDBY;
            institutionDetails.CREATEDDATE = DateTime.Now;
            institutionDetails.GRADE_PERCENT = Institute.GRADE_PERCENT;
            institutionDetails.INSTITUTIONNAME = Institute.INSTITUTIONNAME;
            institutionDetails.PASSINGYEAR = Institute.PASSINGYEAR;
            institutionDetails.USERID = Institute.USERID;

            dbEntities.TBL_USER_INSTITUTION_DETAILS.Add(institutionDetails);
            dbEntities.SaveChanges();
            Institute.INSTITUTIONID = institutionDetails.INSTITUTIONID;
            return Institute;
        }

        public StudentDetails CreateStudent(StudentDetails studentDetails)
        {

            TBL_USER_LOGIN userLogin = new TBL_USER_LOGIN();
            userLogin.CREATEDDATE = DateTime.Now;
            userLogin.LOGIN_EMAIL = studentDetails.EMAILID;
            userLogin.LOGIN_MOBILE = studentDetails.MOBILENO;
            userLogin.MODIFIEDDATE = null;
            userLogin.PASSWORD = studentDetails.PASSWORD;
            userLogin.PASSWORDRETRYCOUNT = 0;
            userLogin.STATUSID = (int)studentDetails.LoginStatus;
            userLogin.USERTYPEID = (int)studentDetails.UserType;

            TBL_USER_DETAILS UserDetails = new TBL_USER_DETAILS();

            UserDetails.DOB = studentDetails.DOB;
            UserDetails.FIRSTNAME = studentDetails.FIRSTNAME;
            UserDetails.MIDDLENAME = studentDetails.MIDDLENAME;
            UserDetails.LASTNAME = studentDetails.LASTNAME;
            UserDetails.GENDER = studentDetails.Gender.ToString();
            UserDetails.NATIONALITY = studentDetails.NATIONALITY;
            UserDetails.USERID = userLogin.USERID;

            userLogin.TBL_USER_DETAILS.Add(UserDetails);

            TBL_USER_ROLE UserRole = new TBL_USER_ROLE();
            UserRole.USERID = userLogin.USERID;
            UserRole.USERTYPEID = (int)studentDetails.UserType;
            UserRole.CREATEDBY = studentDetails.CREATEDBY;
            UserRole.CREATEDDATE = DateTime.Now;

            userLogin.TBL_USER_ROLE.Add(UserRole);

            TBL_USER_ADDRESS_DETAILS address = new TBL_USER_ADDRESS_DETAILS();
            address.ADDRESSLINE1 = studentDetails.AddressLine1;
            address.ADDRESSLINE2 = studentDetails.AddressLine2;
            address.ADDRESSTYPEID = studentDetails.AddressTypeID;
            address.CITY = studentDetails.CityID;
            address.COUNTRY = studentDetails.CountryID;
            address.CREATEDBY = studentDetails.CREATEDBY;
            address.CREATEDDATE = DateTime.Now;
            address.PINCODE = studentDetails.Pincode.ToString();
            address.USERID = userLogin.USERID;
            userLogin.TBL_USER_ADDRESS_DETAILS.Add(address);




            dbEntities.TBL_USER_LOGIN.Add(userLogin);
            dbEntities.SaveChanges();
            studentDetails.USERID = userLogin.USERID;
            return studentDetails;



        }

        public List<Boards> GetBoards()
        {
            return dbEntities.TBL_MASTER_BOARDS.Select(X => new Boards() { BoardID = X.BOARDID, BoardName = X.NAME }).ToList();
        }

        public List<Classes> GetClasses()
        {
            return dbEntities.TBL_MASTER_CLASS.Select(X => new Classes() { ClassID = X.CLASSID, ClassName = X.NAME }).ToList();
        }

        public bool DeleteInstitute(long InstituteID)
        {
            bool Restul = false;
            TBL_USER_INSTITUTION_DETAILS institustiondetail = dbEntities.TBL_USER_INSTITUTION_DETAILS.Where(x => x.INSTITUTIONID == InstituteID).SingleOrDefault();
            if (institustiondetail != null)
            {
                dbEntities.TBL_USER_INSTITUTION_DETAILS.Remove(institustiondetail);
                dbEntities.SaveChanges();
                Restul = true;
            }
            return Restul;
        }
    }
}
