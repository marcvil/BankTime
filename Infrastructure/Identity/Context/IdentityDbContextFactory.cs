using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BankTimeApp.Infrastructure.Identity.Context
{
    public class IdentitytDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {


        public IdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            optionsBuilder.UseSqlite("Filename=Database.db",options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            return new IdentityDbContext(optionsBuilder.Options);
        }
    }
}
