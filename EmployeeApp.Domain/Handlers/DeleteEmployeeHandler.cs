using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeApp.Domain.Externals;
using EmployeeApp.Domain.Messages.Commands;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, EmployeeDeletedResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDeletedResponse> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByIdAsync(request.Id);
            if (employee == null)
            {
                return new EmployeeDeletedResponse(false, "Could not delete employee");
            }

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveAsync();

            return new EmployeeDeletedResponse(true, "Employee deleted successfully");
        }
    }
}
