﻿using System;
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
            // Add a comment
            IEmployeeManager client = new EmployeeManager();
            client.Run();

            Console.WriteLine("Hi there!");
        }
    }
}
