using Excercise_2;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Excercise_2
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
            : base("name=EmployeeDBContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}