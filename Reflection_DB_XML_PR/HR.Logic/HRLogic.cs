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

        /// <summary>
        /// Method change city name by id
        /// </summary>
        /// <param name="DEPTNO">Department id</param>
        /// <param name="newCity">New city name</param>
        public void ChangeDeptLocation(int DEPTNO, string newCity)
        {
            deptRepo.ChangeLocation(DEPTNO, newCity);
        }

        /// <summary>
        /// Method change employee's salary by id
        /// </summary>
        /// <param name="EMPNO">Employee id</param>
        /// <param name="newSalary">New salary</param>
        public void ChangeEmpSalary(int EMPNO, int newSalary)
        {
            empRepo.ChangeSalary(EMPNO, newSalary);
        }

        /// <summary>
        /// Return List with Employee table's datas
        /// </summary>
        /// <returns>List<DEPT></returns>
        public IList<DEPT> GetAllDepartment()
        {
            return deptRepo.GetAll().ToList();
        }

        /// <summary>
        /// Return List with Employee table's datas
        /// </summary>
        /// <returns>List<EMP></returns>
        public IList<EMP> GetAllEmployee()
        {
            return empRepo.GetAll().ToList();
        }

        /// <summary>
        /// Return one data from DEPT Table
        /// </summary>
        /// <param name="DEPTNO">Primary Key</param>
        /// <returns>One data with DEPT type</returns>
        public DEPT GetOneDept(int DEPTNO)
        {
            return deptRepo.GetOne(DEPTNO);
        }

        /// <summary>
        /// Return one data from EMP Table
        /// </summary>
        /// <param name="EMPNO">Primary Key</param>
        /// <returns>One data with EMP type</returns>
        public EMP GetOneEmp(int EMPNO)
        {
            return empRepo.GetOne(EMPNO);
        }
    }
}
