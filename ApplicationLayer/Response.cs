using System;
using System.Collections.Generic;
using System.Text;

namespace BankTimeApp.ApplicationLayer
{
 
        public class Response<T>
        {
            public Response()
            {
            }
            public Response(T data)
            {
                Succeeded = true;
                Message = String.Empty;
                Data = data;
            }

            public Response(T data, string message)
            {
                Succeeded = true;
                Message = message;
                Data = data;
            }

            public Response(string error)
            {
                Succeeded = false;

                if (!string.IsNullOrWhiteSpace(error))
                {
                    this.Errors = new List<string>();
                    this.Errors.Add(error);
                }
            }
            public bool Succeeded { get; set; }
            public string Message { get; set; }
            public List<string> Errors { get; set; }
            public T Data { get; set; }
        }
    
}