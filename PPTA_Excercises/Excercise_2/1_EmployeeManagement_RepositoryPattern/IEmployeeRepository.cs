using System.Collections.Generic;

// Example taken from: https://dotnettutorials.net/lesson/repository-design-pattern-csharp/
namespace PPTA_Excercises.Excercise_2.EmployeeManagement
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Returns all Employees from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();

        /// <summary>
        /// Search for Employee by <paramref name="employeeID"/>
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Employee or null</returns>
        Employee GetById(int employeeID);

        /// <summary>
        /// Adds <paramref name="employee"/> to database, or throws Exception when EmployeeId already exists
        /// </summary>
        /// <exception cref="Exception">Throws when employeeId already exists in database</exception>
        /// <param name="employee"></param>
        void Insert(Employee employee);

        /// <summary>
        /// Updates <paramref name="employee"/> properties in database
        /// </summary>
        /// <exception cref="Exception">When EmployeeId does not exist in database</exception>
        /// <param name="employee"></param>
        void Update(Employee employee);

        /// <summary>
        /// Deletes Employee under <paramref name="employeeID"/>
        /// </summary>
        /// <exception cref="Exception">Throws when <paramref name="employeeID"/> does not exist in database</exception>
        /// <param name="employeeID"></param>
        void Delete(int employeeID);
    }
}