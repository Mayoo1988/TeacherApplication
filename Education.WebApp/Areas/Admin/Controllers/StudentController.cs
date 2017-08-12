using Education.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Core.CountryStateCity;
using Education.Core.Students;
using Education.WebApp.Areas.Admin.Models.Students;
using Education.Entity.Students;
using static Education.WebApp.Areas.Admin.Models.Students.StudentInstitutionDetails;

namespace Education.WebApp.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {


        IStudentReposetory _StudentReposetory;


        public StudentController(IStudentReposetory repos)
        {
            this._StudentReposetory = repos;
        }
        // GET: Admin/Student
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AddStudent()
        {
            CountryStateCityReposetory countryStateCityReposetory = new CountryStateCityReposetory();

            StudentDetail student = new StudentDetail();

            student.CountrtList = countryStateCityReposetory.GetCountry().Select(X => new SelectListItem() { Text = X.CountryName, Value = X.CountryID.ToString() });


            return View(student);
        }


        [HttpGet]
        public ActionResult AddInstitute(long UserID)
        {
            StudentInstitution studentInstitution = new StudentInstitution();
            studentInstitution.StudentInstitutionDetailsList = _StudentReposetory.GetInstitutes(UserID).Select(X => new StudentInstitutionDetails()
            {
                BOARDID = X.BOARDID,
                ClassID = X.CLASSID,
                GRADE_PERCENT = X.GRADE_PERCENT,
                INSTITUTIONID = X.INSTITUTIONID,
                INSTITUTIONNAME = X.INSTITUTIONNAME,
                PASSINGYEAR = X.PASSINGYEAR,
                UserID = X.USERID
            }).ToList();

            studentInstitution.StudentInstitutionDetails = new StudentInstitutionDetails();
            studentInstitution.StudentInstitutionDetails.Classes = _StudentReposetory.GetClasses().Select(X => new SelectListItem() { Text = X.ClassName, Value = X.ClassID.ToString() }).ToList();
            studentInstitution.StudentInstitutionDetails.Boards = _StudentReposetory.GetBoards().Select(X => new SelectListItem() { Text = X.BoardName, Value = X.BoardID.ToString() }).ToList();
            return View(studentInstitution);

        }

        [HttpPost]
        public ActionResult AddInstitute(StudentInstitution studentInstitution)
        {

            if (ModelState.IsValid)
            {
                InstitutionDetail instituteDeatil = new InstitutionDetail();
                instituteDeatil.BOARDID = studentInstitution.StudentInstitutionDetails.BOARDID;
                instituteDeatil.CLASSID = studentInstitution.StudentInstitutionDetails.BOARDID;

                instituteDeatil.CREATEDBY = Convert.ToInt64(Session["UserID"]);
                instituteDeatil.CREATEDDATE = DateTime.Now;

                instituteDeatil.GRADE_PERCENT = studentInstitution.StudentInstitutionDetails.GRADE_PERCENT;

                //instituteDeatil.INSTITUTIONID = studentInstitution.StudentInstitutionDetails.BOARDID;
                instituteDeatil.INSTITUTIONNAME = studentInstitution.StudentInstitutionDetails.INSTITUTIONNAME;
                instituteDeatil.PASSINGYEAR = studentInstitution.StudentInstitutionDetails.PASSINGYEAR;
                instituteDeatil.USERID = studentInstitution.StudentInstitutionDetails.UserID;
                instituteDeatil = _StudentReposetory.AddInstitute(instituteDeatil);
                if (instituteDeatil.INSTITUTIONID > 0)
                {
                    TempData["AlertMessage"] = "Institute Added Successfuly.";
                    return RedirectToAction("AddInstitute", instituteDeatil.USERID);
                }
                TempData["AlertMessage"] = "Unable to add institute. Kindly contact to tech team or try after some time.";

            }

            studentInstitution.StudentInstitutionDetails = new StudentInstitutionDetails();
            studentInstitution.StudentInstitutionDetails.Classes = _StudentReposetory.GetClasses().Select(X => new SelectListItem() { Text = X.ClassName, Value = X.ClassID.ToString() }).ToList();
            studentInstitution.StudentInstitutionDetails.Boards = _StudentReposetory.GetBoards().Select(X => new SelectListItem() { Text = X.BoardName, Value = X.BoardID.ToString() }).ToList();
            return View(studentInstitution);

        }


