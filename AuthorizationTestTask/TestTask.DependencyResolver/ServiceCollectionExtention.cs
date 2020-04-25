using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Services.Contracts;
using TestTask.Services.Implementations;

namespace TestTask.DependencyResolver
{
    public static class ServiceCollectionExtention
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserService, UserService>();
            
        }
    }
}
