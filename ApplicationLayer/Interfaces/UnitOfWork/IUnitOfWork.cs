using BankTimeApp.Infrastructure.Persistence.Context;
using System.Threading;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.StructuralServices
{
    public interface IUnitOfWork
    {
        int Complete(ApplicationDbContext dbContext, CancellationToken cancellationToken = new CancellationToken());
        Task<int> CompleteAsync(ApplicationDbContext dbContext,CancellationToken cancellationToken = new CancellationToken());
    }
}
