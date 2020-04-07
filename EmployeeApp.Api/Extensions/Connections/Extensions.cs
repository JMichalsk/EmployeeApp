using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Infrastructure;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Api.Extensions.Connections
{
    public static class Extensions
    {
        public static void AddDbConnections(this IServiceCollection services)
        {
            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase("EmployeesDb"));
        }
    }
}
