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
        public string EmpID { get; set; }
        public string ProjectID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DaysWorked { get; set; }
    }
}
