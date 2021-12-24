using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.StructuralServices
{
    public interface IRepository<T> where T : class
    {
        //General Get Methods
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<IReadOnlyList<T>> GetAllPagedAsync(int pageNumber, int pageSize);


        //Proper Crud
        public Task AddAsync(T entity);
        public Task AddRangeAsync(IEnumerable<T> entities);

        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entities);

    }
}
