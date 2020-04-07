using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Domain.Model
{
    public class Employee
    {
        public Employee(Guid id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        private Employee()
        {
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}
