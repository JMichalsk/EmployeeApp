using System;
using EmployeeApp.Domain.Responses;
using MediatR;

namespace EmployeeApp.Domain.Messages.Queries
{
    public class GetEmployee : IRequest<EmployeeSelectedResponse>
    {
        public Guid Id { get; set; }
    }
}
