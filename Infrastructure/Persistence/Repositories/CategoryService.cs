using BankTimeApp.Domain.Entities;
using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using System.Threading.Tasks;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BankTimeApp.ApplicationLayer;
using System.Linq;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;

namespace BankTimeApp.Infrastructure.Persistence.Repositories
{
    public class CategoryService : ICategoryService
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<Category> repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            repository = context.Set<Category>();
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Category>> GetById(int id)
        {
            var category = await repository.FindAsync(id);
            if(category == null)
            {
                return new Response<Category>("Not found");
            }
            return new Response<Category>(category);
        }
        public async Task<Response<Category>> GetByName(string name)
        {
            //var category = await repository.FirstOrDefaultAsync(x => x.Name == name);
            var category = new Category();
            category = null;
            if (category == null)
            {
                return new Response<Category>("Doesn't exist");
            }
            return new Response<Category>(category);
        }
        public async Task<Response<Category>> Post(Category category)
        {
            var categoryExists = await GetByName(category.Name);

            if (categoryExists.Data != null)
            {
                return new Response<Category>("Already exist with this name");
            }

            await _context.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return new Response<Category>(category);
        }
    }
}
