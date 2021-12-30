using System.Threading;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.StructuralServices
{
    public interface IUnitOfWork
    {
        int Complete(CancellationToken cancellationToken = new CancellationToken());
        Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
