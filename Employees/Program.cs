using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EmployeeManager();
            client.Run();

            //string dateString = "2008-06-11";
            //string expectedFormat = "yyyy-MM-dd";
            //DateTime theDate;
            //bool result = DateTime.TryParseExact(
            //    dateString,
            //    expectedFormat,
            //    System.Globalization.CultureInfo.InvariantCulture,
            //    System.Globalization.DateTimeStyles.None,
            //    out theDate);
            //if (result)
            //{
            //    Console.WriteLine(theDate.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Date string is not in the correct format.");
            //}
        }
    }
}
