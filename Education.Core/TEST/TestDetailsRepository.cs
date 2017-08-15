using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Admin;
using Education.DB;
using System.Data;

namespace Education.Core.Admin
{
    public class TestDetailsRepository : ITestDetailsRepository
    {
        public EducationDBEntities dbEntities = new EducationDBEntities();

        public TestDetails CreateTestDetails(DataSet studentDetails, TestDetails TestDetails)
        {
            TBL_TEST_TESTDETAIL objtestdetails = new TBL_TEST_TESTDETAIL();
            objtestdetails.TITLE = TestDetails.TITLE;
            objtestdetails.SUBJECTID = TestDetails.SUBJECTID;
            objtestdetails.PUBLISHDATE = TestDetails.PUBLISHDATE;
            objtestdetails.GIVENBY = TestDetails.GIVENBY;
            foreach (DataTable table in studentDetails.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    string questions = Convert.ToString(studentDetails.Tables[0].Rows[0]["Questions"].ToString());
                    string answers = Convert.ToString(studentDetails.Tables[0].Rows[0]["Answers"].ToString());
                    int Isvalid = Convert.ToInt16(studentDetails.Tables[0].Rows[0]["Isvalid"].ToString());
                    int Marks = Convert.ToInt16(studentDetails.Tables[0].Rows[0]["Marks"].ToString());

                    TBL_TEST_QUESTIONS objquestiondetails = new TBL_TEST_QUESTIONS();

                    objquestiondetails.DESCRIPTION = questions;
                    objquestiondetails.ISMULTISELECT = true;
                    objquestiondetails.TESTID = 2;
                    objquestiondetails.QUESTIONTYPEID = 1;
                    objquestiondetails.MARKS = Marks;


                    TBL_TEST_ANSWERS objtestanswersdetail = new TBL_TEST_ANSWERS();
                    objtestanswersdetail.DESCRIPTION = answers;
                    objtestanswersdetail.QUESTIONID = 5;
                    objtestanswersdetail.TESTID = 2;
                    objtestanswersdetail.ISVALID = Convert.ToBoolean(Isvalid);

                    dbEntities.TBL_TEST_TESTDETAIL.Add(objtestdetails);
                    dbEntities.TBL_TEST_QUESTIONS.Add(objquestiondetails);
                    dbEntities.TBL_TEST_ANSWERS.Add(objtestanswersdetail);
                    dbEntities.SaveChanges();
                }
            }

            return TestDetails;
        }
    }
}
