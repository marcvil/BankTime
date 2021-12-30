using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankTimeApp.Infrastructure.Shared.StructuralImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
       


        public UnitOfWork()
        {
        
        }



        public int Complete(ApplicationDbContext dbContext,CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation( dbContext);
            return dbContext.SaveChanges();
        }
        public async Task<int> CompleteAsync(ApplicationDbContext dbContext,CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation(dbContext);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation(ApplicationDbContext dbContext)
        {
            dbContext.ChangeTracker
            .Entries()
            .ToList()
            .ForEach(entry =>
            {
                if (entry.Entity is IEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                        entity.CreatedBy = "Marc";
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.ModifiedOn = DateTime.UtcNow;
                        entity.ModifiedBy = "Marc";
                    }
                }
            });
        }


    }
}
