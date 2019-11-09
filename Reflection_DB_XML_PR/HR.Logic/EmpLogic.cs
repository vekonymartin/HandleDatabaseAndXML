using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// --------------------------------
//         SAJÁT IMPORTOK
using HR.Repository;
using HR.Data;
// --------------------------------

namespace HR.Logic
{
    public class EmpLogic : IEmpLogic
    {
        IEmpRepository empRepo;

        public EmpLogic()
        {
            empRepo = new EmpRepository(new HRDBContext());
        }

        public EmpLogic(IEmpRepository empRepo)
        {
            this.empRepo = empRepo;
        }
        public void ChangeEmpSalary(int EMPNO, int newSalary)
        {
            empRepo.ChangeSalary(EMPNO, newSalary);
        }

        public IList<EMP> GetAllEmployee()
        {
            return empRepo.GetAll().ToList();
        }

        public EMP GetOneEmp(int EMPNO)
        {
            return empRepo.GetOne(EMPNO);
        }

        public void RemoveEmployee(string ENAME)
        {
            empRepo.RemoveEmp(ENAME);
        }

        public void InsertNewEmployee()
        {
            empRepo.InsertEmployee();
        }
    }
}
