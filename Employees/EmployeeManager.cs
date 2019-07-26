using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace Employees
{
    internal class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeManager()
        {
            this.employees = BuildStructure();
        }

        /// <summary>
        /// Builds list of employee objects.
        /// </summary>
        /// <returns></returns>
        public List<Employee> BuildStructure()
        {
            string path = ConfigurationManager.AppSettings["filePath"];

            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path).Skip(1);

                try
                {
                    foreach (var line in lines)
                    {
          
                        string[] fields = line.Split(new[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                      
                        if (fields.Length == Constants.NUMBER_REQUIRED_COLUMNS)
                        {
                            var employee = new Employee()
                            {
                                EmpID = fields[0],
                                ProjectID = fields[1],
                                DateFrom = ParseDates(fields[2]),
                                DateTo = ParseDates(fields[3])
                            };

                            employee.DaysWorked = (employee.DateTo - employee.DateFrom).Days;
                            employees.Add(employee);
                        }
                        else
                        {
                            throw new Exception("Invalid data source");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            }

            return employees;
        }

        /// <summary>
        /// Parses string date formats
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        private DateTime ParseDates(string date)
        {
            string[] expectedFormats = { "yyyy-MM-dd", "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy" };

            if (date == "NULL")
            {
                return DateTime.Today;
            }

            bool result = DateTime.TryParseExact(date, 
                                                 expectedFormats,
                                                 CultureInfo.InvariantCulture, 
                                                 DateTimeStyles.None, 
                                                 out DateTime theDate);
            if (result)
            {
                return theDate;
            }
            else
            {
                throw new Exception("Date incorrect format, please use one the following format: yyyy-MM-dd,MM/dd/yyyy,M/dd/yyyy,MM/d/yyyy");
            }
        }

        /// <summary>
        /// Sorts, groups and dispaly the result.
        /// </summary>
        public void Run()
        {
            if (employees.Count > 0)
            {
                var sortByDaysWorkedAndGroupByProject = employees.OrderByDescending(e => e.DaysWorked)
                                                                 .GroupBy(e => e.ProjectID)
                                                                 .ToList();

                foreach (var group in sortByDaysWorkedAndGroupByProject)
                {
                    int count = group.Count();
                    if (count > 1)
                    {
                        Console.WriteLine($"---For Project {group.Key} the two employees are:");
                        for (var i = 0; i < Constants.NUMBER_OF_EMPLOYEES_TO_BE_SHOWN; i++)
                        {
                            Console.WriteLine($"Emp: {group.ElementAt(i).EmpID} Project: {group.ElementAt(i).ProjectID}, Days Worked: {group.ElementAt(i).DaysWorked}");
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("----File is empty or does not exists----");
            }

        }
    }
}
