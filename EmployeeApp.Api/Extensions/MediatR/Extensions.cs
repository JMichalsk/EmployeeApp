using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Api.Extensions.MediatR
{
    public static class Extensions
    {
        public static void AddMediator(this IServiceCollection services)
        {
            var domainAssembly = AppDomain.CurrentDomain.Load("EmployeeApp.Domain");

            services.AddMediatR(domainAssembly);
        }
    }
}
