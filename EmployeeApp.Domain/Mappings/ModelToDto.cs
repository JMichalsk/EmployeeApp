using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EmployeeApp.Domain.Dtos;
using EmployeeApp.Domain.Model;

namespace EmployeeApp.Domain.Mappings
{
    public class ModelToDto : Profile
    {
        public ModelToDto()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
