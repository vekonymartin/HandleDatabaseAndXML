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
    class DeptLogic : IDeptLogic
    {
        IDeptRepository deptRepo;
        public DeptLogic()
        {
            deptRepo = new DeptRepository(new HRDBContext());
        }
        public DeptLogic(IDeptRepository deptRepo)
        {
            this.deptRepo = deptRepo;
        }
        public void ChangeDeptLocation(int DEPTNO, string newCity)
        {
            deptRepo.ChangeLocation(DEPTNO, newCity);
        }

        public IList<DEPT> GetAllDepartment()
        {
            return deptRepo.GetAll().ToList();
        }

        public DEPT GetOneDept(int DEPTNO)
        {
            return deptRepo.GetOne(DEPTNO);
        }
    }
}
