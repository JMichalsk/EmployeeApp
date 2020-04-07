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
    public class EditEmployeeHandlerTests : Configuration
    {
        [Fact]
        public async Task Handle_EditEmployeeFromDatabase_ReturnSuccessTrue()
        {
            // Arrange
            var employee = Employees[0];
            var employeeDto = new EmployeeDto() { Name = "Jonathan", Surname = "Smite" };

            // Act
            var result = await EditEmployeeHandler.Handle(new EditEmployee() { Id = employee.Id, Employee = employeeDto}, CancellationToken.None);

            // Assert
            result.Success.Should().Be(true);
            Employees.Last().Name.Should().Be(employeeDto.Name);
            Employees.Last().Surname.Should().Be(employeeDto.Surname);
        }

        [Fact]
        public async Task Handle_EditEmployeeThatNotExistInDatabase_ReturnSuccessFalse()
        {
            // Arrange
            var oldEmployee = Employees[0];
            var employee = new Employee(Guid.NewGuid(), "", "");
            var employeeDto = new EmployeeDto() { Name = "Jonathan", Surname = "Smite" };

            // Act
            var result = await EditEmployeeHandler.Handle(new EditEmployee() { Id = employee.Id, Employee = employeeDto }, CancellationToken.None);

            // Assert
            result.Success.Should().Be(false);
            Employees[0].Name.Should().Be(oldEmployee.Name);
            Employees[0].Surname.Should().Be(oldEmployee.Surname);
        }
    }
}
