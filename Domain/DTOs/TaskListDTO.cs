using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.DTOs
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }

        public int Hours  { get; set; }
        public string StateName  { get; set; }
        
    }
}
