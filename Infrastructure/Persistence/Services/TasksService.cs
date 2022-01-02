using BankTimeApp.ApplicationLayer;
using BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces;
using BankTimeApp.ApplicationLayer.Interfaces.StructuralServices;
using BankTimeApp.Domain.Entities;
using BankTimeApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BankTimeApp.Domain.Enums.Enums;

namespace BankTimeApp.Infrastructure.Persistence.Services
{
    public class TasksService : ITasksService
    {
        protected readonly ApplicationDbContextFactory _contextFactory;

        private readonly IUnitOfWork _unitOfWork;

        public TasksService(ApplicationDbContextFactory context, IUnitOfWork unitOfWork)
        {
            _contextFactory = context;
            _unitOfWork = unitOfWork;
        }
        public Response<Tasks> GetById(int id)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var task = dbContext.Tasks.Find(id);
                if (task == null)
                {
                    return new Response<Tasks>("Not found");
                }
                return new Response<Tasks>(task);
            }

        }
        public Response<Tasks> GetByName(string name)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var task = dbContext.Tasks.Include(x=>x.Exchange).FirstOrDefault(x => x.Name == name);

                if (task == null)
                {
                    return new Response<Tasks>("Doesn't exist");
                }
                return new Response<Tasks>(task);
            }
            
        }

        public Response<List<Tasks>> GetAll()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var tasks = dbContext.Tasks.Include(x => x.Exchange).ToList();

                if (tasks.Count == 0)
                {
                    return new Response<List<Tasks>>("No existen tareas");
                }
                return new Response<List<Tasks>>(tasks);
            }

        }
        public Response<Tasks> Post(Tasks task)
        {

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var taskExists = dbContext.Tasks.FirstOrDefault(x => x.Name == task.Name);

                if (taskExists != null)
                {
                    return new Response<Tasks>("AlreadyExists");
                }

                dbContext.Tasks.Add(task);
                _unitOfWork.Complete(dbContext);

                return new Response<Tasks>(task);
            }

 
        }

        public Response<Tasks> Update(Tasks task)
        {

            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var taskExists = dbContext.Tasks.FirstOrDefault(x => x.Id == task.Id);

                if (taskExists == null)
                {
                    return new Response<Tasks>("Doesn'tExist");
                }
                taskExists.State = task.State;

                dbContext.Tasks.Update(taskExists);
                _unitOfWork.Complete(dbContext);

                return new Response<Tasks>(task);
            }


        }
    }
}
