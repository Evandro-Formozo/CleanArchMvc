using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext> (options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b =>
            b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            /* - Registrado o contexto DbContext.
             * - Definido o provedor de banco de dados: UseSqlServer / Definiu a string de conexão: DefaultConnection
             * - Informado que a migração vai ficar na pasta onde esta definido o arquivo de contexto, no projeto onde esta
             *   definido o arquivo de contexto: Projeto Infra.Data
             */

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