        [HttpPost]
        public ActionResult AddStudent(StudentDetail studentDetail)
        {

            if (ModelState.IsValid)
            {


                StudentDetails _studentDetails = new StudentDetails();
                _studentDetails.AddressLine1 = studentDetail.AddressLine1;
                _studentDetails.AddressLine2 = studentDetail.AddressLine2;
                _studentDetails.AddressTypeID = studentDetail.AddressType;
                _studentDetails.CityID = studentDetail.City;
                _studentDetails.CountryID = studentDetail.Country;

                _studentDetails.CREATEDBY = Convert.ToInt64(Session["UserID"]);
                _studentDetails.DOB = studentDetail.DateOfBirth;
                _studentDetails.EMAILID = studentDetail.EMAILID;
                _studentDetails.FIRSTNAME = studentDetail.FIRSTNAME;
                _studentDetails.Gender = studentDetail.Gender.ToLower() == "male" ? Entity.Master.Gender.Male : Entity.Master.Gender.Female;
                _studentDetails.LASTNAME = studentDetail.LASTNAME;
                _studentDetails.MIDDLENAME = studentDetail.MIDDLENAME;
                _studentDetails.MOBILENO = studentDetail.MOBILENO;
                _studentDetails.NATIONALITY = studentDetail.NATIONALITY;
                _studentDetails.Pincode = studentDetail.Pincode;
                _studentDetails.StateID = studentDetail.State;
                _studentDetails.UserType = Entity.Master.UserType.Student;
                _studentDetails.PASSWORD = GeneratePassword(studentDetail.MOBILENO);

                bool Result = _StudentReposetory.StudentExist(_studentDetails);
                if (!Result)
                {
                    _studentDetails = _StudentReposetory.CreateStudent(_studentDetails);
                    if (_studentDetails.USERID > 0)
                    {
                        RedirectToAction("AddInstitute", _studentDetails.USERID);
                    }
                    else
                    {
                        ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");

                    }

                }
                else
                {
                    ModelState.AddModelError("EMAILID", "Email number already Registered");
                    ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                }


            }

            return View(studentDetail);



        }

        [HttpPost]
        public ActionResult DeleteInstitute(long InstituteID, long UserID)
        {
            bool result = _StudentReposetory.DeleteInstitute(InstituteID);
            TempData["AlertMessage"] = "Institute Deleted Successfuly.";
            return RedirectToAction("AddInstitute", UserID);
        }



        [HttpGet]
        public ActionResult AddDocument(long UserID)
        {
            StudentInstitution studentInstitution = new StudentInstitution();
            studentInstitution.StudentInstitutionDetailsList = _StudentReposetory.GetInstitutes(UserID).Select(X => new StudentInstitutionDetails()
            {
                BOARDID = X.BOARDID,
                ClassID = X.CLASSID,
                GRADE_PERCENT = X.GRADE_PERCENT,
                INSTITUTIONID = X.INSTITUTIONID,
                INSTITUTIONNAME = X.INSTITUTIONNAME,
                PASSINGYEAR = X.PASSINGYEAR,
                UserID = X.USERID
            }).ToList();

            studentInstitution.StudentInstitutionDetails = new StudentInstitutionDetails();
            studentInstitution.StudentInstitutionDetails.Classes = _StudentReposetory.GetClasses().Select(X => new SelectListItem() { Text = X.ClassName, Value = X.ClassID.ToString() }).ToList();
            studentInstitution.StudentInstitutionDetails.Boards = _StudentReposetory.GetBoards().Select(X => new SelectListItem() { Text = X.BoardName, Value = X.BoardID.ToString() }).ToList();
            return View(studentInstitution);

        }

