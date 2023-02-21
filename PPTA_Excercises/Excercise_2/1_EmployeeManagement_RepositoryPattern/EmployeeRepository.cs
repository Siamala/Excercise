using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PPTA_Excercises.Excercise_2.EmployeeManagement
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository()
        {
            _context = new EmployeeDBContext();
        }

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        
        public Employee GetById(int employeeID)
        {
            return _context.Employees.Find(employeeID);
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
            Save();
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            Save();
        }

        public void Delete(int employeeID)
        {
            _context.Employees.Remove(GetById(employeeID));
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}