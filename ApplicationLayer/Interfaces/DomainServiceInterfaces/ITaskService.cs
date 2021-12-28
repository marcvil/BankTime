using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface ITaskService
    {
        Task<Response<Tasks>> GetById(int id);
        Task<Response<Tasks>> GetByName(string name);
        Task<Response<Tasks>> GetByUser(int id);
        Task<Response<Tasks>> GetByState(int id);
        Task<Response<List<Tasks>>> GetAll();
    }
}
