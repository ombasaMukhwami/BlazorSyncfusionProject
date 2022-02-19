using BlazoeProject.Contract;
using BlazoeProject.Repository;
using BlazoeProject.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoeProject.Server.Extensions
{
    public static class ServiceExtensions
    {
        //public static void ConfigureCors(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy(MyGlobalValues.CORS_POLICY,
        //                builder => builder.AllowAnyOrigin()
        //                .AllowAnyMethod()
        //                .AllowAnyHeader());
        //    });
        //}
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            //services.AddSingleton<ILoggerManeger, LoggerManeger>();
        }
        public static void ConfigureMysqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MySQLConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString)
            .EnableSensitiveDataLogging());
        }
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
