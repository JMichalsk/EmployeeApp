using System;
using System.Threading;
using System.Threading.Tasks;
using EmployeeApp.Domain.Messages.Queries;
using EmployeeApp.Domain.Model;
using FluentAssertions;
using Xunit;

namespace EmployeeApp.Tests.EmployeeApp.Domain
{
    public class GetEmployeeHandlerTests : Configuration
    {
        [Fact]
        public async Task Handle_GetEmployeeFromDatabase_ReturnSuccessTrue()
        {
            // Arrange
            var employee = Employees[0];

            // Act
            var result = await GetEmployeeHandler.Handle(new GetEmployee() { Id = employee.Id }, CancellationToken.None);

            // Assert
            result.Success.Should().Be(true);
            result.Employee.Name.Should().Be(employee.Name);
            result.Employee.Surname.Should().Be(employee.Surname);
        }

        [Fact]
        public async Task Handle_GetEmployeeThatNotExistInDatabase_ReturnSuccessFalse()
        {
            // Arrange
            var employee = new Employee(Guid.NewGuid(), "", "");

            // Act
            var result = await GetEmployeeHandler.Handle(new GetEmployee() { Id = employee.Id }, CancellationToken.None);

            // Assert
            result.Success.Should().Be(false);
            result.Employee.Should().BeNull();
        }
    }
}
