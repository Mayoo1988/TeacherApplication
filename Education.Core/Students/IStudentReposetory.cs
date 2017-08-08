using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Students
{
    public interface IStudentReposetory
    {
        StudentDetails CreateStudent(StudentDetails studentDetails);
        bool StudentExist(StudentDetails student);
        List<InstitutionDetail> GetInstitutes(long UserID);
        InstitutionDetail AddInstitute(InstitutionDetail Institute);
        bool DeleteInstitute(long InstituteID);
        List<Boards> GetBoards();
        List<Classes> GetClasses();
        
      }
}
