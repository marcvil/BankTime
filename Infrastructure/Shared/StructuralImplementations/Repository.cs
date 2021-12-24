using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTimeApp.Infrastructure.Shared.StructuralImplementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public async Task<T> GetByIdAsync(int id)
        {
           return  await _entities.FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await _entities
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .AsNoTracking()
                            .ToListAsync();
        }

       
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

     

       

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public  void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void  DeleteRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}
