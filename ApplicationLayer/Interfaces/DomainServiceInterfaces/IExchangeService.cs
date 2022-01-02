using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface IExchangeService
    {
        Response<Exchanges> GetById(int id);
        Response<List<Exchanges>> GetAll();
        Response<Exchanges> Post(Exchanges exchange);
        Response<Exchanges> Update(Exchanges exchange);
    }
}
