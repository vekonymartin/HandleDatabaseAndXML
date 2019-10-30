namespace HR.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMP")]
    public partial class EMP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMP()
        {
            EMP1 = new HashSet<EMP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal EMPNO { get; set; }

        [StringLength(10)]
        public string ENAME { get; set; }

        [StringLength(9)]
        public string JOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MGR { get; set; }

        public DateTime? HIREDATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? COMM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DEPTNO { get; set; }

        public virtual DEPT DEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMP> EMP1 { get; set; }

        public virtual EMP EMP2 { get; set; }
    }
}
