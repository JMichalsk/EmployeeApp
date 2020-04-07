using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Externals;
using EmployeeApp.Domain.Messages.Queries;
using EmployeeApp.Domain.Model;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployee, EmployeeSelectedResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeSelectedResponse> Handle(GetEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByIdAsync(request.Id);
            if (employee == null)
            {
                return new EmployeeSelectedResponse("Could not get employee");
            }

            var employeeDto = _mapper.Map<Employee, EmployeeDto>(employee);
            return new EmployeeSelectedResponse(employeeDto);
        }
    }
}
