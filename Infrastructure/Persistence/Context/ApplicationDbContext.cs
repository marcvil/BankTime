using BankTimeApp.Domain.Entities;
using BankTimeApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankTimeApp.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    
        public DbSet<Exchanges> Exchanges { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("BankTimeApp");
           
        }
    }
}
