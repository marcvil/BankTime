using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface IRequestService
    {
        Task<Response<Request>> GetById(int id);
        Task<Response<Request>> GetByUser(int id);
        Task<Response<Request>> GetByTask(int id);
        Task<Response<List<Request>>> GetAll();
    }
}
