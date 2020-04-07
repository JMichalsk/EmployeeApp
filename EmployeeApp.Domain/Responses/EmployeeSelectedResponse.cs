using EmployeeApp.Domain.Dtos;

namespace EmployeeApp.Domain.Responses
{
    public class EmployeeSelectedResponse
    {
        public bool Success { get; set; }
        public EmployeeDto Employee { get; set; }
        public string Message { get; set; }

        public EmployeeSelectedResponse(string message)
        {
            Employee = default;
            Success = false;
            Message = message;
        }
        public EmployeeSelectedResponse(EmployeeDto employee)
        {
            Employee = employee;
            Success = true;
            Message = string.Empty;
        }
    }
}
