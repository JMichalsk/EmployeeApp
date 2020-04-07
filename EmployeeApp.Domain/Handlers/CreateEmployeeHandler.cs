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
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, EmployeeCreatedResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeCreatedResponse> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeeDto, Employee>(request.Employee);

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();

            return new EmployeeCreatedResponse(true, "Employee created successfully");
        }
    }
}
