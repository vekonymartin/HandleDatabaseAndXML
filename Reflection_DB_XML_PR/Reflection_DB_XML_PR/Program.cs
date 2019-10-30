using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// --------------------------------
//         SAJÁT IMPORTOK
using HR.Logic;     
using HR.Data;
// --------------------------------
namespace Reflection_DB_XML_PR
{
    class Program
    {
        #region Test_Sector
        public static void CheckDBConnecting()
        {
            HRDBContext hr = new HRDBContext();
            Console.WriteLine("DEPARTMENT");
            foreach (var item in hr.DEPTs)
            {
                Console.WriteLine($"ID={item.DEPTNO}\tNAME={item.DNAME}\tLOCATION={item.LOC}");
            }
            Console.WriteLine("EMPLOYEE");
            foreach (var item in hr.EMPs)
            {
                Console.WriteLine($"{item.DEPTNO}\t{item.ENAME}\t{item.JOB}\t{item.SAL}" +
                    $"{item.MGR}\t{item.DEPTNO}\t{item.HIREDATE}\t{item.COMM}");
            }
            Console.WriteLine(new string('=',50));
        }
        public static void CheckSeparatedClass()
        {
            EmpLogic empLogic = new EmpLogic();

            //foreach (var item in empLogic.GetAllEmployee())
            //    Console.WriteLine(item.ENAME);
            //      ||
            //      \/
            // ugyan az, annyi a különbség, hogy a másiknál nem adtam meg, hogy milyen adatokat szeretnék látni
            //      ||
            //      \/ 
            DisplayConsole.ResultOnConsole(empLogic.GetAllEmployee());

            Console.WriteLine("\n" + new string('-', 10) + "\n " + empLogic.GetOneEmp(7369).ENAME);
        }
        public static void CheckContractedClass()
        {
            HRLogic hr = new HRLogic();

            foreach (var item in hr.GetAllDepartment())
            {
                Console.WriteLine("DEPTNO = {0}\tDNAME = {1}\tLOC= {2}",item.DEPTNO,item.DNAME, item.LOC);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            //CheckDBConnecting();
            //CheckSeparatedClass();
            CheckContractedClass();


            Console.ReadLine();
        }
    }
}
