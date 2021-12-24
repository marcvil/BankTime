using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.StartUp.ServiceCollection
{
    public static class ServiceRegistration
    {
        public static void AddApplicationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(
                                                            configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(
                                                            configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
