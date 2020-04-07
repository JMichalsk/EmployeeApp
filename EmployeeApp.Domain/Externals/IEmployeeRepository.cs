using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Domain.Model;

namespace EmployeeApp.Domain.Externals
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);

        Task<Employee> FindByIdAsync(Guid id);

        public void Update(Employee employee);

        void Delete(Employee employee);

        Task SaveAsync();
    }
}
