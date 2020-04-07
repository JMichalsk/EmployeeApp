using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Messages.Commands
{
    public class CreateEmployee : IRequest<EmployeeCreatedResponse>
    {
        public EmployeeDto Employee { get; set; }
    }
}
