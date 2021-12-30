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

        public ICollection<Tasks> Tasks { get; set; }

        //Many To Many


    }
}
