using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Infrastructure
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

    }
}
