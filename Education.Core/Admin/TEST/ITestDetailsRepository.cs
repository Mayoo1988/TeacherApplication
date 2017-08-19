using Education.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
    public interface ITestDetailsRepository
    {
        TestDetails CreateTestDetails(DataSet studentDetails,TestDetails TestDetails);
    }
}
