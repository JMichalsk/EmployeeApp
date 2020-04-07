using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EmployeeApp.Api.Extensions.Swagger
{
    public static class Extensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
                setup.SwaggerDoc("v1", new OpenApiInfo() {Title = "Employees Api", Version = "v1"}));
        }
    }
}
