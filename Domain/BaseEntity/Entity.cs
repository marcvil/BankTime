using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.BaseEntity
{
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }


    }
}
