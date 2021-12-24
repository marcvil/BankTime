using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Infrastructure.Identity.Context
{
    public class IdentitytDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {


        public IdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-DUTALF4;Database=BankTimeApp;Trusted_Connection=True;",
                    options => options.EnableRetryOnFailure());

            return new IdentityDbContext(optionsBuilder.Options);
        }
    }
}
