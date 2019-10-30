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
    public interface IEmpLogic
    {
        EMP GetOneEmp(int EMPNO);
        void ChangeEmpSalary(int EMPNO, int newSalary);
        IList<EMP> GetAllEmployee();
    }
}
