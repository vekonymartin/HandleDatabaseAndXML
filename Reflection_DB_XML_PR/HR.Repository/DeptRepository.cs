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
    public class DeptRepository : Repository<DEPT>, IDeptRepository
    {
        public DeptRepository(DbContext ctx) : base(ctx) { }
        
        public void ChangeLocation(int DEPTNO, string newCity)
        {
            var loc = GetOne(DEPTNO);
            loc.LOC = newCity;
            ctx.SaveChanges();
        }

        public override DEPT GetOne(int DEPTNO)
        {
            return GetAll().FirstOrDefault(x => x.DEPTNO == DEPTNO);
        }

        public void InsertNewDept(int DEPTNO, string DEPTNAME, string LOC)
        {
            DEPT newDeptData = new DEPT()
            {
                DEPTNO = DEPTNO,
                DNAME = DEPTNAME,
                LOC = LOC
            };
            ctx.Set<DEPT>().Add(newDeptData);
            ctx.SaveChanges();
            Console.WriteLine("Insert new row");
        }
        /*
         *===================================================================================
         *        /\
         *        || ez a kettő ugyan az, a különbség, hogy az egyikhez egy objectet adok át,
         *        \/ míg a másikhoz adatokat
         *===================================================================================
         */
        public void InsertNewDept(DEPT newDeptData)
        {
            ctx.Set<DEPT>().Add(newDeptData);
            ctx.SaveChanges();
            Console.WriteLine("Insert new row");
        }

        public void RemoveLocation(string location)
        {
            //DB.Configuration.AutoDetectChangesEnabled = false;
            ctx.Configuration.ValidateOnSaveEnabled = true;
            DEPT loc = GetAll().Single(x => x.LOC == location);
            ctx.Entry(loc).State = EntityState.Modified;
            ctx.Set<DEPT>().Remove(loc);
            ctx.SaveChanges();
            Console.WriteLine($"Remove {location} data");
        }
        public void InsertOneData(int ID, string newCity)
        {
            var row = GetOne(ID);
            row.LOC = newCity;
            ctx.SaveChanges();
            Console.WriteLine("Insert new data");
        }
    }
}
