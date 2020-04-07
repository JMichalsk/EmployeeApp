using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApp.Domain.Externals;
using EmployeeApp.Domain.Handlers;
using EmployeeApp.Domain.Mappings;
using EmployeeApp.Domain.Model;
using Moq;

namespace EmployeeApp.Tests.EmployeeApp.Domain
{
    public class Configuration
    {
        protected IList<Employee> Employees;

        protected CreateEmployeeHandler CreateEmployeeHandler;
        protected GetEmployeeHandler GetEmployeeHandler;
        protected DeleteEmployeeHandler DeleteEmployeeHandler;
        protected EditEmployeeHandler EditEmployeeHandler;

        public Configuration()
        {
            Employees = new List<Employee>()
                {new Employee(Guid.NewGuid(), "John", "Smith"), new Employee(Guid.NewGuid(), "Abby", "Black")};

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid i) => Employees.FirstOrDefault(empl => empl.Id.Equals(i)));

            employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>()))
                .Callback((Employee empl) => Employees.Add(new Employee(Guid.NewGuid(), empl.Name, empl.Surname))).Returns(Task.CompletedTask);
            
            employeeRepositoryMock.Setup(x => x.Delete(It.IsAny<Employee>())).Callback((Employee empl) =>
            {
                int index = Employees.IndexOf(empl);
                Employees.RemoveAt(index);
            });

            employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>())).Callback((Employee empl) =>
            {
                var oldEmployee = Employees.FirstOrDefault(se => se.Id.Equals(empl.Id));
                Employees.Remove(oldEmployee);
                Employees.Add(empl);
            });

            employeeRepositoryMock.Setup(x => x.SaveAsync());

            var mockedMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModel());
                cfg.AddProfile(new ModelToDto());
            }).CreateMapper();

            CreateEmployeeHandler = new CreateEmployeeHandler(mockedMapper, employeeRepositoryMock.Object);
            GetEmployeeHandler = new GetEmployeeHandler(mockedMapper, employeeRepositoryMock.Object);
            DeleteEmployeeHandler = new DeleteEmployeeHandler(employeeRepositoryMock.Object);
            EditEmployeeHandler = new EditEmployeeHandler(mockedMapper, employeeRepositoryMock.Object);
        }
    }
}
