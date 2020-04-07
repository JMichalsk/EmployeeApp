using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Domain.Responses
{
    public class EmployeeDeletedResponse : BaseResponse
    {
        public EmployeeDeletedResponse(bool success, string message) : base(success, message)
        {
        }
    }
}
