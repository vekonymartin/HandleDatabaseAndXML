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

        // ===========================================================================================
        // XML Dokumentáció url=http://users.nik.uni-obuda.hu/prog3/_progtools/prog_tools.pdf 17.oldal
        // 3 db '/'-et kell rakni a metódus fölött és autómatikusan legenerálja
        //                                  ||
        //                                  \/
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

       
        public void GetEverything()
        {
            var t1 = (from x in empRepo.GetAll()
                      select x).AsEnumerable(); // . ToArray()
            var t2 = (from x in deptRepo.GetAll()
                      select x).AsEnumerable(); // . ToArray()

            //           /\
            //           ||
            // ezt csak akkor kell alkalmazni ha egy másik lekérdezésre hivatkozok egy lekérdezésben
            // ======================================================================================== 

            var all = (from x in empRepo.GetAll().AsEnumerable()
                      join kapcs in deptRepo.GetAll().AsEnumerable() on x.DEPTNO equals kapcs.DEPTNO
                      select new Everything()
                      {
                          DEPTNO = (int)kapcs.DEPTNO,
                          DEPTNAME = kapcs.DNAME,
                          LOC = kapcs.LOC,
                          ENAME = x.ENAME,
                          EMPNO = (int)x.EMPNO,
                          HIREDATE = (DateTime)x.HIREDATE,
                          JOB = x.JOB,
                          MGR = (int)(x.MGR ?? 0),
                          SAL = (int)(x.SAL ?? 0),
                          COMM = (int)(x.COMM ?? 0)
                      }).AsEnumerable();
            foreach (var item in all)
            {
                Console.WriteLine(item.DEPTNAME + " " + item.ENAME + " " + item.SAL);
            }
        }

        /// <summary>
        /// Return list with Departments' name and people average salary whose work there
        /// </summary>
        /// <returns>List<AverageSalaryPerDepartment></returns>
        public IList<AverageSalaryPerDepartment> GetSalaryAveragePerDepartment()
        {
            var avg2 = (from e in empRepo.GetAll()
                        group e by e.DEPT into grp
                        select new AverageSalaryPerDepartment()
                        {
                            DepartmentName = grp.Key.DNAME,
                            AverageSalary = (double)grp.Average(x => x.SAL + (x.COMM ?? 0))
                            //                                                       /\
                            //                                                       ||
                            // ?? operátor: az NVL függvény megfelelője (ha a bal oldala null, behelyettesíti a jobb oldalt) 
                        }).AsEnumerable();// . ToArray();

            return avg2.ToList();
        }
    }
}
