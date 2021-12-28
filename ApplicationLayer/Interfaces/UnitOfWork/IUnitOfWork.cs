using System.Threading;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.StructuralServices
{
    public interface IUnitOfWork
    {
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
