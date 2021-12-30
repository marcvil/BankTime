using BankTimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankTimeApp.ApplicationLayer.Interfaces.DomainServiceInterfaces
{
    public interface ICategoryService
    {
        Response<Category> GetById(int id);
        Response<Category> Post(Category category);
    }
}
