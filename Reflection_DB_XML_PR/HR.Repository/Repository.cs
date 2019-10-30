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
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetOne(int id);
    }
}
