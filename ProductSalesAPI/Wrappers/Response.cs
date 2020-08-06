using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = "success";
            Errors = false;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public bool Errors { get; set; }
        public string Message { get; set; }
    }
}
