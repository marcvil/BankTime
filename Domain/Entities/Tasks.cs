using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using static BankTimeApp.Domain.Enums.Enums;

namespace BankTimeApp.Domain.Entities
{
    public class Tasks : Entity
    {
        public string Name { get; set; }

        public int State { get; set; }  //Pasaré el int para saber que estado es

        public string UserCreated { get; set; }
        public string UserAssigned { get; set; }

        //One to One Relationships

        //One To Many Relationships



        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<Request> Requests { get; set; }

        //Many To Many

    }
}
