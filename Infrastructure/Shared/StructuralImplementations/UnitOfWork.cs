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
        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public int Complete()
        {
            this.ApplyAuditInformation();
            return _context.SaveChanges();
        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation();
            return await _context.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            _context.ChangeTracker
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
