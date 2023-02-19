using System.Collections.Generic;

// Example taken from: https://dotnettutorials.net/lesson/repository-design-pattern-csharp/
namespace PPTA_Excercises.Excercise_2.EmployeeManagement
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();
    }
}