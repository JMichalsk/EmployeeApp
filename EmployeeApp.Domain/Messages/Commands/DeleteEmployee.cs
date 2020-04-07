using System;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Messages.Commands
{
    public class DeleteEmployee : IRequest<EmployeeDeletedResponse>
    {
        public Guid Id { get; set; }
    }
}
