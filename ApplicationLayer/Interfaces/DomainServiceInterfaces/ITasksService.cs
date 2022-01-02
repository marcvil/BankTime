using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface ITasksService
    {
        Response<Tasks> GetById(int id);
        Response<Tasks> GetByName(string name);
        Response<List<Tasks>> GetAll();
        Response<Tasks> Post(Tasks task);
        Response<Tasks> Update(Tasks task);
    }
}
