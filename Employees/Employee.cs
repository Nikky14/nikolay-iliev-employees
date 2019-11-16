using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// An employee object
    /// </summary>
    internal class Employee
    {
        public int EmpID { get; set; }
        public int ProjectID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DaysWorked { get; set; }
    }

    internal class Test
    {
        public int Id { get; set; }
    }
}
