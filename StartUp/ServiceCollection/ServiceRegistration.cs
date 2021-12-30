using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BankTimeApp.StartUp.ServiceCollection
{
    public static class ServiceRegistration
    {
        public static void AddApplicationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                       options.UseSqlite("Filename=Database.db", options =>
                                                       {
                                                           options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                                                       }));
        }

        public static void AddIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                       options.UseSqlite("Filename=Database.db", options =>
                                                       {
                                                           options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                                                       }));
        }
    }
}
