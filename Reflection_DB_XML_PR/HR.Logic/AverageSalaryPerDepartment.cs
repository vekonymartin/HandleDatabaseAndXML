using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Logic
{
    public class AverageSalaryPerDepartment
    {
        public string DepartmentName { get; set; }
        public double AverageSalary { get; set; }

        public override string ToString()
        {
            return $"DEPARTMENT NAME = {DepartmentName}\n AVERAGE SALARY = {AverageSalary}";
        }
    }
}
