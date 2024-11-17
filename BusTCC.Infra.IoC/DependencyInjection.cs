using BusTCC.Application.Interfaces;
using BusTCC.Application.Mappings;
using BusTCC.Application.Services;
using BusTCC.Domain.Account;
using BusTCC.Domain.Infra.Data;
using BusTCC.Domain.Interfaces;
using BusTCC.Infra.Data.Identity;
using BusTCC.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            services.AddAuthentication(opt => { 
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPreferenciaRepository, PreferenciaRepository>();
            services.AddScoped<ICatracaRepository, CatracaRepository>();
            services.AddScoped<IComunicacaoRepository, ComunicacaoRepository>();            
            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IPontoRepository, PontoRepository>();
            services.AddScoped<IOnibusRepository, OnibusRepository>();
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();

            // Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPreferenciaService, PreferenciaService>();
            services.AddScoped<ICatracaService, CatracaService>();
            services.AddScoped<IComunicacaoService, ComunicacaoService>();
            services.AddScoped<IRotaService, RotaService>();
            services.AddScoped<IPontoService, PontoService>();
            services.AddScoped<IOnibusService, OnibusService>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();


            return services;
        }
    }
}
