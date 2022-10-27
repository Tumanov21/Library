using Library.Infastructure.Persistence;
using Library.Infastructure.Persistence.Repositories.Command.Implementation;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infastructure.Persistence.Repositories.Query.Implementation;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(options
                => options.UseNpgsql(configuration.GetConnectionString("Connect")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IBookRepositoryCommand, BookRepositoryCommand>();
            services.AddScoped<IBookRepositoryQuery, BookRepositoryQuery>();
            services.AddScoped<ICategoryRepositoryCommand, CategoryRepositoryCommand>();
            services.AddScoped<ICategoryRepositoryQuery, CategoryRepositoryQuery>();
            return services;
        }
    }
}
