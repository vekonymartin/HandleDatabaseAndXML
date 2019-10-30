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
    }
}
