using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApp.Domain.Dtos;

namespace EmployeeApp.Domain.Responses
{
    public class EmployeeCreatedResponse : BaseResponse
    {
        public EmployeeCreatedResponse(bool success, string message) : base(success, message)
        {
        }
    }
}