        [HttpPost]
        public ActionResult AddDocument(StudentInstitution studentInstitution)
        {

            if (ModelState.IsValid)
            {
                InstitutionDetail instituteDeatil = new InstitutionDetail();
                instituteDeatil.BOARDID = studentInstitution.StudentInstitutionDetails.BOARDID;
                instituteDeatil.CLASSID = studentInstitution.StudentInstitutionDetails.BOARDID;

                instituteDeatil.CREATEDBY = Convert.ToInt64(Session["UserID"]);
                instituteDeatil.CREATEDDATE = DateTime.Now;

                instituteDeatil.GRADE_PERCENT = studentInstitution.StudentInstitutionDetails.GRADE_PERCENT;

                //instituteDeatil.INSTITUTIONID = studentInstitution.StudentInstitutionDetails.BOARDID;
                instituteDeatil.INSTITUTIONNAME = studentInstitution.StudentInstitutionDetails.INSTITUTIONNAME;
                instituteDeatil.PASSINGYEAR = studentInstitution.StudentInstitutionDetails.PASSINGYEAR;
                instituteDeatil.USERID = studentInstitution.StudentInstitutionDetails.UserID;
                instituteDeatil = _StudentReposetory.AddInstitute(instituteDeatil);
                if (instituteDeatil.INSTITUTIONID > 0)
                {
                    TempData["AlertMessage"] = "Institute Added Successfuly.";
                    return RedirectToAction("AddInstitute", instituteDeatil.USERID);
                }
                TempData["AlertMessage"] = "Unable to add institute. Kindly contact to tech team or try after some time.";

            }

            studentInstitution.StudentInstitutionDetails = new StudentInstitutionDetails();
            studentInstitution.StudentInstitutionDetails.Classes = _StudentReposetory.GetClasses().Select(X => new SelectListItem() { Text = X.ClassName, Value = X.ClassID.ToString() }).ToList();
            studentInstitution.StudentInstitutionDetails.Boards = _StudentReposetory.GetBoards().Select(X => new SelectListItem() { Text = X.BoardName, Value = X.BoardID.ToString() }).ToList();
            return View(studentInstitution);

        }


        [HttpPost]
        public ActionResult AddDocument(StudentDetail studentDetail)
        {

            if (ModelState.IsValid)
            {


                StudentDetails _studentDetails = new StudentDetails();
                _studentDetails.AddressLine1 = studentDetail.AddressLine1;
                _studentDetails.AddressLine2 = studentDetail.AddressLine2;
                _studentDetails.AddressTypeID = studentDetail.AddressType;
                _studentDetails.CityID = studentDetail.City;
                _studentDetails.CountryID = studentDetail.Country;

                _studentDetails.CREATEDBY = Convert.ToInt64(Session["UserID"]);
                _studentDetails.DOB = studentDetail.DateOfBirth;
                _studentDetails.EMAILID = studentDetail.EMAILID;
                _studentDetails.FIRSTNAME = studentDetail.FIRSTNAME;
                _studentDetails.Gender = studentDetail.Gender.ToLower() == "male" ? Entity.Master.Gender.Male : Entity.Master.Gender.Female;
                _studentDetails.LASTNAME = studentDetail.LASTNAME;
                _studentDetails.MIDDLENAME = studentDetail.MIDDLENAME;
                _studentDetails.MOBILENO = studentDetail.MOBILENO;
                _studentDetails.NATIONALITY = studentDetail.NATIONALITY;
                _studentDetails.Pincode = studentDetail.Pincode;
                _studentDetails.StateID = studentDetail.State;
                _studentDetails.UserType = Entity.Master.UserType.Student;
                _studentDetails.PASSWORD = GeneratePassword(studentDetail.MOBILENO);

                bool Result = _StudentReposetory.StudentExist(_studentDetails);
                if (!Result)
                {
                    _studentDetails = _StudentReposetory.CreateStudent(_studentDetails);
                    if (_studentDetails.USERID > 0)
                    {
                        RedirectToAction("AddInstitute", _studentDetails.USERID);
                    }
                    else
                    {
                        ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");

                    }

                }
                else
                {
                    ModelState.AddModelError("EMAILID", "Email number already Registered");
                    ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                }


            }

            return View(studentDetail);



        }

        [HttpPost]
        public ActionResult DeleteDocument(long InstituteID, long UserID)
        {
            bool result = _StudentReposetory.DeleteInstitute(InstituteID);
            TempData["AlertMessage"] = "Institute Deleted Successfuly.";
            return RedirectToAction("AddInstitute", UserID);
        }



        string GeneratePassword(string Key)
        {
            return Key;
        }

    }
}