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

        public void InsertEmployee()
        {
            EMP newEmp = new EMP()
            {
                EMPNO = 9998,
                ENAME = "MARTIN",
                JOB = "CLERK",
                MGR = 7782,
                DEPTNO = 10
            };
            ctx.Entry(newEmp).State = EntityState.Modified;
            ctx.Set<EMP>().Attach(newEmp);
            ctx.Set<EMP>().Add(newEmp);
            ctx.SaveChanges();
            Console.WriteLine("Insert new employee");
        }

        public void RemoveEmp(string ENAME)
        {
            //DB.Configuration.AutoDetectChangesEnabled = false;
            //DB.Configuration.ValidateOnSaveEnabled = false;
            EMP employee = (GetAll().FirstOrDefault(x => x.ENAME.Equals(ENAME)));
            ctx.Entry(employee).State = EntityState.Modified;
            ctx.Set<EMP>().Attach(employee);
            ctx.Set<EMP>().Remove(employee);
            ctx.SaveChanges();
            Console.WriteLine("Remove employee");
        }
    }
}
