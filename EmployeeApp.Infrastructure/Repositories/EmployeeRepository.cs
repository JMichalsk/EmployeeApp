using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Domain.Externals;
using EmployeeApp.Domain.Model;

namespace EmployeeApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _dbContext;
        public EmployeeRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Employee employee)
        {
            await _dbContext.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(Guid id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public void Update(Employee employee)
        {
            _dbContext.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _dbContext.Remove(employee);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
