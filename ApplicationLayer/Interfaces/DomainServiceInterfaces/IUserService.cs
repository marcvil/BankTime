using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface IUserService
    {
        Task<Response<User>> GetById(int id);
        Task<Response<User>> GetByName(string name);
        Task<Response<List<User>>> GetAll();
    }
}
