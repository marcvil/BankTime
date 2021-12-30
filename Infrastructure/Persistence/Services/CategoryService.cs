using BankTimeApp.Domain.Entities;
using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using System.Threading.Tasks;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BankTimeApp.ApplicationLayer;
using System.Linq;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;

namespace BankTimeApp.Infrastructure.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly ApplicationDbContextFactory _contextFactory;
       
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ApplicationDbContextFactory context, IUnitOfWork unitOfWork)
        {
            _contextFactory = context;
            _unitOfWork = unitOfWork;
        }
        public Response<Category> GetById(int id)
        {
            using(var dbContext = _contextFactory.CreateDbContext())
            {
                var category = dbContext.Categories.Find(id);
                if (category == null)
                {
                    return new Response<Category>("Not found");
                }
                return new Response<Category>(category);
            }
      
        }
        public Response<Category> GetByName(string name)
        {
            //var category =  repository.FirstOrDefault(x => x.Name == name);

            // if (category == null)
            // {
            //     return new Response<Category>("Doesn't exist");
            // }
            // return new Response<Category>(category);
            return null;
        }
        public Response<Category> Post(Category category)
        {
            //var categoryExists = GetByName(category.Name);

            //if (categoryExists.Data != null)
            //{
            //    return new Response<Category>("Already exist with this name");
            //}

            // _context.Add(category);
            // _unitOfWork.Complete();

            //return new Response<Category>(category);
            return null;
        }
    }
}
