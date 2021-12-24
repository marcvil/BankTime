using BankTimeApp.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.Entities
{
    public class TaskCategories : Entity
    {
        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
