﻿using Contracts;
using Logger;
using Repository;
using Service.Contract;
using Service;
using Microsoft.EntityFrameworkCore;

namespace MakeWeBet.API.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
            => services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().
                    AllowAnyMethod().
                    AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services)
            => services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLogger(this IServiceCollection services)
        => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
