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
    public class HRLogic : IDeptLogic, IEmpLogic
    {
        IEmpRepository empRepo;
        IDeptRepository deptRepo;
        public HRLogic()
        {
            empRepo = new EmpRepository(new HRDBContext());
            deptRepo = new DeptRepository(new HRDBContext());
        }
        public HRLogic(IEmpRepository empRepo, IDeptRepository deptRepo)
        {
            this.empRepo = empRepo;
            this.deptRepo = deptRepo;
        }
        public void ChangeDeptLocation(int DEPTNO, string newCity)
        {
            deptRepo.ChangeLocation(DEPTNO, newCity);
        }

        public void ChangeEmpSalary(int EMPNO, int newSalary)
        {
            empRepo.ChangeSalary(EMPNO, newSalary);
        }

        public IList<DEPT> GetAllDepartment()
        {
            return deptRepo.GetAll().ToList();
        }

        public IList<EMP> GetAllEmployee()
        {
            return empRepo.GetAll().ToList();
        }

        public DEPT GetOneDept(int DEPTNO)
        {
            return deptRepo.GetOne(DEPTNO);
        }

        public EMP GetOneEmp(int EMPNO)
        {
            return empRepo.GetOne(EMPNO);
        }
    }
}
