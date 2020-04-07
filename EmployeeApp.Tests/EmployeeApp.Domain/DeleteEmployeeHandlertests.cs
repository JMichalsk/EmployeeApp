using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Handlers;
using EmployeeApp.Domain.Messages.Commands;
using FluentAssertions;
using Xunit;

namespace EmployeeApp.Tests.EmployeeApp.Domain
{
    public class DeleteEmployeeHandlerTests : Configuration
    {
        [Fact]
        public async Task Handle_DeleteEmployeeFromDatabase_ReturnSuccessTrue()
        {
            // Arrange
            var employeeId = Employees[0].Id;
            var employeesCount = Employees.Count;

            // Act
            var result = await DeleteEmployeeHandler.Handle(new DeleteEmployee() { Id = employeeId }, CancellationToken.None);

            // Assert
            result.Success.Should().Be(true);
            Employees.Count.Should().Be(employeesCount - 1);
        }

        [Fact]
        public async Task Handle_DeleteEmployeeThatNotExistInDatabase_ReturnSuccessFalse()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employeeCount = Employees.Count;

            // Act
            var result = await DeleteEmployeeHandler.Handle(new DeleteEmployee() { Id = employeeId }, CancellationToken.None);

            // Assert
            result.Success.Should().Be(false);
            Employees.Count.Should().Be(employeeCount);
        }
    }
}
