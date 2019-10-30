namespace HR.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRDBContext : DbContext
    {
        public HRDBContext()
            : base("name=HRDBContext")
        {
        }

        public virtual DbSet<DEPT> DEPTs { get; set; }
        public virtual DbSet<EMP> EMPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPT>()
                .Property(e => e.DEPTNO)
                .HasPrecision(2, 0);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.DNAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .Property(e => e.LOC)
                .IsUnicode(false);

            modelBuilder.Entity<DEPT>()
                .HasMany(e => e.EMPs)
                .WithRequired(e => e.DEPT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMP>()
                .Property(e => e.EMPNO)
                .HasPrecision(4, 0);

            modelBuilder.Entity<EMP>()
                .Property(e => e.ENAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP>()
                .Property(e => e.JOB)
                .IsUnicode(false);

            modelBuilder.Entity<EMP>()
                .Property(e => e.MGR)
                .HasPrecision(4, 0);

            modelBuilder.Entity<EMP>()
                .Property(e => e.SAL)
                .HasPrecision(7, 2);

            modelBuilder.Entity<EMP>()
                .Property(e => e.COMM)
                .HasPrecision(7, 2);

            modelBuilder.Entity<EMP>()
                .Property(e => e.DEPTNO)
                .HasPrecision(2, 0);

            modelBuilder.Entity<EMP>()
                .HasMany(e => e.EMP1)
                .WithOptional(e => e.EMP2)
                .HasForeignKey(e => e.MGR);
        }
    }
}
