using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.BaseEntity
{
    public interface IEntity
    {
         DateTime CreatedOn { get; set; }
         string CreatedBy { get; set; }

         DateTime? ModifiedOn { get; set; }
         string ModifiedBy { get; set; }
    }
}
