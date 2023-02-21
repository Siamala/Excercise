using PPTA_Excercises.Excercise_2.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTA_Excercises.Tests.Excercise_2._1_EmployeeManagement.Data
{
    public class EmployeesHelper
    {
        public static List<Employee> EmployeesDb = new List<Employee>()
        {
            new Employee()
            {
                EmployeeID = 1,
                Dept = "Sales",
                Gender = "Male",
                Name = "Mark",
                Salary = 3000
            },
            new Employee()
            {
                EmployeeID = 2,
                Dept = "Sales",
                Gender = "Female",
                Name = "Diana",
                Salary = 3500
            },
            new Employee()
            {
                EmployeeID = 2,
                Dept = "Engineering",
                Gender = "Male",
                Name = "John",
                Salary = 2500
            }
        };
    }
}
