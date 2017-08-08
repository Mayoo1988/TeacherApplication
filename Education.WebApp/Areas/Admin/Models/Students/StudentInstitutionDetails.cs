using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Areas.Admin.Models.Students
{
    public class StudentInstitutionDetails
    {
        public IEnumerable<SelectListItem> Classes { get; set; }
        [Required(ErrorMessage = "Select Class")]
        public int? ClassID { get; set; }
        public long INSTITUTIONID { get; set; }
        [Required(ErrorMessage = "Enter Institute Name")]
        public string INSTITUTIONNAME { get; set; }
        public long? UserID { get; set; }
        public IEnumerable<SelectListItem> Boards { get; set; }
        [Required(ErrorMessage = "Select Board")]
        public int BOARDID { get; set; }
        [Required(ErrorMessage = "Select Passing Years")]
        public Nullable<int> PASSINGYEAR { get; set; }
        [Required(ErrorMessage = "Enter Percent or gread")]
        public string GRADE_PERCENT { get; set; }

        public IEnumerable<SelectListItem> PASSINGYEARList
        {
            get
            {
                List<SelectListItem> itemlist = new List<SelectListItem>();
                for (int Curyear = DateTime.Now.Year; Curyear >= 1980; Curyear--)
                {
                    itemlist.Add(new SelectListItem()
                    {
                        Text = Curyear.ToString(),
                        Value = Curyear.ToString()
                    })

                }
                return itemlist;
            }


            set { }


        }

    }

    public class StudentInstitution
    {
        public StudentInstitutionDetails StudentInstitutionDetails { get; set; }
        public List<StudentInstitutionDetails> StudentInstitutionDetailsList { get; set; }
    }
}