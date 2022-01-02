using BankTimeApp.Domain.BaseEntity;
using BankTimeApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static BankTimeApp.Domain.Enums.Enums;

namespace BankTimeApp.Domain.Entities
{
    public class Tasks : Entity
    {
        public string Name { get; set; }

        public int State { get; set; }  //Pasaré el int para saber que estado es



        //One to One Relationships

     
        public Exchanges Exchange { get; set; }

        //One To Many Relationships

        public int CategoryId { get; set; }
        public Category Category { get; set; }


 


        //Many To Many

    }
}
