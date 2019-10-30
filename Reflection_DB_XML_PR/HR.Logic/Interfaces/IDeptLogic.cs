using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// --------------------------------
//         SAJÁT IMPORTOK
using HR.Data;
// --------------------------------

namespace HR.Logic
{
    interface IDeptLogic
    {
        DEPT GetOneDept(int DEPTNO);
        IList<DEPT> GetAllDepartment();
        void ChangeDeptLocation(int DEPTNO, string newCity);
    }
}
