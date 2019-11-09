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
    public interface IDeptRepository : IRepository<DEPT>
    {
        void ChangeLocation(int DEPTNO, string newCity);
        void RemoveLocation(string location);
        void InsertNewDept(DEPT newDeptData);
        void InsertNewDept(int DEPTNO, string DEPTNAME, string LOC);
        void InsertOneData(int ID, string newCity);
    }
}
