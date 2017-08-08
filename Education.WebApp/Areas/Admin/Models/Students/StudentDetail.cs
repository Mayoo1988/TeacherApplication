using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Areas.Admin.Models.Students
{
    public class StudentDetail : IValidatableObject
    {



        //public long USERID { get; set; }
        [Required(ErrorMessage = "Enter Email id")]
        public string EMAILID { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LASTNAME { get; set; }


        [Required(ErrorMessage = "Enter Date of birth in DD/MM/YYYY format")]
        public string DOB { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Nationlaity")]
        public string NATIONALITY { get; set; }
        [Required(ErrorMessage = "Enter Mobile No")]
        [RegularExpression("^[0-9]{8,10}$", ErrorMessage = "Enter valid Mobile No")]
        public string MOBILENO { get; set; }
        [Required(ErrorMessage = "Select student's Gender")]
        public string Gender { get; set; }

        public int AddressType { get; set; }
        [Required(ErrorMessage = "Enter Address line 1")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Select Country")]
        public int Country { get; set; }
        [Required(ErrorMessage = "Select State")]
        public int State { get; set; }
        [Required(ErrorMessage = "Select City")]
        public int City { get; set; }
        [RegularExpression("^[0-9]{5,6}$", ErrorMessage = "Enter valid pincode")]
        public int Pincode { get; set; }
        public IEnumerable<SelectListItem> CountrtList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResultList = new List<ValidationResult>();

            List<string> validationmember = new List<string>();
            if (string.IsNullOrEmpty(DOB) || IsValidDate(DOB))
            {
                validationmember.Add("DOB");
                ValidationResult validation = new ValidationResult("Enter Valid Date of birth", validationmember);
                validationResultList.Add(validation);


            }
            return validationResultList;


        }
        bool IsValidDate(string Date)
        {
           
            bool result = false;
            try
            {
                DateOfBirth=  new DateTime(Convert.ToInt32(Date.Split('/')[2]), Convert.ToInt32(Date.Split('/')[1]), Convert.ToInt32(Date.Split('/')[0]));
                result = true;
            }
            catch
            {
                try
                {
                    DateOfBirth =    new DateTime(Convert.ToInt32(Date.Split('/')[2]), Convert.ToInt32(Date.Split('/')[0]), Convert.ToInt32(Date.Split('/')[1]));
                    result = true;
                }
                catch
                {  }

            }
            return result;

        }
    }
}