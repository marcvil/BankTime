using System.Threading;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.StructuralServices
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync(CancellationToken token = new CancellationToken());
    }
}
