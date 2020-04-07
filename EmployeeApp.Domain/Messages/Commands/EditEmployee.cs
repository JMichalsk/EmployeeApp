using System;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Messages.Commands
{
    public class EditEmployee : IRequest<EmployeeEditedResponse>
    {
        public Guid Id { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
