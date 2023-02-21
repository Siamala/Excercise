using PPTA_Excercises.Excercise_2.EmployeeManagement;
using System;
using System.Collections.Generic;

namespace PPTA_Excercises.Excercise_2._1_EmployeeManagement_RepositoryPattern
{
    public class EmployeeController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Search for Employee by <paramref name="employeeID"/>
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>Employee or null</returns>
        public Employee GetById(int employeeID)
        {
            return _employeeRepository.GetById(employeeID);
        }

        /// <summary>
        /// Returns all Employees from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        /// <summary>
        /// Adds <paramref name="employee"/> to database, or throws Exception when EmployeeId already exists
        /// </summary>
        /// <param name="employee"></param>
        public void Insert(Employee employee)
        {
            if (_employeeRepository.GetById(employee.EmployeeID) == null)
            {
                _employeeRepository.Insert(employee);
            }
            else
            {
                throw new Exception($"Employee with employeeId: {employee.EmployeeID} exists already in database");
            }
        }

        /// <summary>
        /// Updates <paramref name="employee"/> properties in database
        /// </summary>
        /// <exception cref="Exception">When EmployeeId does not exist in database</exception>
        /// <param name="employee"></param>
        public void Update(Employee employee)
        {
            if (_employeeRepository.GetById(employee.EmployeeID) == null)
            {
                throw new Exception($"Employee with employeeId: {employee.EmployeeID} does not exist in database");
            }
            else
            {
                _employeeRepository.Update(employee);
            }
        }

        /// <summary>
        /// Deletes Employee under <paramref name="employeeID"/>
        /// </summary>
        /// <exception cref="Exception">Throws when <paramref name="employeeID"/> does not exist in database</exception>
        /// <param name="employeeID"></param>
        public void Delete(int employeeID)
        {
            if (_employeeRepository.GetById(employeeID) == null)
            {
                throw new Exception($"Employee with employeeId: {employeeID} does not exist in database");
            }
            else
            {
                _employeeRepository.Delete(employeeID);
            }
        }
    }
}
