using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// --------------------------------
//         SAJÁT IMPORTOK
using System.Data.Entity;
using HR.Data;
// --------------------------------

namespace HR.Repository
{
    public class EmpRepository : Repository<EMP>, IEmpRepository
    {
        public EmpRepository(DbContext ctx) : base(ctx) { }
        public void ChangeSalary(int EMPNO, int newSalary)
        {
            var sal = GetOne(EMPNO);
            sal.SAL = newSalary;
            ctx.SaveChanges();

        }

        public override EMP GetOne(int EMPNO)
        {
            return GetAll().FirstOrDefault(x => x.EMPNO == EMPNO);
        }
    }
}
