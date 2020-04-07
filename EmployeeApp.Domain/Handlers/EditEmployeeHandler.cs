using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Externals;
using EmployeeApp.Domain.Messages.Commands;
using EmployeeApp.Domain.Model;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Handlers
{
    public class EditEmployeeHandler : IRequestHandler<EditEmployee, EmployeeEditedResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EditEmployeeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeEditedResponse> Handle(EditEmployee request, CancellationToken cancellationToken)
        {
            var oldEmployee = await _employeeRepository.FindByIdAsync(request.Id);
            if (oldEmployee == null)
                return new EmployeeEditedResponse(false, "Couldn't edit employee");

            var employee = new Employee(request.Id, request.Employee.Name, request.Employee.Surname);
            _employeeRepository.Update(employee);
            await _employeeRepository.SaveAsync();

            return new EmployeeEditedResponse(true, "Employee successfully edited");
        }
    }
}
