using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankTimeApp.Domain.Entities
{
    public class Exchanges : Entity
    {
        public int TimeToCompleteTask { get; set; }
        public int ExchangeState { get; set; }


        //One to One Relationships

        public string UserCreated { get; set; }
        public string UserAssigned { get; set; }

    
        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        //One To Many Relationships

        //Many To Many
    }
}
