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

namespace BankTimeApp.Infrastructure.Persistence.Services
{
    public class ExchangesService : IExchangeService
    {
        protected readonly ApplicationDbContextFactory _contextFactory;

        private readonly IUnitOfWork _unitOfWork;

        public ExchangesService(ApplicationDbContextFactory context, IUnitOfWork unitOfWork)
        {
            _contextFactory = context;
            _unitOfWork = unitOfWork;
        }
        public Response<Exchanges> GetById(int id)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var exchange = dbContext.Exchanges.Include(x=>x.Task).FirstOrDefault(x => x.Id == id);
                if (exchange == null)
                {
                    return new Response<Exchanges>("Not found");
                }
                return new Response<Exchanges>(exchange);
            }

        }
 
        public Response<List<Exchanges>> GetAll()
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var exchanges = dbContext.Exchanges.Include(x => x.Task).ToList();

                if (exchanges.Count == 0)
                {
                    return new Response<List<Exchanges>>("No existen tareas");
                }
                return new Response<List<Exchanges>>(exchanges);
            }

        }
        public Response<Exchanges> Post(Exchanges exchange)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var exchangeExists = GetById(exchange.Id);

                if (exchangeExists.Data != null)
                {
                    return new Response<Exchanges>("Already exist with this name");
                }

                dbContext.Exchanges.Add(exchange);
                _unitOfWork.Complete(dbContext);

                return new Response<Exchanges>(exchange);
            }

        }
        public Response<Exchanges> Update(Exchanges exchange)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                var exchangeExists = GetById(exchange.Id);

                if (exchangeExists.Data == null)
                {
                    return new Response<Exchanges>("No existe elemento");
                }

                dbContext.Exchanges.Update(exchange);
                _unitOfWork.Complete(dbContext);

                return new Response<Exchanges>(exchange);
            }
     
        }

    }
}
