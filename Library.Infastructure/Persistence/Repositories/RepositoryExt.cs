using Library.Infastructure.Data.Repositories.Command.Implementation;
using Library.Infastructure.Data.Repositories.Command.Interface;
using Library.Infastructure.Data.Repositories.Query.Implementation;
using Library.Infastructure.Data.Repositories.Query.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Persistence.Repositories
{
    public static class RepositoryExt
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepositoryCommand, BookRepositoryCommand>();
            services.AddScoped<IBookRepositoryQuery, BookRepositoryQuery>();
            services.AddScoped<ICategoryRepositoryCommand, CategoryRepositoryCommand>();
            services.AddScoped<ICategoryRepositoryQuery, CategoryRepositoryQuery>();
        }
    }
}
