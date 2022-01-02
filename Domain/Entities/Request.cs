using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.Entities
{
    public class Request : Entity
    {
        public DateTime  RequestTimeToComplete { get; set; }


        //One to One Relationships

        //One To Many Relationships
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        //Many To Many
    }
}
