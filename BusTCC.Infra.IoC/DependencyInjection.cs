using BusTCC.Application.Interfaces;
using BusTCC.Application.Mappings;
using BusTCC.Application.Services;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
using BusTCC.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPreferenciaRepository, PreferenciaRepository>();

            // Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPreferenciaService, PreferenciaService>();


            return services;
        }
    }
}
