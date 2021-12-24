using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.Entities
{
    public class Exchanges : Entity
    {
        public DateTime TimeToCompleteTask { get; set; }
        public int ExchangeState { get; set; }


        //One to One Relationships

        public int UserWhoOwesHoursId { get; set; } 
        public ApplicationUser UserWhoOwesHours { get; set; }

        public int UserWhoCompletedTaskId { get; set; }
        public ApplicationUser UserWhoCompletedTaskHours { get; set; }


        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        //One To Many Relationships

        //Many To Many
    }
}
