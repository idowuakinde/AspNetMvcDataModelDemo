using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvcDataModelDemo.Models
{
    public class Employee
    {
        public Employee()
        {
            // Default Constructor. Do nothing
        }
        public Employee(int ID, string Name, DateTime JoiningDate, int Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.JoiningDate = JoiningDate;
            this.Age = Age;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }

    public class EmpDbContext : DbContext
    {
        public EmpDbContext()
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
