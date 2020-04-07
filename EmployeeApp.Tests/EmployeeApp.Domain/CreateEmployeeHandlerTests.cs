using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Messages.Commands;
using EmployeeApp.Domain.Model;
using FluentAssertions;
using Xunit;

namespace EmployeeApp.Tests.EmployeeApp.Domain
{
    public class CreateEmployeeHandlerTests : Configuration
    {

        [Fact]
        public async Task Handle_CreateEmployee_ReturnSuccessTrue()
        {
            // Arrange
            var employeeDto = new EmployeeDto() { Name = "Jonathan", Surname = "Smite" };
            var employeesCount = Employees.Count;

            // Act
            var result = await CreateEmployeeHandler.Handle(new CreateEmployee() {Employee = employeeDto}, CancellationToken.None);

            // Assert
            result.Success.Should().Be(true);
            Employees.Count.Should().Be(employeesCount + 1);
            Employees.Last().Name.Should().Be(employeeDto.Name);
            Employees.Last().Surname.Should().Be(employeeDto.Surname);
        }
    }
}
