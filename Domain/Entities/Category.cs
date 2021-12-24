using BankTimeApp.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        //One to One Relationships

        //One To Many Relationships

        //Many To Many
        public ICollection<TaskCategories> Tasks { get; set; }

    }
}
