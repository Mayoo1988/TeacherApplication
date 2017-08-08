using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Master
{

    public enum UserType
    {
        SuperAdmin = 1,
        SubAdmin = 2,
        Teacher = 3,
        Parent = 4,
        Student = 5
    }

    public enum UserLoginStatus
    {
        Disabled = 1,
        Active = 2,
        Locked = 3
    }
    public enum Gender
    {
        Male,
        Female
    }


}
