using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Domain.Responses
{
    public class EmployeeEditedResponse : BaseResponse
    {
        public EmployeeEditedResponse(bool success, string message) : base(success, message)
        {
        }
    }
}
