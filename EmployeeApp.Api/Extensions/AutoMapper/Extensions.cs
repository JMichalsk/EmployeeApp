using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Api.Extensions.AutoMapper
{
    public static class Extensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("EmployeeApp.Domain"));
        }
    }
}
