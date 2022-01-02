using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.Domain.DTOs
{
    public class ExchangeListDTO
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public string UserCreated { get; set; }
        public string UserAsigned { get; set; }
        public int IdTareaRelacionada { get; set; }
        public string TareaRelacionadaName { get; set; }
    }
}
