using BankTimeApp.Domain.Entities;
using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using System.Threading.Tasks;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BankTimeApp.ApplicationLayer;
using System.Linq;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using System.Collections.Generic;

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
                    return new Response<Category>("Categoria no encontrada");
                }
                return new Response<Category>(category);
            }
      
        }
        public Response<Category> GetByName(string name)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var category = dbContext.Categories.FirstOrDefault(x => x.Name == name);

                if (category == null)
                {
                    return new Response<Category>("Categoria no encontrada");
                }
                return new Response<Category>(category);
            }
 
        }

        public Response<List<Category>> GetAll()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var categories = dbContext.Categories.ToList();

                if (categories.Count == 0)
                {
                    return new Response<List<Category>>("No existe ninguna categoria");
                }
                return new Response<List<Category>>(categories);
            }

        }
        public Response<Category> Post(Category category)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var categoryExists = GetByName(category.Name);

                if (categoryExists.Data != null)
                {
                    return new Response<Category>("Ya existe una tarea con este nombre con este nombre");
                }

                dbContext.Categories.Add(category);
                _unitOfWork.Complete(dbContext);

                return new Response<Category>(category);
            }
            return null;
        }

    }
}
