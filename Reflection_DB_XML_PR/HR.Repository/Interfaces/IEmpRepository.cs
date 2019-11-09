using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// --------------------------------
//         SAJÁT IMPORTOK
using HR.Data;
// --------------------------------

namespace HR.Repository
{
    public interface IEmpRepository : IRepository<EMP>
    {
        void ChangeSalary(int EMPNO, int newSalary);
        void InsertEmployee();
        void RemoveEmp(string ENAME);
    }
}
